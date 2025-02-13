using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SampleApi.Security;
using SampleShop.ApplicationService.Contract.Dtos;
using SampleShop.ApplicationService.Contract.Dtos.Category;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.ApplicationService.Services;
using SampleShop.ApplicationService.UnitOfWork;
using SampleShop.Domain.AutoMapperConfiguration;
using SampleShop.Domain.IRepositories;
using SampleShop.Domain.UnitOfWork;
using SampleShop.InfraStracture.Context;
using SampleShop.InfraStracture.Repositories;
using SampleShop.InfraStracture.UnitOfWorks;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.GetSection("CdnConfiguration").Bind(new CdnConfiguration());
#region RegisterDbContext
builder.Services.AddDbContext<SampleShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SampleShopApi"));
});
#endregion
#region RegisterRepository
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductDetailRepository, ProductDetailRepository>();
builder.Services.AddScoped<IColorRepository, ColorRepository>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IBaseRepository<,>),typeof(BaseRepository<,>));
#endregion
#region RegisterServices
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<ISliderService, SliderService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();
#endregion
#region RegisterRedisServices
builder.Services.AddScoped<IRedisConfigurationService<CategoryDto>, RedisConfigurationService<CategoryDto>>();
builder.Services.AddScoped<IRedisConfigurationService<ProductDto>, RedisConfigurationService<ProductDto>>();
#endregion
#region RegisterAutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
#endregion
builder.Services.AddScoped<UnitOfWorkAttributeManager>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SampleApi API",
        Version = "v1",
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
});
var app = builder.Build();
app.MapControllers();

app.UseHttpsRedirection();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();