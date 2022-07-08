using CalculosBasicos.Bussiness.Contracts;
using CalculosBasicos.Bussiness.Implements;

namespace CalculosBasicos.Server.Services
{
    public class RegisterServices
    {
        public static WebApplicationBuilder AddRegister(WebApplicationBuilder build)
        {
            RegisterServicesAll(build);
            //others services, example: data or extern services
            return build;
        }
        private static WebApplicationBuilder RegisterServicesAll(WebApplicationBuilder build)
        {
            build.Services.AddScoped<IOperationsBussiness, OperationsBussiness>();
            return build;
        }
    }
}
