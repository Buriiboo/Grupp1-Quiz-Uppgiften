using System;
using System.Collections.Generic;
using System.Linq;

public enum QuestionType
{
    Freetext,
    MultipleChoice,
    Numeric,
    Year 
}
public abstract class Question
{
    public string QuestionText { get; set; }
    public QuestionType QuestionType { get; set; }
    public int Points { get; set; }

    public abstract bool Validate();
}

public class FreetextQuestion : Question
{
    public override bool Validate()
    {
        // Freetext question validation logic
        return true;
    }
}

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

public class QuizApplication
{
    private List<Question> questions;
    private List<Question> askedQuestions;

    public QuizApplication()
    {
        questions = new List<Question>();
        askedQuestions = new List<Question>();
    }

    public void CreateQuestion(string questionText, QuestionType questionType, int points)
    {
        Question question;
        switch (questionType)
        {
            case QuestionType.Freetext:
                question = new FreetextQuestion();
                break;

            case QuestionType.MultipleChoice:
                question = new MultipleChoiceQuestion();
                break;

            case QuestionType.Numeric:
                question = new NumericQuestion();
                break;

            case QuestionType.Year:
                question = new YearQuestion();
                break;

            default:
                throw new ArgumentException("Invalid question type.");
        }

        question.QuestionText = questionText;
        question.QuestionType = questionType;
        question.Points = points;

        questions.Add(question);
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

    public void PlayGame()
    {
        Question randomQuestion = GetRandomQuestion();

        if (randomQuestion != null)
        {
            Console.WriteLine("Question: " + randomQuestion.QuestionText);
            // Display question based on the type and gather user's answer
            // ...

            // Validate the answer
            if (randomQuestion.Validate())
            {
                // Award points for correct answer
                Console.WriteLine("Correct answer! You earned " + randomQuestion.Points + " points.");
            }
            else
            {
                Console.WriteLine("Incorrect answer. No points awarded.");
            }
        }
        else
        {
            Console.WriteLine("No more questions available.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        QuizApplication quizApp = new QuizApplication();

        // Create sample questions
        quizApp.CreateQuestion("What is the capital of France?", QuestionType.Freetext, 10);

        // Additional question types add here

        // Play the game
        quizApp.PlayGame();
    }
}
