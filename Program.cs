using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MedPro.Models.EF.medProDBContext>(x => x.UseSqlServer("Server=tcp:p2project.database.windows.net,1433;Initial Catalog=medProDB;Persist Security Info=False;User ID=project2;Password=Password@4567;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
builder.Services.AddCors(option =>
{
  option.AddDefaultPolicy(policy =>
  {
    policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
  });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
