using Microsoft.EntityFrameworkCore;
using SampleShop.ApplicationService.Contract.Dtos.ColorDtos;
using SampleShop.ApplicationService.Contract.Dtos.CommentDto;
using SampleShop.ApplicationService.Contract.Dtos.ProductDetailDtos;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.Domain.IRepositories;
using SampleShop.Domain.Models;
using SampleShop.InfraStracture.Repositories;

namespace SampleShop.ApplicationService.Services
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IProductDetailRepository repository;
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IColorRepository colorRepository;
        private readonly IFeatureRepository featureRepository;
        private readonly IBaseRepository<long,Comment> commentRepository;

        public ProductDetailService(IProductDetailRepository repository, IProductRepository productRepository, ICategoryRepository categoryRepository, IColorRepository colorRepository, IFeatureRepository featureRepository, IBaseRepository<long, Comment> commentRepository)
        {
            this.repository = repository;
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
            this.colorRepository = colorRepository;
            this.featureRepository = featureRepository;
            this.commentRepository = commentRepository;
        }

        public void Add(ProductDetailAddDto dto)
        {
            var productDetail = new ProductDetail()
            {
                CreateObjectDat = dto.CreateObjectDate,
                Description = dto.Description,
                Id = dto.Id,
                IsDelete = dto.IsDelete,
                ProductId = dto.ProductId
            };
            repository.Add(productDetail);
            repository.SaveChanges();
        }

        public void Delete(long id)
        {
            repository.Delete(id);
            repository.SaveChanges();
        }

        public List<ProductDetailDto> GetAll()
        {
            return repository.GetAll()
            .Select(x => new ProductDetailDto()
            {
                CreateObjectDate = x.CreateObjectDat,
                Description = x.Description,
                Id = x.Id,
                IsDelete = x.IsDelete,
                ProductId = x.ProductId
            }).ToList();
        }

        public ProductDetailDto GetProductDetail(long productId)
        {
            var result = (from pd in repository.GetAll()
                          join p in productRepository.GetAll()
                             on pd.ProductId equals p.Id
                          join co in colorRepository.GetAll()
                              on p.Id equals co.ProductId
                          join cm in commentRepository.GetAll()
                              on p.Id equals cm.ProductId
                          join ca in categoryRepository.GetAll()
                              on p.CategoryId equals ca.Id
                          where pd.ProductId == productId
                          select new ProductDetailDto()
                          {
                              Colors = colorRepository.GetAll()
                              .Select(co => new ColorDto()
                              {
                                  CreateObjectDate = co.CreateObjectDat,
                                  Id = co.Id,
                                  IsDelete = co.IsDelete,
                                  ProductId = co.ProductId,
                                  Name = co.Title
                              }).ToList(),
                              CategoryName = ca.Title,
                              CreateObjectDate = pd.CreateObjectDat,
                              Description = pd.Description,
                              Id = pd.Id,
                              IsDelete = pd.IsDelete,
                              ProductImageName = p.ImageName,
                              ProductId = pd.ProductId,
                              Price = p.Price,
                              ProductName = p.Title,
                              Comments = commentRepository.GetAll()
                              .Select(c=> new CommentDto()
                              {
                                  CommentName = c.CommentName,
                                  CreateObjectDate = c.CreateObjectDat,
                                  Id = c.Id,
                                  IsDelete = c.IsDelete,
                                  ProductId = c.ProductId
                              }).ToList(),
                              Features = featureRepository.GetAll()
                              .Select(f=> new Contract.Dtos.FeatureDtos.FeatureDto()
                              {
                                  CreateObjectDate = f.CreateObjectDat,
                                  Id = f.Id,
                                  IsDelete = f.IsDelete,
                                  ProductId = f.ProductId,
                                  Title = f.Name
                              }).ToList()
                          }).FirstOrDefault();
            return result;
        }

        public void Update(ProductDetailUpdateDto dto)
        {
            var productDetail = repository.GetById(dto.Id);
            productDetail.Description = dto.Description;
            productDetail.IsDelete = dto.IsDelete;
            productDetail.CreateObjectDat = dto.CreateObjectDate;
            productDetail.ProductId = dto.ProductId;
        }
    }
}
