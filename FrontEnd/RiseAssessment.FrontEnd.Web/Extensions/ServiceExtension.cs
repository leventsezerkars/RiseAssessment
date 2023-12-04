
using FluentValidation.AspNetCore;
using RiseAssessment.FrontEnd.Web.Models;
using RiseAssessment.FrontEnd.Web.Services;
using RiseAssessment.FrontEnd.Web.Services.Interfaces;

namespace RiseAssessment.FrontEnd.Web.Extensions
{
    public static class ServiceExtension
    {
        public static void AddHttpClientServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHttpContextAccessor();
            services.AddFluentValidationAutoValidation();

            var serviceApiSettings = Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

            services.AddHttpClient<IPersonService, PersonService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Person.Path}");
            });

            services.AddHttpClient<IContactService, ContactService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Contact.Path}");
            });

            services.AddHttpClient<ILocationReportService, LocationReportService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Report.Path}");
            });

            services.AddHttpClient<ILocationReportDetailService, LocationReportDetailService>(opt =>
            {
                opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.Report.Path}");
            });

        }
    }
}