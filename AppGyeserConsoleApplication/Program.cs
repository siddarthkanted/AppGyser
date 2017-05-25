using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGyeserConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");

            Crossword crossword = new Crossword();
            crossword.SpellBeeHtml();

            //GlossaryApp glossaryApp = new GlossaryApp();
            //glossaryApp.GenerateChukle();

            //WordScramble wordScramble = new WordScramble();
            //wordScramble.SpellBeeHtml();

            //HttpPostImage httpPostImage = new HttpPostImage();
            //httpPostImage.PostImage();

            //WordSearch wordSearch = new WordSearch();
            //wordSearch.HindiMovies();

            //WordChallenge wordchallenge = new WordChallenge();
            //wordchallenge.create();

            //SimpleQuiz simpleQuiz = new SimpleQuiz();
            //simpleQuiz.DatesQuiz();

            Console.WriteLine("Finsh");
            Console.ReadKey();
        }
    }
}
