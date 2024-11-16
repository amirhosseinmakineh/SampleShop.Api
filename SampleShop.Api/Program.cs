using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SampleShop.ApplicationService.Contract.Dtos.Category;
using SampleShop.ApplicationService.Contract.IServices;
using SampleShop.ApplicationService.Services;
using SampleShop.Domain.IRepositories;
using SampleShop.InfraStracture.Context;
using SampleShop.InfraStracture.Repositories;
var builder = WebApplication.CreateBuilder(args);
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
#endregion
#region RegisterServices
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
#endregion
#region RegisterRedisServices
builder.Services.AddScoped<IRedisConfigurationService<CategoryDto>, RedisConfigurationService<CategoryDto>>();
#endregion
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
}
app.Run();