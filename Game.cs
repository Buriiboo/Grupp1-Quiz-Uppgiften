using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Questions;

namespace Game
{
    public class QuizApplication
    {
        private List<Freetext> questions;
        private List<Freetext> askedQuestions;

        public QuizApplication()
        {
            questions = LoadQuestionsFromJson();
            askedQuestions = new List<Freetext>();
        }

        private List<Freetext> LoadQuestionsFromJson()
        {
            // Load the questions and answers from the provided JSON
            string jsonFilePath = "freetextQuestions.json"; 
            string jsonString = File.ReadAllText(jsonFilePath);
            Dictionary<string, string> questionAnswerPairs = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);

            // Convert the question-answer pairs to Freetext instances
            List<Freetext> freetextQuestions = new List<Freetext>();
            foreach (var kvp in questionAnswerPairs)
            {
                Freetext question = new Freetext(kvp.Key, kvp.Value);
                freetextQuestions.Add(question);
            }

            return freetextQuestions;
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
}
