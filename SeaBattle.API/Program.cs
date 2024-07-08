using SeaBattle.WebApplication.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<EngineService>();
builder.Services.AddControllers();
builder.Services.AddLogging();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

// Enable CORS
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
