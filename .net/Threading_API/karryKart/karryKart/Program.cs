using ConsoleToDB.Data;
using Contracts;
using Enity.Auth;
using Entity.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System.Text;
var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(optionsAction: options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectDB")));
builder.Services.AddScoped<IparentCategoryServices, ParentCategoryRepository>();
builder.Services.AddScoped<ICategoryServices, CategoryRepository>();
builder.Services.AddScoped<IManufacturerServices, ManufacturerRepo>();
builder.Services.AddScoped<IProductServices, ProductRepository>();
builder.Services.AddScoped<ITaxServices, TaxRepository>();
builder.Services.AddScoped<IShippingServices, ShippingRepository>();
builder.Services.AddScoped<IVendorsServices, VendorRepository>();
builder.Services.AddScoped<IDiscountsServices, DiscountRepository>();
builder.Services.AddScoped<IRentalServices, RentalRepository>();
builder.Services.AddScoped<IDownloadableProductServices, DownloadRepository>();
builder.Services.AddScoped<IGiftCardServices, GiftCardRepository>();
builder.Services.AddScoped<IInventoryServices, InventoryRepository>();
builder.Services.AddScoped<ISEOServices, SEORepository>();
builder.Services.AddScoped<IRecurringProductServices, RecurringProductRepository>();
builder.Services.AddScoped<IRewardPointservices, RewardPointRepository>();
builder.Services.AddScoped<IOnlineCustomerRepo, OnlineCustomerRepository>();
builder.Services.AddScoped<IOrders, OrderRepository>();
builder.Services.AddScoped<IStockSubscriptions, StockSubscriptionsRepository>();
builder.Services.AddScoped<ICartAndWishlistServices, CartAndWishlistRepository>();
builder.Services.AddScoped<IAddressRepo, AddressRepository>();
builder.Services.AddScoped<ICustomerRoleService, CustomerRoleRepository>();
builder.Services.AddScoped<ICustomerInfo, CustomerInfoRepository
    >();
builder.Services.AddDbContext<AppDbContext>(optionsAction: options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("connectDB")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Adding Jwt Bearer
.AddJwtBearer(options =>
{  
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!))
    };   
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();