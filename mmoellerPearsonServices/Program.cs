using Microsoft.EntityFrameworkCore;
using mmoellerPearsonServices.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<TechnicalRequestContext>( opt =>
    opt.UseInMemoryDatabase("FormList"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{

    //options.AddDefaultPolicy(
    //    policy =>
    //    {
    //        policy
    //            .AllowAnyHeader()
    //            .AllowAnyMethod()
    //        .AllowAnyOrigin();
    //    });
    options.AddPolicy(name: MyAllowSpecificOrigins,
                   policy =>
                   {
                       //policy.WithOrigins("http://localhost:3000"
                       //                  ); // add the allowed origins  
                       policy.AllowAnyHeader();
                       policy.AllowAnyMethod();
                       policy.AllowAnyOrigin();
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

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();

//app.UseCors();

