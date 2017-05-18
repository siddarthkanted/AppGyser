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

            //HttpPostImage httpPostImage = new HttpPostImage();
            //httpPostImage.PostImage();

            WordSearch wordSearch = new WordSearch();
            wordSearch.HindiMovies();

            //WordChallenge wordchallenge = new WordChallenge();
            //wordchallenge.create();

            //SimpleQuiz simpleQuiz = new SimpleQuiz();
            //simpleQuiz.DatesQuiz();

            Console.WriteLine("Finsh");
        }
    }
}
