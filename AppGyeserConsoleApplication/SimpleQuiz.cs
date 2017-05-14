using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGyeserConsoleApplication
{
    public class SimpleQuiz
    {
        //each level takes 20 questions
        //0 for level number. 1 for level name
        public string levelHtml = "<div class='multiplePages-item-wrapper'><div class='multiplePages-item' data-index='{0}'><div class='multiplePages-header'><div class='multiplePages-caption'>Level pack <span class='multiplePages-item-number'>#1</span></div><a rel='remove' class='multiplePages-remove' href='javascript:void(0)' style='display: block;'>Remove Level pack</a></div><label for='CustomModelForm_levels_{0}_nameLevel'>Name level:<b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label><div class='item' data-field-name='CustomModelForm[levels][{0}][nameLevel]'><input placeholder='Technology' type='text' value='{1}' name='CustomModelForm[levels][{0}][nameLevel]' id='CustomModelForm_levels_{0}_nameLevel'><div class='errorMessage hidden'></div></div><label for='CustomModelForm[levels][{0}][imageLevel]'>Picture for level (optional): <b class='required' style='color: #BE311B; font-size: {0}.9em;'>*</b></label><div class='item'><div class='image-upload-container'> <a class='add-picture'> <span class='set-picture-button attach-uploader-crop' data-required-height='' data-required-width='' id='attach-image-crop-6' href='/widget_edit_crop.php?successJs=window.parent.imageCropped('attach-image-crop-6')&amp;callback=&amp;ratio=1'>Attach image</span> <span class='remove-picture'>remove image</span> <span class='ajaxloader'></span> <img src='' class='upload-preview'> <input value='' class='hidden-full' name='CustomModelForm[levels][{0}][imageLevel]' id='CustomModelForm_levels_{0}_imageLevel' type='hidden'> </a> </div><div class='errorMessage hidden'></div></div><div class='group-title'>List for the level questions: </div><div class='group-separator'></div><div class='multiple-container' data-min-count='1' data-max-count='20' data-initial-count='2' data-multiple-name='CustomModelForm[levels][{0}][questions]'>";

        //0 for level number. 1 for question number. 2 for question. 3 for correct answer. 4 for wrong answer
        public string questionHtml = "<div class='multiple-item' data-index='{1}'> <label for='CustomModelForm_levels_{0}_questions_{1}_questionText'>Question: <b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label> <div class='item'> <textarea placeholder='What does the Internet prefix WWW stand for?' name='CustomModelForm[levels][{0}][questions][{1}][questionText]' id='CustomModelForm_levels_{0}_questions_{1}_questionText'>{2}</textarea> <div class='errorMessage hidden'></div> </div> <label for='CustomModelForm[levels][{0}][questions][{1}][questionImage]'>Picture for Question (optional): <b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label> <div class='item'> <div class='image-upload-container'> <a class='add-picture'> <span class='set-picture-button attach-uploader-crop' data-required-height='' data-required-width='' id='attach-image-crop-7' href='/widget_edit_crop.php?successJs=window.parent.imageCropped('attach-image-crop-7')&amp;callback=&amp;ratio=1'>Attach image</span> <span class='remove-picture'>remove image</span> <span class='ajaxloader'></span> <img src='' class='upload-preview'> <input value='' class='hidden-full' name='CustomModelForm[levels][{0}][questions][{1}][questionImage]' id='CustomModelForm_levels_{0}_questions_{1}_questionImage' type='hidden'> </a> </div> <div class='errorMessage hidden'></div> </div> <div class='item text-label'>Add the correct answer</div> <label for='CustomModelForm_levels_{0}_questions_{1}_correctAnswer'>Correct answer: <b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label> <div class='item' data-field-name='CustomModelForm[levels][{0}][questions][{1}][correctAnswer]'> <input placeholder='Example: World Wide Web' type='text' value='{3}' name='CustomModelForm[levels][{0}][questions][{1}][correctAnswer]' id='CustomModelForm_levels_{0}_questions_{1}_correctAnswer'> <div class='errorMessage hidden'></div> </div> <div class='item text-label'>Add wrong answers, separated by commas. You can add maximum 3 wrong answers.</div> <label for='CustomModelForm_levels_{0}_questions_{1}_incorrectAnswers'>Incorrect answers: <b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label> <div class='item' data-field-name='CustomModelForm[levels][{0}][questions][{1}][incorrectAnswers]'> <input placeholder='Example: Worldwide Weather, Western Washington World, Wide Width Wickets' type='text' value='{4}' name='CustomModelForm[levels][{0}][questions][{1}][incorrectAnswers]' id='CustomModelForm_levels_{0}_questions_{1}_incorrectAnswers'> <div class='errorMessage hidden'></div> </div> <a rel='remove' class='remove-button multiple-remove' href='javascript:void(0)' style='display: none;'><img src='/img/tabs_delete.png'></a> <div class='item-number'>#1</div> </div>";

        //no string format needed here
        public string addNewHtml = "<div class='add-new'><a class='add multiple-add' href='javascript:void(0);'><span>Add more</span></a></div></div></div><div class='add-new-multiplePages'><a class='add multiplePages-add' href='javascript:void(0);'><span>+ New Level pack </span></a></div></div>";


        private void Create(List<Quiz> quizList, string filePath)
        {
            string contents = "";

            int take = 20, skip = 0;
            List<Quiz> paged = quizList.Skip(skip).Take(take).ToList();
            while(paged!= null && paged.Count() > 0)
            {
                int levelNumber = skip / take;
                contents += string.Format(levelHtml, levelNumber, string.Format("Level {0}", levelNumber+1));

                for(int count=0; count< paged.Count(); count++)
                {
                    contents += string.Format(questionHtml, levelNumber, count, paged[count].question, paged[count].answer, paged[count].wrongAnswers);
                }

                contents += addNewHtml;

                skip += take;
                paged = quizList.Skip(skip).Take(take).ToList();
            }

            System.IO.File.WriteAllText(filePath, contents);
        }


        public void CreateCountryCapitalQuiz()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            var csv = new CsvReader(File.OpenText(@"C:\code\AppGyeserConsoleApplication\countryNameCapital.csv"));
            List<CountryCapital> CountryCapitals = csv.GetRecords<CountryCapital>().ToList();
            List<Quiz> quizList = new List<Quiz>();
            string[] capitals = CountryCapitals.Select(x => x.capital).ToArray();
            foreach (var countryCapital in CountryCapitals)
            {
                Quiz quiz = new Quiz();
                quiz.question = string.Format("Which is the capital of {0}?", countryCapital.country);
                quiz.answer = countryCapital.capital;
                IEnumerable<string> wrongAnswers = capitals.Where(x => !countryCapital.capital.Equals(x));
                quiz.wrongAnswers = string.Join("," , wrongAnswers.OrderBy(x => random.Next()).Take(3));
                quizList.Add(quiz);
            }
            Create(quizList, @"C:\code\AppGyeserConsoleApplication\countryNameCapitalHtml.txt");
        }


        public void CreateCountryCurrencyQuiz()
        {
            List<CountryCurrency> countryCurrencyList = JsonConvert.DeserializeObject<List<CountryCurrency>>(File.ReadAllText(@"C:\code\AppGyeserConsoleApplication\countryNameCurrency.json"));
            Random random = new Random(DateTime.Now.Millisecond);
            List<Quiz> quizList = new List<Quiz>();
            string[] currencies = countryCurrencyList.Select(x => x.Currency).Distinct().ToArray();
            foreach (var countryCurrency in countryCurrencyList)
            {
                Quiz quiz = new Quiz();
                quiz.question = string.Format("What is the currency of {0}?", countryCurrency.Country);
                quiz.answer = countryCurrency.Currency;
                IEnumerable<string> wrongAnswers = currencies.Where(x => !countryCurrency.Currency.Equals(x));
                quiz.wrongAnswers = string.Join(",", wrongAnswers.OrderBy(x => random.Next()).Take(3));
                quizList.Add(quiz);
            }
            Create(quizList, @"C:\code\AppGyeserConsoleApplication\countryCurrencyHtml.txt");
        }

        public void StateCapitalQuiz()
        {
            List<StateCapital> countryCurrencyList = JsonConvert.DeserializeObject<List<StateCapital>>(File.ReadAllText(@"C:\code\AppGyeserConsoleApplication\stateCapital.json"));
            Random random = new Random(DateTime.Now.Millisecond);
            List<Quiz> quizList = new List<Quiz>();

            List<string> currencies = countryCurrencyList.Select(x => x.Capital).Distinct().ToList();
            currencies.Remove("Dehradun (interim)  Nainital (Judiciary)");
            currencies.Remove("Srinagar (summer) Jammu (winter)");

            foreach (var countryCurrency in countryCurrencyList)
            {
                Quiz quiz = new Quiz();
                quiz.question = string.Format("Which is the capital of {0}?", countryCurrency.Name);
                quiz.answer = countryCurrency.Capital;
                IEnumerable<string> wrongAnswers = currencies.Where(x => !countryCurrency.Capital.Equals(x));
                quiz.wrongAnswers = string.Join(",", wrongAnswers.OrderBy(x => random.Next()).Take(3));
                quizList.Add(quiz);
            }
            Create(quizList, @"C:\code\AppGyeserConsoleApplication\stateCapitalHtml.txt");
        }



    }


  

    class Quiz
    {
        public string question { get; set; }
        public string answer { get; set; }
        public string wrongAnswers { get; set; }
    }

    class CountryCapital
    {
        public string country { get; set; }
        public string capital { get; set; }
        public string type { get; set; }
    }

    class CountryCurrency
    {
        public string Country { get; set; }
        public string Currency { get; set; }
    }

    class StateCapital
    {
        public string Name { get; set; }
        public string Capital { get; set; }
    }
}
