using SampleLibrary;
using SearchEngine.Service;

namespace SearchEngine;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddOpenApiDocument();
        services.AddScoped<IFileReader, FileReader>();
        services.AddScoped<IIndexer, Indexer>();
        services.AddScoped<IQueryManager, QueryManager>();
        services.AddScoped<IDocumentService, DocumentService>();
    }
    
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseSwaggerUi3();
        app.UseOpenApi();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}