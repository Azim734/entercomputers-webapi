using EnterComputers.DataAcces.Interfaces.Categories;
using EnterComputers.DataAcces.Interfaces.Companies;
using EnterComputers.DataAcces.Interfaces.Users;
using EnterComputers.DataAcces.Repositories.Categories;
using EnterComputers.DataAcces.Repositories.Companies;
using EnterComputers.DataAcces.Repositories.Users;
using EnterComputers.Service.Dtos.Notification;
using EnterComputers.Service.Interfaces.Auth;
using EnterComputers.Service.Interfaces.Categories;
using EnterComputers.Service.Interfaces.Common;
using EnterComputers.Service.Interfaces.Companies;
using EnterComputers.Service.Interfaces.Notification;
using EnterComputers.Service.Interfaces.Users;
using EnterComputers.Service.Services.Auth;
using EnterComputers.Service.Services.Categories;
using EnterComputers.Service.Services.Common;
using EnterComputers.Service.Services.Companies;
using EnterComputers.Service.Services.Notifications;
using EnterComputers.Service.Services.Users;
using EnterComputers.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

//-> DI containers, IoC containers
// AddSingelton, AddScoped, AddTransient
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddScoped<IFileService, FileServic>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IcompanyService, CompaniService>();


builder.Services.AddScoped<ITokenService, TokenService>();  
//ilder.Services.AddScoped<ITokenService, AuthService>();
builder.Services.AddSingleton<ISmsSender, SmsSender>();




builder.Services.AddSingleton<IShortStorageService, ShortStorageService>();
builder.Services.AddScoped<IShortStorageService, ShortStorageService>();
builder.Services.AddTransient<IShortStorageService, ShortStorageService>();

builder.ConfigureJwtAuth();
builder.ConfigureSwaggerAuth();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();
