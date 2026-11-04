using Microsoft.EntityFrameworkCore;
using QST.ECommerce.Application.Interfaces;
using QST.ECommerce.Application.Services;
using QST.ECommerce.Domain.Catalogue;
using QST.ECommerce.Infrastructure.DbContexts;
using QST.ECommerce.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var conStr = builder.Configuration.GetConnectionString("ECommerceDatabase");
//EF Core DbContext configuration
builder.Services.AddDbContext<CatalogDbContext>(options =>
    options.UseMySql(conStr, ServerVersion.AutoDetect(conStr)));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi(); // This line was causing the CS1061 error and has been removed


// Register Repository and Service for Dependency Injection
builder.Services.AddScoped<IProductService, ProductService>();  // to initialize Product Service in Application Layer through Constructor Dependency Injection
builder.Services.AddScoped<IProductRepository, ProductRepository>();  //Infrastructure Layer
builder.Services.AddScoped<IDeptService, DeptService>();// to initialize Department Service in Application Layer through Constructor Dependency Injection
builder.Services.AddScoped<IDeptRepository, DeptRepository>();  //Infrastructure Layer
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
