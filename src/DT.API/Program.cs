using Application;
using DT.API;
using DT.API.Middleware;
using Infrastructure;
using Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure();

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddWebUIServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();

    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextDefaultData>();
        await initialiser.DatabaseInitialiseAsync();
        await initialiser.SeedAsync();
    }

}
else
{
    app.UseHsts();

}

app.UseMiddleware<CustomExceptionHandlerMiddleware>();

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwaggerUi3(setting =>
{
    setting.Path = "/api";
    setting.DocumentPath = "/api/specification.json";
});

app.UseRouting();   
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name:"default",pattern:"{controller}/{action=index}/{id?}");

app.Run();
