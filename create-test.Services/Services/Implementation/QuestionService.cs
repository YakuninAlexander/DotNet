using AutoMapper;
using create_test.Entities.Models;
using create_test.Repository;
using create_test.Services.Abstract;
using create_test.Services.Models;

namespace create_test.Services.Implementation;

public class QuestionService : IQuestionService
{
    private readonly IRepository<Questions> questionsRepository;
    private readonly IMapper mapper;
    public QuestionService(IRepository<Questions> questionsRepository, IMapper mapper)
    {
        this.questionsRepository = questionsRepository;
        this.mapper = mapper;
    }

    public void DeleteQuestion(Guid id)
    {
        var questionToDelete = questionsRepository.GetById(id);
        if (questionToDelete == null)
        {
            throw new Exception("Question not found"); 
        }

        questionsRepository.Delete(questionToDelete);
    }

    public QuestionModel GetQuestion(Guid id)
    {
        var question = questionsRepository.GetById(id);
         if (question == null)
        {
            throw new Exception("Question not found"); 
        }
        return mapper.Map<QuestionModel>(question);
    }

    public PageModel<QuestionModel> GetQuestions(int limit = 20, int offset = 0)
    {
        var questions = questionsRepository.GetAll();
        int totalCount = questions.Count();
        var chunk = questions.OrderBy(x => x.Question).Skip(offset).Take(limit);

        return new PageModel<QuestionModel>()
        {
            Items = mapper.Map<IEnumerable<QuestionModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public QuestionModel UpdateQuestion(Guid id, UpdateQuestionModel question)
    {
        var existingQuestion = questionsRepository.GetById(id);
        if (existingQuestion == null)
        {
            throw new Exception("Question not found");
        }

        existingQuestion.Question = question.Question;
        existingQuestion.Answers = question.Answers;
        existingQuestion.RightAnswers = question.RightAnswers;

        existingQuestion = questionsRepository.Save(existingQuestion);
        return mapper.Map<QuestionModel>(existingQuestion);
    }
}