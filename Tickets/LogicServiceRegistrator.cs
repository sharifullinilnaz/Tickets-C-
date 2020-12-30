using Tickets.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tickets
{
    public static class LogicServiceRegistrator
    {
        public static IServiceCollection RegisterLogicServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<ITicketService, TicketService>();
                

            return serviceCollection;
        }
    }
}
