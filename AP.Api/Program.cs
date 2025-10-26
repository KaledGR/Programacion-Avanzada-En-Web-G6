using AP.Core.BusinessLogic;
using AP.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITaskBusiness, TaskBusiness>();
builder.Services.AddScoped<IRepositoryTask, RepositoryTask>();
builder.Services.AddScoped<ISourceItemBusiness, SourceItemBusiness>();
builder.Services.AddScoped<IRepositorySourceItem, RepositorySourceItem>();
builder.Services.AddScoped<ISourceBusiness, SourceBusiness>();
builder.Services.AddScoped<IRepositorySource, RepositorySource>();

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
