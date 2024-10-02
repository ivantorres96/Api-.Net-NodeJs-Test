using Microsoft.Extensions.DependencyInjection;
using Prueba.Domains.Domains;
using Prueba.Domains.Interfaces;

namespace Prueba.Domains;

public static class DomainRegistrations
{
    public static void AddDomainsLayer(this IServiceCollection services)
    {
        //Registro de los dominios
        services.AddTransient<IProductDomain, ProductDomain>();
    }
}   