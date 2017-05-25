using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGyeserConsoleApplication
{
    public class WordScramble
    {
        private string html = "<div class='multiple-item' data-index='{0}'> <div class='item text-label'>Come up with the name of the category. Example: history, space and etc</div> <label for='CustomModelForm_categoryQuestion_{0}_nameCategory'>Name of category: </label> <div class='item' data-field-name='CustomModelForm[categoryQuestion][{0}][nameCategory]'> <input type='text' value='{1}' name='CustomModelForm[categoryQuestion][{0}][nameCategory]' id='CustomModelForm_categoryQuestion_{0}_nameCategory'> <div class='errorMessage hidden'></div> </div> <div class='item text-label'>Enter your clue regarding your category.</div> <label for='CustomModelForm_categoryQuestion_{0}_description'>Clue: </label> <div class='item' data-field-name='CustomModelForm[categoryQuestion][{0}][description]'> <input type='text' value='{2}' name='CustomModelForm[categoryQuestion][{0}][description]' id='CustomModelForm_categoryQuestion_{0}_description'> <div class='errorMessage hidden'>This field is required</div> </div> <div class='item text-label'><br>IMPORTANT! Enter a word <b>without spaces.</b></div> <label for='CustomModelForm_categoryQuestion_{0}_answer'>Answer: <b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label> <div class='item' data-field-name='CustomModelForm[categoryQuestion][{0}][answer]'> <input type='text' value='{3}' name='CustomModelForm[categoryQuestion][{0}][answer]' id='CustomModelForm_categoryQuestion_{0}_answer'> <div class='errorMessage hidden'></div> </div> <a rel='remove' class='remove-button multiple-remove' href='javascript:void(0)' style='display: inline;'><img src='/img/tabs_delete.png'></a> <div class='item-number'>#1</div> </div>";

        private void Generate(List<Question> questionList ,  string filePath)
        {
            string content = "";
            for(int count=0; count< questionList.Count; count++)
            {
                content += String.Format(html, count, questionList[count].Category, questionList[count].Clue, questionList[count].Answer);
            }
            File.WriteAllText(filePath, content);
        }

        public void NumberList()
        {
            string clue = "Starts with {0} and ends with {1}";
            var csv = new CsvReader(File.OpenText(@"C:\code\AppGyeserConsoleApplication\result.csv"));
            List<NumberData> CountryCapitals = csv.GetRecords<NumberData>().ToList();
            List<Question> questionList = CountryCapitals.Select(x => new Question(x.Category, String.Format(clue, char.ToUpper(x.Word[0]), char.ToUpper(x.Word[x.Word.Length - 1])), x.Word)).ToList();
            Generate(questionList, @"C:\code\AppGyeserConsoleApplication\numbersWordScrambleHtml.csv");
        }

        public void SpellBeeHtml()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            var csv = new CsvReader(File.OpenText(@"C:\code\AppGyeserConsoleApplication\spellBeeADVANCEDtxt.txt"));
            List<SpellBee> spellBeeList = csv.GetRecords<SpellBee>().ToList();
            spellBeeList = spellBeeList.OrderBy(x => random.Next()).ToList();
            List<Question> questionList = spellBeeList.Select((x,i) => new Question(string.Format("Level {0}", i/20+1), x.Meaning, x.Word)).ToList();
            Generate(questionList, @"C:\code\AppGyeserConsoleApplication\spellBeeADVANCEDHtml.txt");
        }
    }

    class Question
    {
        public string Category { get; set; }
        public string Clue { get; set; }
        public string Answer { get; set; }

        public Question(string Category, string Clue, string Answer)
        {
            this.Category = Category;
            this.Clue = Clue;
            this.Answer = Answer;
        }
    }

    //"word","meaning"
    class SpellBee{
          public string Meaning { get; set; }
    public string Word { get; set; }
}

    //{"Cateogry":"Month Names","Word":"January"}
    class NumberData
    {
        public string Category { get; set; }
        public string Word { get; set; }
    }
}
