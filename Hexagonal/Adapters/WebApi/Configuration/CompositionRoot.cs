using Core.Ports;
using Core.UseCases;
using ExternalServices;
using Persistence;

namespace WebApi.Configuration
{
    public static class CompositionRoot
    {
        public static IServiceCollection InjectAdapters(this IServiceCollection services)
        {
            services.AddScoped<ICalendarService, CalendarAdapter>();
            services.AddScoped<IAppointmentRepository, AppointmentRepositoryAdapter>();
            services.AddScoped<CreateAppointmentCommandHandler>();
            services.AddScoped<RescheduleAppointmentCommandHandler>();

            return services;
        }
    }
}
