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

}