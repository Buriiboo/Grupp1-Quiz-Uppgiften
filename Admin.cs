using System;
using Huvudmeny;
using Questions;
using Game;
namespace Admin
{
    public class Admin
    {
    public void ShowAllQuestions()
        {
            FreetextQuestion freetextQuestion = new FreetextQuestion();
            freetextQuestion.ShowFreetextQuestion();

        }
    }
}