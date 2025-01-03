using SampleShop.ApplicationService.Contract.Convertor;
using SampleShop.ApplicationService.Contract.Dtos;
using SampleShop.ApplicationService.Contract.Dtos.Category;
using SampleShop.ApplicationService.Contract.GlobalEnums;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.IRepositories;
using SampleShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using SampleShop.InfraStracture.Repositories;
using SampleShop.Domain.UnitOfWork;
using Microsoft.AspNetCore.Http;

namespace SampleShop.ApplicationService.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;
        private readonly ICategoryRepository categoryRepository;
        private readonly DateConvertor dateConvertor;
        private readonly IUnitOfWork unitOfWork;
        public ProductService(IProductRepository repository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(ProductAddDto dto)
        {
            var product = new Product()
            {
                CategoryId = dto.CategoryId,
                ImageName = dto.ImageName,
                IsDelete = dto.IsDelete,
                Price = dto.Price,
                Title = dto.Title,
                CreateObjectDat = dto.CreateObjectDate
            };
            repository.Add(product);
            SaveImage(dto.ImageName,dto.ImageUpload);
            int count = repository.SaveChanges();

        }

        public bool CheckImage(ProductUpdateDto dto)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), CdnConfiguration.FileUrl, dto.ImageName);
            if (File.Exists(imagePath))
                return true;
            return false;
        }

        public void DeleteImage(ProductUpdateDto dto)
        {
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), CdnConfiguration.FileUrl, dto.ImageName);
            if (CheckImage(dto))
                File.Delete(imagePath);
        }

        public void DeleteProduct(long id)
        {
            repository.Delete(id);
            repository.SaveChanges();
        }

        public List<ProductDto> GetAllProducts()
        {
            var products = (from p in repository.GetAll()
                           where p.IsDelete == false
                           select new ProductDto()
                           {
                               CategoryId = p.CategoryId,
                               CategoryTitle = p.Category.Title,
                               CreateObjectDate = p.CreateObjectDat,
                               ImageName = p.ImageName,
                               IsDelete = p.IsDelete,
                               Title = p.Title,
                               Price = p.Price
                           }).ToList();
            return products;
        }

        public List<ProductDto> GetNewsProduct()
        {
            var result = repository.GetAll()
                .Select(x => new ProductDto()
            {
                CategoryTitle = x.Category.Title,
                CreateObjectDate = x.CreateObjectDat,
                ImageName = $"{CdnConfiguration.FileUrl}/{x.ImageName}",
                IsDelete = x.IsDelete,
                Price = x.Price,
                Title = x.Title,
                CategoryId = x.CategoryId,
                Id = x.Id
            }).Where(x=> x.IsDelete == false)
            .OrderBy(x => x.CreateObjectDate)
            .ToList();
            return result;
        }

        public List<ProductDto> GetSpacialProducts()
        {
            var result = repository.GetAll()
               .Select(x => new ProductDto()
               {
                   CategoryTitle = x.Category.Title,
                   CreateObjectDate = x.CreateObjectDat,
                   ImageName = $"{CdnConfiguration.FileUrl}/{x.ImageName}",
                   IsDelete = x.IsDelete,
                   Price = x.Price,
                   Title = x.Title,
                   CategoryId = x.CategoryId,
                   Id = x.Id
               }).Where(x=> x.IsDelete == false)
               .OrderByDescending(x => x.Price)
               .ToList();
            return result;
        }

        public void SaveImage(string imageName, IFormFile file)
        {
            var destinationPath = CdnConfiguration.FileUrl + $"/{file.FileName}";
            using (var stream = new FileStream(destinationPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }


        public void UpdateProduct(ProductUpdateDto dto)
        {
            var product = repository.GetById(dto.Id);
            if (product != null)
            {
                product.Price = dto.Price;
                product.Title = dto.Title;
                product.CategoryId = dto.CategoryId;
                product.ImageName = dto.ImageName;
                product.Category.Title = dto.CategoryTitle;
                repository.Update(product);
                repository.SaveChanges();
            }
            else
                throw new NullReferenceException();
            DeleteImage(dto);
            SaveImage(dto.ImageName, dto.ImageUpload);
        }
    }
}
