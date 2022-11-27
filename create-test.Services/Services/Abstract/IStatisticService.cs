using create_test.Services.Models;

namespace create_test.Services.Abstract;

public interface IStatisticService
{
    StatisticModel GetStatistic(Guid id);

    StatisticModel UpdateStatistic(Guid id, UpdateStatisticModel statistic);

    void DeleteStatistic(Guid id);

    PageModel<StatisticModel> GetStatistics(int limit = 20, int offset = 0);
}
