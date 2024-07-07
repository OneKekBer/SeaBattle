using SeaBattle.WebApplication.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<EngineService>();

var app = builder.Build();



app.Run();
