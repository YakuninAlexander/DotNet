using create_test.Services.Models;

namespace create_test.Services.Abstract;

public interface IQuestionService
{
    QuestionModel CreateQuestion(CreateQuestionModel question);
    QuestionModel GetQuestion(Guid id);

    QuestionModel UpdateQuestion(Guid id, UpdateQuestionModel question);

    void DeleteQuestion(Guid id);

    PageModel<QuestionModel> GetQuestions(int limit = 20, int offset = 0);
}
