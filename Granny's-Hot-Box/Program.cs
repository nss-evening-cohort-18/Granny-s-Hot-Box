using Granny_s_Hot_Box.Repositories;
using Granny_s_Hot_Box.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

var builder = WebApplication.CreateBuilder(args);

//FirebaseApp.Create(new AppOptions
//{
//    Credential = GoogleCredential.FromFile("")
//});

var firebaseProjectId = builder.Configuration.GetValue<string>("Authentication:Firebase:ProjectId");
var googleTokenUrl = $"https://securetoken.google.com/{firebaseProjectId}";
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = googleTokenUrl;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = googleTokenUrl,
            ValidateAudience = true,
            ValidAudience = firebaseProjectId,
            ValidateLifetime = true
        };
    });



// Add services to the container.
builder.Services.AddTransient<IUser, UserRepository>();
builder.Services.AddTransient<IMealProduct, MealProductRepository>();
builder.Services.AddTransient<IOrderMeals, OrderMealsRepository>();
builder.Services.AddTransient<IPaymentType, PaymentTypeRepository>();
builder.Services.AddTransient<IOrder, OrderRepository>();
builder.Services.AddTransient<IUserPayment, UserPaymentRepository>();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
