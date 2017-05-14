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

            //WordChallenge wordchallenge = new WordChallenge();
            //wordchallenge.create();

            SimpleQuiz simpleQuiz = new SimpleQuiz();
            simpleQuiz.StateCapitalQuiz();

            Console.WriteLine("Finsh");
        }
    }
}
