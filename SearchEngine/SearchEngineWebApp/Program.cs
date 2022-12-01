using SampleLibrary;
using SearchEngine.Service;

namespace SearchEngine;

internal static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddOpenApiDocument();
        builder.Services.AddScoped<IFileReader, FileReader>();
        builder.Services.AddScoped<IIndexer, Indexer>();
        builder.Services.AddScoped<IQueryManager, QueryManager>();
        builder.Services.AddScoped<IDocumentService, DocumentService>();


        var app = builder.Build();

// Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseSwaggerUi3();
        app.UseOpenApi();


        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            "default",
            "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}