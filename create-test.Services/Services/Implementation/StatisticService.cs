using AutoMapper;
using create_test.Entities.Models;
using create_test.Repository;
using create_test.Services.Abstract;
using create_test.Services.Models;

namespace create_test.Services.Implementation;

public class StatisticService : IStatisticService
{

    private readonly IRepository<Statistic> statisticsRepository;
    private readonly IRepository<User> usersRepository;
    private readonly IRepository<Test> testsRepository;
    private readonly IMapper mapper;
    public StatisticService(IRepository<Statistic> statisticsRepository, IRepository<Test> testsRepository, IRepository<User> usersRepository, IMapper mapper)
    {
        this.testsRepository = testsRepository;
        this.usersRepository = usersRepository;
        this.statisticsRepository = statisticsRepository;
        this.mapper = mapper;
    }

    public void DeleteStatistic(Guid id)
    {
        var statisticToDelete = statisticsRepository.GetById(id);
        if (statisticToDelete == null)
        {
            throw new Exception("Statistic not found"); 
        }

        statisticsRepository.Delete(statisticToDelete);
    }

    public StatisticModel GetStatistic(Guid id)
    {
        var statistic = statisticsRepository.GetById(id);
         if (statistic == null)
        {
            throw new Exception("Statistic not found"); 
        }
        return mapper.Map<StatisticModel>(statistic);
    }

    public PageModel<StatisticModel> GetStatistics(int limit = 20, int offset = 0)
    {
        var statistics = statisticsRepository.GetAll();
        int totalCount = statistics.Count();
        var chunk = statistics.OrderBy(x => x.AttemptTime).Skip(offset).Take(limit);

        return new PageModel<StatisticModel>()
        {
            Items = mapper.Map<IEnumerable<StatisticModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public StatisticModel CreateStatistic(CreateStatisticModel statistic)
    {
        if (testsRepository.GetById(statistic.TestId) == null)
        {
            throw new Exception("Test not existing!");
        }
        if (usersRepository.GetById(statistic.TestId) == null) 
        {
            throw new Exception("User not existing");
        }
        
        var savedStatistic = mapper.Map<Statistic>(statistic);
        statisticsRepository.Save(savedStatistic);
        
        return mapper.Map<StatisticModel>(savedStatistic);
    }

    public StatisticModel UpdateStatistic(Guid id, UpdateStatisticModel statistic)
    {
        var existingStatistic = statisticsRepository.GetById(id);
        if (existingStatistic == null)
        {
            throw new Exception("Statistic not found");
        }

        existingStatistic.CorrectAnswers = statistic.CorrectAnswers;

        existingStatistic = statisticsRepository.Save(existingStatistic);
        return mapper.Map<StatisticModel>(existingStatistic);
    }
}