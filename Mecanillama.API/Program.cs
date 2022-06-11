using Mecanillama.API.Appointments.Domain.Repositories;
using Mecanillama.API.Appointments.Domain.Services;
using Mecanillama.API.Appointments.Persistence.Repositories;
using Mecanillama.API.Appointments.Services;
using Mecanillama.API.Customers.Domain.Repositories;
using Mecanillama.API.Customers.Domain.Services;
using Mecanillama.API.Customers.Mapping;
using Mecanillama.API.Customers.Persistence.Repositories;
using Mecanillama.API.Customers.Services;
using Mecanillama.API.Mechanics.Domain.Repositories;
using Mecanillama.API.Mechanics.Domain.Services;
using Mecanillama.API.Mechanics.Persistence.Repositories;
using Mecanillama.API.Mechanics.Services;
using Mecanillama.API.Reviews.Domain.Repositories;
using Mecanillama.API.Reviews.Domain.Services;
using Mecanillama.API.Reviews.Persistence.Repositories;
using Mecanillama.API.Reviews.Services;
using Mecanillama.API.Shared.Domain.Repositories;
using Mecanillama.API.Shared.Persistence.Contexts;
using Mecanillama.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Add API Documentation Information
        
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Mecanillama API",
        Description = "Mecanillama RESTful API",
        TermsOfService = new Uri("https://mecanillama.github.io/Landing-Page/"),
        Contact = new OpenApiContact
        {
            Name = "Mecanillama.studio",
            Url = new Uri("https://mecanillama.github.io/Landing-Page/")
        },
        License = new OpenApiLicense
        {
            Name = "Mecanillama Resources License",
            Url = new Uri("https://mecanillama.github.io/Landing-Page/")
        }
    });
    options.EnableAnnotations();
});


// Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Database Connection with Standard Level for Information and Errors

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));

// Add lowercase routes

builder.Services.AddRouting(options => 
    options.LowercaseUrls = true);

// Dependency Injection Configuration

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IMechanicRepository, MechanicRepository>();
builder.Services.AddScoped<IMechanicService, MechanicService>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper Configuration

builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));

var app = builder.Build();

// Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();