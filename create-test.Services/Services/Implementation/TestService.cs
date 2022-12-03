using AutoMapper;
using create_test.Entities.Models;
using create_test.Repository;
using create_test.Services.Abstract;
using create_test.Services.Models;

namespace create_test.Services.Implementation;

public class TestService : ITestService
{

    private readonly IRepository<User> usersRepository;
    private readonly IRepository<Test> testsRepository;
    private readonly IMapper mapper;
    public TestService(IRepository<Test> testsRepository, IRepository<User> usersRepository, IMapper mapper)
    {
        this.usersRepository = usersRepository;
        this.testsRepository = testsRepository;
        this.mapper = mapper;
    }

  public TestModel CreateTest(CreateTestModel test)
  {
    if (usersRepository.GetById(test.UserID) == null)
    {
        throw new Exception("User not existing!");
    }
    
    var savedTest = mapper.Map<Test>(test);
    testsRepository.Save(savedTest);
    
    return mapper.Map<TestModel>(savedTest);
  }

  public void DeleteTest(Guid id)
    {
        var testToDelete = testsRepository.GetById(id);
        if (testToDelete == null)
        {
            throw new Exception("Test not found"); 
        }

        testsRepository.Delete(testToDelete);
    }

    public TestModel GetTest(Guid id)
    {
        var test = testsRepository.GetById(id);
         if (test == null)
        {
            throw new Exception("Test not found"); 
        }
        return mapper.Map<TestModel>(test);
    }

    public PageModel<TestModel> GetTests(int limit = 20, int offset = 0)
    {
        var tests = testsRepository.GetAll();
        int totalCount = tests.Count();
        var chunk = tests.OrderBy(x => x.CreateDate).Skip(offset).Take(limit);

        return new PageModel<TestModel>()
        {
            Items = mapper.Map<IEnumerable<TestModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public TestModel UpdateTest(Guid id, UpdateTestModel test)
    {
        var existingTest = testsRepository.GetById(id);
        if (existingTest == null)
        {
            throw new Exception("Test not found");
        }

        existingTest.Name = test.Name;
        existingTest.IsPrivate = test.IsPrivate;

        existingTest = testsRepository.Save(existingTest);
        return mapper.Map<TestModel>(existingTest);
    }
}