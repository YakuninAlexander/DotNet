using AutoMapper;
using create_tests.WebAPI.Models;
using create_test.Services.Models;

namespace create_tests.WebAPI.MapperProfile;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
        #region  Pages

        CreateMap(typeof(PageModel<>), typeof(PageResponse<>));

        #endregion

        #region Users

        CreateMap<UserModel, UserResponse>().ReverseMap();
        CreateMap<UpdateUserRequest, UpdateUserModel>().ReverseMap();

        #endregion

        
        #region Tests

        CreateMap<TestModel, TestResponse>().ReverseMap();
        CreateMap<UpdateTestRequest, UpdateTestModel>().ReverseMap();

        #endregion

        
        #region Questions

        CreateMap<QuestionModel, QuestionResponse>().ReverseMap();
        CreateMap<UpdateQuestionRequest, UpdateQuestionModel>().ReverseMap();

        #endregion

        
        #region Statistics

        CreateMap<StatisticModel, StatisticResponse>().ReverseMap();;
        CreateMap<UpdateStatisticRequest, UpdateStatisticModel>().ReverseMap();;

        #endregion
    }
}