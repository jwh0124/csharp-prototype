using CUPrototype.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CUPrototype
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {


            DatabaseContext context = applicationBuilder.ApplicationServices.GetRequiredService<DatabaseContext>();

            context.Database.EnsureCreated();
        }
    }
}
