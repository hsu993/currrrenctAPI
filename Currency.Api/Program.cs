using Currency.Api.Parameter;
using Currency.Api.Validators;
using Currency.Model.Dtos.DataModel;
using Currency.Model.Implement;
using Currency.Model.Interface;
using Currency.Model.Models;
using Currency.Model.Models.Interface;
using Currency.Model.Models.Repository;
using Currency.Service.Implement;

using Currency.Service.Interface;
using FluentValidation;


//using Currency.Service;
//using Currency.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.ComponentModel;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// 參考 https://igouist.github.io/post/2022/03/newbie-7-fluent-validation/
// Add services to the container.
// 依賴注入的三種生命週期 Transient、Scoped、Singleton
/*
    Transient（一次性）：每次注入都建立一個新的 
    Scoped（作用域）：每次 Request 都建立一個新的，同個 Request 重複利用同一個
    Singleton（單例）：只建立一個新的，每次都重複利用同一個
 */

// 註冊 ICardRepository 的實作為 CardRepository
#region -- Service --

builder.Services.AddScoped<ICardService, CardService>();
//builder.Services.AddFluentValidation();
//builder.Services.AddTransient<IValidator<CardParameter>, CardParameterValidator>();
//builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());
#endregion

#region -- Repository --

// Repsitory
//builder.Services.AddScoped<ICardRepository, CardRepository>();
builder.Services.AddScoped<ICardRepository>(sp =>
{
    //var connectString = @"Server=.;Database=Currency;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;";
    var connectString = builder.Configuration.GetConnectionString("DefualtDatabase");
    return new CardRepository(connectString);
});

#endregion

// Others
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();// 註冊 Swagger

builder.Services.AddSwaggerGen(c =>
{
    // API 服務簡介
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "菜雞 API",
        Description = "菜雞新訓記的範例 API",
        TermsOfService = new Uri("https://igouist.github.io/"),
        Contact = new OpenApiContact
        {
            Name = "Igouist",
            Email = string.Empty,
            Url = new Uri("https://igouist.github.io/about/"),
        },
        License = new OpenApiLicense
        {
            Name = "TEST",
            Url = new Uri("https://igouist.github.io/about/"),
        }
    });

    // 讀取 XML 檔案產生 API 說明
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


// GetConnectionString()裡的值會根據你剛剛在appsettings.json的ConnectionStrings裡設定的值，所以這邊你也可以自行做設定
builder.Services.AddDbContext<CurrencyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtDatabase")));

//// Repository
//container.RegisterType<IRepository<Categories>, DataRepository<Categories>>(new InjectionConstructor(dbContext));
//builder.Services.AddScoped<Currency, CurrencyService>();


//// Service
////將 MyService1 註冊為 Scope 
//builder.Services.AddScoped<ICurrencyService, CurrencyService>();

////將 MyService2 註冊為 Transient 
////builder.Services.AddTransient<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    //app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    //});
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        //c.RoutePrefix = string.Empty; // 指定路徑為 ""
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
