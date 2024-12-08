using IdentityMailProject.BusinessLayer.Abstract;
using IdentityMailProject.BusinessLayer.Concrete;
using IdentityMailProject.DataAccessLayer.Abstract;
using IdentityMailProject.DataAccessLayer.Context;
using IdentityMailProject.DataAccessLayer.EntityFramework;
using IdentityMailProject.EntityLayer.Concrete;
using IdentityMailProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;

});



builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IMessageDal, EfMessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();

builder.Services.AddDbContext<IdentityMailContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<IdentityMailContext>().AddDefaultTokenProviders().AddErrorDescriber<CustomIdentityErrorValidator>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Message}/{action=Index}/{id?}");

app.Run();
