using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGyeserConsoleApplication
{
    public class Crossword
    {
        string cateogryHtml = "<div class='multiplePages-item' data-index='{0}'> <div class='multiplePages-header'> <div class='multiplePages-caption'>Crossword <span class='multiplePages-item-number'>#1</span></div> <a rel='remove' class='multiplePages-remove' href='javascript:void(0)' style='display: block;'>Remove Crossword</a> </div> <label for='CustomModelForm_crosswords_{0}_name'>Crossword name:<b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label> <div class='item' data-field-name='CustomModelForm[crosswords][{0}][name]'> <input type='text' value='{1}' name='CustomModelForm[crosswords][{0}][name]' id='CustomModelForm_crosswords_{0}_name'> <div class='errorMessage hidden'></div> </div> <div class='group-title'>List for the crossword clue: </div> <div class='group-separator'></div> <div class='multiple-container' data-min-count='3' data-max-count='50' data-initial-count='3' data-multiple-name='CustomModelForm[crosswords][{0}][questions]'>";
        string questionHtml = "<div class='multiple-item' data-index='{1}'> <label for='CustomModelForm_crosswords_{0}_questions_{1}_clue'>Clue: <b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label> <div class='item' data-field-name='CustomModelForm[crosswords][{0}][questions][{1}][clue]'> <input type='text' value='{2}' name='CustomModelForm[crosswords][{0}][questions][{1}][clue]' id='CustomModelForm_crosswords_{0}_questions_{1}_clue'> <div class='errorMessage hidden'></div> </div> <label for='CustomModelForm_crosswords_{0}_questions_{1}_word'>Answer: <b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label> <div class='item' data-field-name='CustomModelForm[crosswords][{0}][questions][{1}][word]'> <input type='text' value='{3}' name='CustomModelForm[crosswords][{0}][questions][{1}][word]' id='CustomModelForm_crosswords_{0}_questions_{1}_word'> <div class='errorMessage hidden'></div> </div> <a rel='remove' class='remove-button multiple-remove' href='javascript:void(0)' style='display: none;'><img src='/img/tabs_delete.png'></a> <div class='item-number'>#1</div> </div>";
        string addNewHtml = "<div class='add-new'><a class='add multiple-add' href='javascript:void(0);'><span>Add more</span></a></div> </div> </div>";

        private void Generate(List<CrosswordData> questionList, string filePath)
        {
            string contents = "";

            int take = 15, skip = 0;
            List<CrosswordData> paged = questionList.Skip(skip).Take(take).ToList();
            while (paged != null && paged.Count() > 0)
            {
                int levelNumber = skip / take;
                contents += string.Format(cateogryHtml, levelNumber, string.Format("Level {0}", levelNumber + 1));

                for (int count = 0; count < paged.Count(); count++)
                {
                    contents += string.Format(questionHtml, levelNumber, count, paged[count].Clue, paged[count].Answer);
                }

                contents += addNewHtml;

                skip += take;
                paged = questionList.Skip(skip).Take(take).ToList();

                if (levelNumber == 15)
                    break;
            }


            contents += addNewHtml;

            File.WriteAllText(filePath, contents);
        }

        public void SpellBeeHtml()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            var csv = new CsvReader(File.OpenText(@"C:\code\AppGyeserConsoleApplication\spellingBeeEasy.txt"));
            List<SpellBee> spellBeeList = csv.GetRecords<SpellBee>().ToList();
            spellBeeList = spellBeeList.OrderBy(x => random.Next()).ToList();
            List<CrosswordData> questionList = spellBeeList.Select(x => new CrosswordData(x.Meaning, x.Word)).ToList();
            questionList = questionList.OrderBy(a => Guid.NewGuid()).ToList();
            Generate(questionList, @"C:\code\AppGyeserConsoleApplication\spellBeeEasyHtml.txt");
        }
    }

    class CrosswordData
    {
        public string Clue { get; set; }
        public string Answer { get; set; }

        public CrosswordData(string Clue, string Answer)
        {
            this.Clue = Clue;
            this.Answer = Answer;
        }
    }



}
