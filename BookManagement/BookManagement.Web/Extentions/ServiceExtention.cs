using BookManagement.Web.Services;
using BookManagement.Web.Services.Abstract;

namespace BookManagement.Web.Extentions
{
    public static class ServiceExtention
    {
        public static void AddHttpClientServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHttpClient<IPersonService, PersonService>();

            services.AddHttpClient<IReportService, ReportService>();
        }
    }
}
