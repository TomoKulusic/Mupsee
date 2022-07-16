using Mupsee.Interfaces;
using Mupsee.Models;
using Mupsee.Services;
using Repository.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MupseeContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("MupseeConnectionString");
    options.UseSqlServer(connectionString);
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000/").AllowAnyHeader().AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.Configure<ApiSettings>(options => builder.Configuration.GetSection("ApiSettings").Bind(options));

builder.Services.AddScoped<IYoutubeApiService, YoutubeApiService>();
builder.Services.AddScoped<IImdbApiService, ImdbApiService>();
builder.Services.AddScoped<IMupseeService, MupseeService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );

app.UseAuthorization();

app.MapControllers();

app.Run();
