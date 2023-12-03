using MassTransit;
using Microsoft.Extensions.Options;
using RiseAssessment.Core.Messages;
using RiseAssessment.Services.Contact.Consumers;
using RiseAssessment.Services.Contact.Services;
using RiseAssessment.Services.Contact.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<PersonNameChangedEventConsumer>();
    x.AddConsumer<GetLocationReportDatasConsumer>();
    // Default Port : 5672
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMQUrl"], "/", host =>
        {
            host.Username("guest");
            host.Password("guest");
        });

        cfg.ReceiveEndpoint("person-name-changed-event-contact-service", e =>
        {
            e.ConfigureConsumer<PersonNameChangedEventConsumer>(context);
        });

        cfg.ReceiveEndpoint("create-location-report-service", e =>
        {
            e.ConfigureConsumer<GetLocationReportDatasConsumer>(context);
        });
    });

});
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
