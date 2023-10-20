using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Questions
{
    public class Freetext
    {
        public string FreetextQuestion { get; set; }
        public string CorrectAnswer { get; set; }

        public Freetext(string freetextQuestion, string correctAnswer)
        {
            FreetextQuestion = freetextQuestion;
            CorrectAnswer = correctAnswer;
        }
    }


    public class FreetextQuestion
    {
        private List<Freetext> questionList;
        private List<Freetext> askedQuestions;

        public FreetextQuestion()
        {
            questionList = new List<Freetext>();
            askedQuestions = new List<Freetext>();
        }

        public void FreetextQuestionAdd(string question, string correctAnswer)
        {
            JsonLoadFreetextQuestion();
            Freetext newQuestion = new Freetext(question, correctAnswer);
            questionList.Add(newQuestion);
            JsonSaveFreetextQuestion();
        }

        public void JsonSaveFreetextQuestion()
        {
            string jsonFreetextQuestion = JsonSerializer.Serialize(questionList);
            File.WriteAllText("freetextQuestion.json", jsonFreetextQuestion);
        }

   public void JsonLoadFreetextQuestion()
    {
        try
        {
            string jsonFreetextQuestion = File.ReadAllText("freetextQuestion.json");
            questionList = JsonSerializer.Deserialize<List<Freetext>>(jsonFreetextQuestion);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while deserializing JSON:");
            Console.WriteLine(ex.Message);
        }
    }

    public List<Freetext> ShowFreetextQuestion()
{
    JsonLoadFreetextQuestion();

    if (questionList != null && questionList.Count > 0)
    {
        Console.WriteLine("Questions loaded successfully:");
        int questionNumber = 1;

        foreach (var question in questionList)
        {
            Console.WriteLine($"Question {questionNumber}:");
            Console.WriteLine($"Fråga: {question.FreetextQuestion}");
            Console.WriteLine($"Svar: {question.CorrectAnswer}");
            Console.WriteLine();
            questionNumber++;
        }

        return questionList;
    }
    else
    {
        Console.WriteLine("No questions found.");
        Console.ReadLine();
        return new List<Freetext>();
    }
}


    }
}

