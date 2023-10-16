using System.Collections.Generic;
using System.Linq;

public class Fråga
{
    public FreetextQuestion( get; set; )
    public CorrectAnswer( get; set; )
    public List<FreetextQuestion> freetextQuestionList;
    public FreetextQuestion(string question, string correctAnswer)
    {
        FreetextQuestion = freetextQuestion;
        CorrectAnswer = correctAnswer;
    }
}

public FreetextQuestion
{
    freetextQuestionList = new List<FreetextQuestion>();
}

public void FreetextQuestionAdd(string Question, string CorrectAnswer)
{
    JsonLoadFreetextQuestion();
    freetextQuestionList.Add(new FreetextQuestion(Question, CorrectAnswer));
    JsonSaveFreetextQuestion();

}
    public void JsonSaveFreetextQuestion()
    {
        string JsonFreetextQuestion = JsonSerializer.Serialize(freetextQuestionList);
        File.WriteAllText("freetextQuestion.json", JsonFreetextQuestion);
    }
    public void JsonLoadFreetextQuestion()
    {
        string JsonFreetextQuestion = File.ReadAllText("freetextQuestion.json");
        freetextQuestionList = JsonSerializer.Deserialize<List<FreetextQuestion>>(JsonFreetextQuestion);
    }
    public List<FreetextQuestion> ShowFreetextQuestion()
    {
        JsonLoadFreetextQuestion();
        for(int i = 0; i < freetextQuestionList.Count; i++)
        {
            Console.WriteLine($"Fråga {freetextQuestionList[i].Question}\nSvar: {freetextQuestionList[i].CorrectAnswer}");
            Console.WriteLine("\n");
        }
        Console.ReadLine();   
        return FreetextQuestionList; 
}
/*
public class MultipleChoiceQuestion : Question
{
    public List<string> Choices { get; set; }

    public override bool Validate()
    {
        // Multiple choice question validation logic
        return true;
    }
}

public class NumericQuestion : Question
{
    public int CorrectAnswer { get; set; }

    public override bool Validate()
    {
        // Numeric question validation logic
        return true;
    }
}

public class YearQuestion : Question
{
    public int CorrectYear { get; set; }

    public override bool Validate()
    {
        // Year question validation logic
        return true;
    }
}
*/
public class QuizApplication
{
    private List<Question> questions;
    private List<Question> askedQuestions;

    public QuizApplication()
    {
        questions = new List<Question>();
        askedQuestions = new List<Question>();
    }

    

    public Question GetRandomQuestion()
    {
        if (questions.Count == 0)
            return null;

        Random random = new Random();
        int index = random.Next(questions.Count);
        Question randomQuestion = questions[index];

        // Remove the question from the available questions
        questions.RemoveAt(index);

        // Add the question to the asked questions
        askedQuestions.Add(randomQuestion);

        return randomQuestion;
    }
}