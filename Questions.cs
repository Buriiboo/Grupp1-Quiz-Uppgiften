using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Fråga
{
    public string FreetextQuestion { get; set; }
    public string CorrectAnswer { get; set; }

    public Fråga(string question, string correctAnswer)
    {
        FreetextQuestion = question;
        CorrectAnswer = correctAnswer;
    }
}

public class FreetextQuestion
{
    public List<Fråga> FreetextQuestionList { get; set; }

    public FreetextQuestion()
    {
        FreetextQuestionList = new List<Fråga>();
    }

    public void FreetextQuestionAdd(string question, string correctAnswer)
    {
        JsonLoadFreetextQuestion();
        FreetextQuestionList.Add(new Fråga(question, correctAnswer));
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
        FreetextQuestionList = JsonSerializer.Deserialize<List<Fråga>>(jsonFreetextQuestion);
    }

    public List<Fråga> ShowFreetextQuestion()
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
    private List<Fråga> questions;
    private List<Fråga> askedQuestions;

    public QuizApplication()
    {
        questions = new List<Fråga>();
        askedQuestions = new List<Fråga>();
    }

    public Fråga GetRandomQuestion()
    {
        if (questions.Count == 0)
            return null;

        Random random = new Random();
        int index = random.Next(questions.Count);
        Fråga randomQuestion = questions[index];

        // Remove the question from the available questions
        questions.RemoveAt(index);

        // Add the question to the asked questions
        askedQuestions.Add(randomQuestion);

        return randomQuestion;
    }
}
