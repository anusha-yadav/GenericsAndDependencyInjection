using ECommerce.Data.Entities;
using ECommerce.Repository.Contracts;
using ECommerce.Repository.Implementation;
using ECommerce.Services.Contracts;
using ECommerce.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProductManagement.Enums;
using ProductManagement.FactoryPattern;
using System.Text;
using Product = ProductManagement.Models.Product;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379";
    options.InstanceName = "MyAppCache:";
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
            };
        });

builder.Services.AddControllers();

builder.Services.AddDbContext<ECommerceDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("EcommerceDB")));

builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<TokenService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


var product = new Product
{
    Id = 1,
    ProductCategory = "Electronics",
    ProductDescription = "Phones",
    ProductName = "Samsung A21s"
};

var jsonSerializer = DataConverter<Product>.GetSerializerFormat(FormatType.Json);
var xmlSerializer = DataConverter<Product>.GetSerializerFormat(FormatType.Xml);

string jsonData = jsonSerializer.Serialize(product);
Console.WriteLine(jsonData);
string xmlData = xmlSerializer.Serialize(product);
Console.WriteLine(xmlData);

app.Run();

