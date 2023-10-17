using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Freetext
{
    public string FreetextQuestion { get; set; }
    public string CorrectAnswer { get; set; }

    public Freetext(string question, string correctAnswer)
    {
        FreetextQuestion = question;
        CorrectAnswer = correctAnswer;
    }
}

public class FreetextQuestion
{
    public List<Freetext> FreetextQuestionList { get; set; }

    public FreetextQuestion()
    {
        FreetextQuestionList = new List<Freetext>();
    }

    public void FreetextQuestionAdd(string question, string correctAnswer)
    {
        JsonLoadFreetextQuestion();
        FreetextQuestionList.Add(new Freetext(question, correctAnswer));
        JsonSaveFreetextQuestion();
    }

    public void JsonSaveFreetextQuestion()
    {
        string jsonFreetextQuestion = JsonSerializer.Serialize(FreetextQuestionList);
        File.WriteAllText("freetextQuestion.json", jsonFreetextQuestion);
    }

    public void JsonLoadFreetextQuestion()
    {
        string jsonFreetextQuestion = File.ReadAllText("freetextQuestion.json");
        FreetextQuestionList = JsonSerializer.Deserialize<List<Freetext>>(jsonFreetextQuestion);
    }

    public List<Freetext> ShowFreetextQuestion()
    {
        JsonLoadFreetextQuestion();
        for (int i = 0; i < FreetextQuestionList.Count; i++)
        {
            Console.WriteLine($"Fråga {FreetextQuestionList[i].FreetextQuestion}\nSvar: {FreetextQuestionList[i].CorrectAnswer}");
            Console.WriteLine("\n");
        }
        Console.ReadLine();
        return FreetextQuestionList;
    }
}

public class QuizApplication
{
    private List<Freetext> questions;
    private List<Freetext> askedQuestions;

    public QuizApplication()
    {
        questions = new List<Freetext>();
        askedQuestions = new List<Freetext>();
    }

    public Freetext GetRandomQuestion()
    {
        if (questions.Count == 0)
            return null;

        Random random = new Random();
        int index = random.Next(questions.Count);
        Freetext randomQuestion = questions[index];

        // Remove the question from the available questions
        questions.RemoveAt(index);

        // Add the question to the asked questions
        askedQuestions.Add(randomQuestion);

        return randomQuestion;
    }
}
