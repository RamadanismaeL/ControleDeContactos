using System.Text;
using controleDeContactos.Data;
using controleDeContactos.src.Services.Interfaces;
using controleDeContactos.src.Services.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
/**
** @author Ramadan Ismael
*/
string keyRam = "2a01df3ae34b5032b7c6ea2e4211e1d8c49effbae7825d76184481658713c16fbae20799648b3f81b2b872e1702ea73b18b5b462fd8d74df21b21e5b50098a55";
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(ram => {
    ram.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Contact and Task Management System.",
        Version = "v1",
        Description = "API for management contacts and tasks with JWT authentication",
        Contact = new OpenApiContact
        {
            Name = "Administrator : Ramadan Ibraimo Ismael",
            Email = "ramadan.ismael02@gmail.com",
            Url = new Uri("https://www.controledecontactos.com")
        }
    });
    var securitySchema = new OpenApiSecurityScheme
    {
        Name = "JWT Autentication",
        Description = "Enter with Bearer JWT {token}",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    ram.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securitySchema);
    ram.AddSecurityRequirement(new OpenApiSecurityRequirement {
        { securitySchema, new[] {"Bearer"} }
    });
});
builder.Services.AddAuthentication(ram => {
    ram.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    ram.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(ram => {
    ram.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "IsmaelBusinessSolution",
        ValidAudience = "ContactAndTaskManagementSystem",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyRam)),
        ClockSkew = TimeSpan.Zero
    };
});
builder.Services.AddAuthorization();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

var username = Environment.GetEnvironmentVariable("DB_USER") ?? throw new InvalidOperationException("DB_USER is not set");
var password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? throw new InvalidOperationException("DB_PASSWORD is not set");
var port = Environment.GetEnvironmentVariable("DB_PORT") ?? throw new InvalidOperationException("DB_PORT is not set");
var server = Environment.GetEnvironmentVariable("DB_SERVER") ?? throw new InvalidOperationException("DB_SERVER is not set");

//Console.WriteLine($"User: {username}, Password: {password}, Port: {port}");
string? connect = $"server={server}; port={port}; database=dbTaskContact; user={username}; password={password}; Persist Security Info=false; Connect Timeout=300";
builder.Services.AddDbContextPool<dbTaskContact>(ram => ram.UseMySql(connect, ServerVersion.AutoDetect(connect)));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();