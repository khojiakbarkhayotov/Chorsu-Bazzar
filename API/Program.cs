using Microsoft.EntityFrameworkCore;
using API.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// public IConfiguration Configuration { get; } 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<API.Data.StoreContext>(opt=>{
//   object Configuration = null;
//   opt.UseSqlite(Configuration.GetConnectionString("Default Connection"));
// });
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<API.Data.StoreContext>(opt => opt.UseSqlite(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<StoreContext>();
// var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
try{
    context.Database.Migrate();
     DBInitializer.Initialize(context);

} catch(Exception ex){
    System.Console.WriteLine(ex);
    System.Console.WriteLine("Problem migrating data");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
