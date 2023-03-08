using Microsoft.EntityFrameworkCore;
using OrderManagment.Data;
using OrderManagment.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors(options => options.AddPolicy(name: "OrderManagment",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<IOrderServices, OrderServices>();
builder.Services.AddScoped<IOrderProductsServices, OrderProductsServices>();
builder.Services.AddScoped<IContractorServices, ContractorServices>();
builder.Services.AddScoped<IProductServices, ProductServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("OrderManagment");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
