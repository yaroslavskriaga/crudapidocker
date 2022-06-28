using crudapi.Data;
using crudapi.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Register services
RegisterServices(builder.Services);

var app = builder.Build();

// App configurations
ConfigureApp(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.Configure<UsersDatabaseSettings>(builder.Configuration.GetSection("UsersDatabaseSettings"));
    services.AddScoped<UserService>();
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("version_1", new OpenApiInfo 
        {
            Title = "Users CRUD API",
            Version = "version_1",
            Description = "Users CRUD API using MongoDB",
        });
    });
}

void ConfigureApp(WebApplication app)
{
    var port = Environment.GetEnvironmentVariable("PORT");
    if (!string.IsNullOrWhiteSpace(port))
    {
        app.Urls.Add("http://*:" + port);
    }
    
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/version_1/swagger.json", "Users CRUD Api version_1");
    });
    
    app.UseHttpsRedirection();

    app.UseAuthorization();
    
    app.MapControllers();
}
