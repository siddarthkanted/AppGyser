using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGyeserConsoleApplication
{
    //http://www.appsgeyser.com/create-triviaGame-app/
    //0 question number. 1 cateogry name. 2 question. 3 firstAnswer. 4 second. 5 third. 6 fourth
    //7 radio one 8 radio two 9 radio three 10 radio 4
    //put checked="checked" for right radio button and remaining 3 radio button empty
    public class QuizWithCategory
    {
        private string html = "<div class='multiple-item' data-index='{0}'><div class='item text-label'>Come up with the name of the category. Example: history, space and etc</div><label for='CustomModelForm_categoryQuestion_{0}_nameCategory'>Name of categQory: </label><div class='item' data-field-name='CustomModelForm[categoryQuestion][{0}][nameCategory]'><input type='text' value='{1}' name='CustomModelForm[categoryQuestion][{0}][nameCategory]' id='CustomModelForm_categoryQuestion_{0}_nameCategory'><div class='errorMessage hidden'></div></div><div class='item text-label'>Enter your clue regarding your category.</div><label for='CustomModelForm_categoryQuestion_{0}_question'>Question: </label><div class='item' data-field-name='CustomModelForm[categoryQuestion][{0}][question]'> <input type='text' value='{2}' name='CustomModelForm[categoryQuestion][{0}][question]' id='CustomModelForm_categoryQuestion_{0}_question'><div class='errorMessage hidden'></div></div><div class='item text-label'><br> Enter answers and select the correct one</div><label for='CustomModelForm_categoryQuestion_{0}_firstAnswer'>First answer: <b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label><div class='item' data-field-name='CustomModelForm[categoryQuestion][{0}][firstAnswer]'> <input type='text' value='{3}' name='CustomModelForm[categoryQuestion][{0}][firstAnswer]' id='CustomModelForm_categoryQuestion_{0}_firstAnswer'><div class='errorMessage hidden'></div></div><label for='CustomModelForm_categoryQuestion_{0}_secondAnswer'>Second answer: <b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label><div class='item' data-field-name='CustomModelForm[categoryQuestion][{0}][secondAnswer]'> <input type='text' value='{4}' name='CustomModelForm[categoryQuestion][{0}][secondAnswer]' id='CustomModelForm_categoryQuestion_{0}_secondAnswer'><div class='errorMessage hidden'></div></div><label for='CustomModelForm_categoryQuestion_{0}_thirdAnswer'>Third answer: <b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label><div class='item' data-field-name='CustomModelForm[categoryQuestion][{0}][thirdAnswer]'> <input type='text' value='{5}' name='CustomModelForm[categoryQuestion][{0}][thirdAnswer]' id='CustomModelForm_categoryQuestion_{0}_thirdAnswer'><div class='errorMessage hidden'></div></div><label for='CustomModelForm_categoryQuestion_{0}_fourthAnswer'>Fourth answer: <b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label><div class='item' data-field-name='CustomModelForm[categoryQuestion][{0}][fourthAnswer]'> <input type='text' value='{6}' name='CustomModelForm[categoryQuestion][{0}][fourthAnswer]' id='CustomModelForm_categoryQuestion_{0}_fourthAnswer'><div class='errorMessage hidden'></div></div><label for='CustomModelForm[categoryQuestion][{0}][correctAnswer]'>Select correct answer:</label><div class='item radio-group' data-default-value='wordpress'><span id='CustomModelForm_categoryQuestion_{0}_correctAnswer'> <input data-default-value='wordpress' value='1' id='CustomModelForm_categoryQuestion_{0}_correctAnswer_0' type='radio' name='CustomModelForm[categoryQuestion][{0}][correctAnswer]' {7}> <label for='CustomModelForm_categoryQuestion_{0}_correctAnswer_0'>First</label><br> <input data-default-value='wordpress' value='2' id='CustomModelForm_categoryQuestion_{0}_correctAnswer_1' type='radio' name='CustomModelForm[categoryQuestion][{0}][correctAnswer]' {8}> <label for='CustomModelForm_categoryQuestion_{0}_correctAnswer_1'>Second</label><br> <input data-default-value='wordpress' value='3' id='CustomModelForm_categoryQuestion_{0}_correctAnswer_2' type='radio' name='CustomModelForm[categoryQuestion][{0}][correctAnswer]' {9}> <label for='CustomModelForm_categoryQuestion_{0}_correctAnswer_2'>Third</label><br> <input data-default-value='wordpress' value='4' id='CustomModelForm_categoryQuestion_{0}_correctAnswer_3' type='radio' name='CustomModelForm[categoryQuestion][{0}][correctAnswer]' {10}> <label for='CustomModelForm_categoryQuestion_{0}_correctAnswer_3'>Fourth</label></span><div class='errorMessage hidden'></div></div><a rel='remove' class='remove-button multiple-remove' href='javascript:void(0)' style='display: inline;'><img src='/img/tabs_delete.png'></a><div class='item-number'>#{0}</div></div>";
       
        private string generateHtml(QuizCategory QuizCategory, int questionNumber)
        {
            string[] answers = new string[4];
            string[] checkedRadio = new string[4];

            Random random = new Random();
            int randomNumber = random.Next(0, 4);

            int count = 0;
            for(int i=0; i<4; i++)
            {
                if(i== randomNumber)
                {
                    answers[i] = QuizCategory.CorrectAnswer;
                    checkedRadio[i] = "checked='checked'";
                }
                else
                {
                    answers[i] = QuizCategory.CorrectAnswer;
                    checkedRadio[i] = QuizCategory.WrongAnswers[count++];
                }
            }

            return String.Format(html, questionNumber, QuizCategory.Category, QuizCategory.Question, answers, checkedRadio);
        }






    }

    class QuizCategory
    {
        public string Category { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string[] WrongAnswers { get; set; }
    }
}
