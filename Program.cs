using Microsoft.EntityFrameworkCore;
//dotnet add package Microsoft.EntityFrameworkCore.SqlServer"lazem"

using Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add the DbContext

builder.Services.AddDbContext<AppdbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //http://localhost:5233/swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//dotnet add package Microsoft.EntityFrameworkCore.Design
//dotnet tool install --global dotnet-ef

//to update the database kol ta8yer t3melo fel models msln
//dotnet ef migrations add InitialCreate"any name"
//dotnet ef database update