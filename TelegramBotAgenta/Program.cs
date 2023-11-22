using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using TelegramBotAgenta;
using TelegramBotAgenta.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var token = builder.Configuration["token"];
builder.Services.AddSingleton(new TelegramBotClient(token));
builder.Services.AddHostedService<BacgroundServicesBots>();
//builder.Services.AddSingleton(StaticServicesBot());


builder.Services.AddDbContext<DBDataAccess>();


var app = builder.Build();


app.Run();
