﻿using Microsoft.AspNetCore.Http;
using SampleShop.ApplicationService.Contract.Dtos;

namespace SampleShop.ApplicationService.Contract.IServices
{
    public interface IProductService
    {
        List<ProductDto> GetNewsProduct();
        List<ProductDto> GetSpacialProducts();
        void Add(ProductAddDto dto);
        void UpdateProduct(ProductUpdateDto dto);
        List<ProductDto> GetAllProducts();
        void DeleteProduct(long id);
        void SaveImage(string imageName , IFormFile file);
        bool CheckImage(ProductUpdateDto dto);
        void DeleteImage(ProductUpdateDto dto);
    }
}
