using ASP1.MiddleWare;
using ASP1.Services.Hash;
using ASP1.Services.Kdf;
using HWASP.Data.Context;
using HWASP.Data.DAL;
using HWASP.Services.RandomServices;
using HWASP.Services.Upload;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRandomService, RandomService>();

//������������ �������� ����� � �������� ��� ������������
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MsSql"))
       /* .LogTo(Console.WriteLine, LogLevel.Information)*/,
    ServiceLifetime.Singleton
);

builder.Services.AddSingleton<DataAccessor>();

builder.Services.AddSingleton<IHashService, ShaHashService>();
builder.Services.AddSingleton<IKdfService, Pdkdf1Service>();
builder.Services.AddSingleton<IUploadService, UploadService>();
//��������� Http-������
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    //������� ��������� - ����� ���������������, �.�. ���� � ������� 10 ������ �� ������ �� ������ � ������, ������ ����������
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//��������� Http-������
app.UseSession();

//��� MiddleWare ��� ��������������  ����� ������
app.UseSessionAuth();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
