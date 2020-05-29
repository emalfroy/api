namespace Dummy.Api.Infrastructure.Modules
{
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Be.Vlaanderen.Basisregisters.DataDog.Tracing.Autofac;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class ApiModule : Module
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _services;

        public ApiModule(
            IConfiguration configuration,
            IServiceCollection services)
        {
            _configuration = configuration;
            _services = services;
        }

        protected override void Load(ContainerBuilder containerBuilder)
        {
            // containerBuilder
            //     .RegisterModule(new LoggingModule(_configuration, _services));

            containerBuilder
                .RegisterModule(new DataDogModule(_configuration));

            containerBuilder
                .Populate(_services);
        }
    }
}
