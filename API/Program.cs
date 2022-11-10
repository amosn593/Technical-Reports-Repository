using API.DIServices;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Azure.Storage.Blobs;

var builder = WebApplication.CreateBuilder(args);

var dbconnection = builder.Configuration.GetConnectionString("ReportsContext");

var blobconnection = builder.Configuration.GetConnectionString("BlobConnection");

builder.Services.AddDbContext<ReportsDbContext>(
    options => options.UseSqlServer(dbconnection)
    );

builder.Services.AddScoped(options =>
{
    return new BlobServiceClient(blobconnection);
});

// Add services to the container.

builder.Services.RegisterServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("reportfrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
