using Granny_s_Hot_Box.Repositories;
using Granny_s_Hot_Box.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IUser, UserRepository>();
builder.Services.AddTransient<IMealProduct, MealProductRepository>();
builder.Services.AddTransient<IPaymentType, PaymentTypeRepository>();
builder.Services.AddTransient<IOrder, OrderRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
