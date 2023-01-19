using DapperWorkshop.Data.Repositories;
using DapperWorkshop.Data.DAO;
using DapperWorkshop.Data.Connection;
using SqlKata.Compilers;
using DapperWorkshop.Data.Queries;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the DI container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IDbConnectionFactory, DbConnectionFactory>();
builder.Services.AddTransient<Compiler>(_ => new SqlServerCompiler());
builder.Services.AddTransient<IDbQueryFactory, DbQueryFactory>();
builder.Services.AddTransient<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddTransient<IEmployeeDataAccess, EmployeeDataAccess>();

WebApplication app = builder.Build();

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