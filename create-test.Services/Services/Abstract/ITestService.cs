using create_test.Services.Models;

namespace create_test.Services.Abstract;

public interface ITestService
{
    TestModel GetTest(Guid id);

    TestModel UpdateTest(Guid id, UpdateTestModel test);

    void DeleteTest(Guid id);

    PageModel<TestModel> GetTests(int limit = 20, int offset = 0);
}