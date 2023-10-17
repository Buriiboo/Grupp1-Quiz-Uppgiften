using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Questions
{
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
            string jsonFreetextQuestion = File.ReadAllText("freetextQuestion.json");
            questionList = JsonSerializer.Deserialize<List<Freetext>>(jsonFreetextQuestion);
        }

        public List<Freetext> ShowFreetextQuestion()
        {
            JsonLoadFreetextQuestion();
            for (int i = 0; i < questionList.Count; i++)
            {
                Console.WriteLine($"Fråga {questionList[i].FreetextQuestion}\nSvar: {questionList[i].CorrectAnswer}");
                Console.WriteLine("\n");
            }
            Console.ReadLine();
            return questionList;
        }
    }
}
