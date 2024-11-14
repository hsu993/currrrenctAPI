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
// �Ѧ� https://igouist.github.io/post/2022/03/newbie-7-fluent-validation/
// Add services to the container.
// �̿�`�J���T�إͩR�g�� Transient�BScoped�BSingleton
/*
    Transient�]�@���ʡ^�G�C���`�J���إߤ@�ӷs�� 
    Scoped�]�@�ΰ�^�G�C�� Request ���إߤ@�ӷs���A�P�� Request ���ƧQ�ΦP�@��
    Singleton�]��ҡ^�G�u�إߤ@�ӷs���A�C�������ƧQ�ΦP�@��
 */

// ���U ICardRepository ����@�� CardRepository
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

builder.Services.AddSwaggerGen();// ���U Swagger

builder.Services.AddSwaggerGen(c =>
{
    // API �A��²��
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "���� API",
        Description = "�����s�V�O���d�� API",
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

    // Ū�� XML �ɮײ��� API ����
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});


// GetConnectionString()�̪��ȷ|�ھڧA���bappsettings.json��ConnectionStrings�̳]�w���ȡA�ҥH�o��A�]�i�H�ۦ氵�]�w
builder.Services.AddDbContext<CurrencyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtDatabase")));

//// Repository
//container.RegisterType<IRepository<Categories>, DataRepository<Categories>>(new InjectionConstructor(dbContext));
//builder.Services.AddScoped<Currency, CurrencyService>();


//// Service
////�N MyService1 ���U�� Scope 
//builder.Services.AddScoped<ICurrencyService, CurrencyService>();

////�N MyService2 ���U�� Transient 
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
        //c.RoutePrefix = string.Empty; // ���w���|�� ""
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
