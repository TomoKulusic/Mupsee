using Mupsee.Interfaces;
using Mupsee.Services;
using Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Mupsee.Models.SettingsModels;

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
            /// For testing purposes here we enabled pretty much everything for this address.
            /// For production we would have to add real url addresses
            policy.WithOrigins("http://localhost:3000/").AllowAnyHeader().AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.Configure<ApiConfiguration>(options => builder.Configuration.GetSection("ApiSettings").Bind(options));
builder.Services.Configure<EmailConfiguration>(options => builder.Configuration.GetSection("EmailConfiguration").Bind(options));


builder.Services.AddScoped<IYoutubeApiService, YoutubeApiService>();
builder.Services.AddScoped<IImdbApiService, ImdbApiService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IFavoriteService, FavoriteService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSingleton(typeof(ICachingService<>), typeof(CachingService<>));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


builder.Services.AddMemoryCache();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
