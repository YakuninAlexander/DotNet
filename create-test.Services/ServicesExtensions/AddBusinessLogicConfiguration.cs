using create_test.Services.Abstract;
using create_test.Services.Implementation;
using create_test.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;

namespace create_test.Services;

public static partial class ServicesExtensions
{
    public static void AddBusinessLogicConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServicesProfile));

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITestService, TestService>();
        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IStatisticService, StatisticService>();
    }
}