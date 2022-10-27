using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace create_tests.WebAPI.AppConfiguration.ServicesExtensions 
{
  /// <summary>
  /// Services extensions
  /// </summary>
  public static partial class ServicesExtensions
  {
    /// <summary>
    /// Configure versioning
    /// </summary>
    /// <param name="services"></param>
    public static void AddVersioningConfiguration(this IServiceCollection services)
    {
      services.AddVersionedApiExplorer(options =>
      {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
      });

      services.AddApiVersioning(options =>
      {
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.DefaultApiVersion = new ApiVersion(1, 0);
      });
    }
  }
}
