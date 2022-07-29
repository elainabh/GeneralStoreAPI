using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using GeneralStoreAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpsRedirection(options => options.HttpsPort = 7132);
builder.Services.AddDbContext<GeneralStoreDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));  //COME BACK TO THIS 




static IHostBuilder CreateHostBuilder(string[] args) =>
Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
{
webBuilder.UseUrls("http://localhost:5178", "https://localhost:7132"); 
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

