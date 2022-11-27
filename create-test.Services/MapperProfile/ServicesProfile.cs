using AutoMapper;
using create_test.Entities.Models;
using create_test.Services.Models;

namespace create_test.Services.MapperProfile;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        #region Users

        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<User, UpdateUserModel>().ReverseMap();

        #endregion

        #region Tests

        CreateMap<Test, TestModel>().ReverseMap();
        CreateMap<Test, UpdateTestModel>().ReverseMap();

        #endregion

        #region Statistic

        CreateMap<Statistic, StatisticModel>().ReverseMap();
        CreateMap<Statistic, UpdateStatisticModel>().ReverseMap();

        #endregion

        #region Questions

        CreateMap<Questions, QuestionModel>().ReverseMap();
        CreateMap<Questions, UpdateQuestionModel>().ReverseMap();

        #endregion
    }
}