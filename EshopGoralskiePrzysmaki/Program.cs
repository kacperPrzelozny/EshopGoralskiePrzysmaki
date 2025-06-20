using EshopGoralskiePrzysmaki;
using EshopGoralskiePrzysmaki.Models;
using EshopGoralskiePrzysmaki.Repositories.Categories;
using EshopGoralskiePrzysmaki.Repositories.Client;
using EshopGoralskiePrzysmaki.Repositories.Products;
using EshopGoralskiePrzysmaki.Services.Validation;
using EshopGoralskiePrzysmaki.Services.Validation.Categories;
using EshopGoralskiePrzysmaki.Services.Validation.Products;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("EshopGoralskiePrzysmaki"));

// DI
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryValidationService, CategoryValidationService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductValidationService, ProductValidationService>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    context.Clients.AddRange(
        new Client
        {
            Id = 1,
            FirstName = "Jan",
            LastName = "Kowalski",
            Address = "Kolorowa 31/2 31-508 Zbłaszynek",
            Email = "j.kowalski@gmail.com",
            Created = DateTime.Now,
            Edited = DateTime.Now
        }
    );
    context.SaveChanges();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
