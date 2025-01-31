using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplicationCommand.Data;
using WebApplicationCommand.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var sqlConnBuilder = new SqlConnectionStringBuilder();
sqlConnBuilder.ConnectionString = builder.Configuration.GetConnectionString("CommandConnectionString");


builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseSqlServer(sqlConnBuilder.ConnectionString)
);
builder.Services.AddScoped<ICommandRepo, CommandRepo>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
