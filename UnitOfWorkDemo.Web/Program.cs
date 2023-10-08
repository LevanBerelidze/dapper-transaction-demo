using UnitOfWorkDemo.Web.Utils;
using UnitOfWorkDemo.Core;
using UnitOfWorkDemo.Infra;

namespace UnitOfWorkDemo.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCore();
            builder.Services.AddInfrastructure();
            builder.Services
                .AddControllers(x => x.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
                .AddNewtonsoftJson(x =>
                {
                    x.SerializerSettings.ContractResolver = new DataAnnotationsContractResolver();
                    x.UseCamelCasing(processDictionaryKeys: true);
                });

            WebApplication app = builder.Build();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}