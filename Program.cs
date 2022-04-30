using CodeWarsReservationBackend.Services;
using CodeWarsReservationBackend.Services.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CohortService>();
builder.Services.AddScoped<ReservationService>();
builder.Services.AddScoped<CompletedKatasService>();


var connectionString = builder.Configuration.GetConnectionString("CodeWarsString");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

// Adding CORS POLICY HERE
builder.Services.AddCors(options => {
    options.AddPolicy("CodeWarsPolicy",
    builder => {
        builder.WithOrigins("http://localhost:3000","http://localhost:3001","http://localhost:3002","http://localhost:3005", "https://codestackkatareservebackend.azurewebsites.net","https://codestackkatareserve.azurewebsites.net", "https://scottskatatrackerfe.azurewebsites.net")
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});




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

app.UseCors("CodeWarsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
