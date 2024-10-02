using Microsoft.Extensions.DependencyInjection;

namespace Prueba.Services;

public static class ServiceRegistrations
{
    public static void AddServicesLayer(this IServiceCollection services)
    {
        //Servicio de rollback para transacciones con la base de datos
        //services.AddTransient<ICommitAndRollBackContextService, CommitAndRollBackContextService>();
    }
}