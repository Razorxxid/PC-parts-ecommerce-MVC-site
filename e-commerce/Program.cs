using AutoMapper;
using e_commerce.Data.Context;
using e_commerce.Data.Repository;
using e_commerce.Mapper;
using e_commerce.Models.asbstractClasses;
using e_commerce.Models.implementations;
using e_commerce.Models.interfaces;
using e_commerce.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Agrega servicios al contenedor.
        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<ProductContext>(
               options => options.UseSqlServer("name=ConnectionStrings:Products"));

        builder.Services.AddScoped(typeof(IProductRepository<>), typeof(ProductRepository<>));
        builder.Services.AddScoped(typeof(FilteredSearchService), typeof(FilteredSearchService));
        builder.Services.AddScoped(typeof(ProductFactory), typeof(ProductFactory));


        builder.Services.AddAutoMapper(typeof(MapperProfile), typeof(MapperProfile));

        builder.Services.AddScoped(typeof(List<AbstractProduct>)); 
        
        
        var app = builder.Build();

        

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseHttpMethodOverride();

        app.UseAuthorization();

        app.MapControllers();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}