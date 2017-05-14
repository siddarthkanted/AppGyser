using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGyeserConsoleApplication
{
    public class WordChallenge
    {

        public string easyHtmlTag = "<div class='multiple-item' data-index='{0}'><div class='item text-label'>Maximum and minimum length of a word in this level is 3 letters<br></div><label for='CustomModelForm_easyWords_{0}_word'>Enter word:<b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label><div class='item' data-field-name='CustomModelForm[easyWords][{0}][word]'><input placeholder='Example: car' type='text' value='{1}' name='CustomModelForm[easyWords][{0}][word]' id='CustomModelForm_easyWords_{0}_word'><div class='errorMessage hidden'>This field is required</div></div><a rel='remove' class='remove-button multiple-remove' href='javascript:void(0)' style='display: none;'><img src='/img/tabs_delete.png'></a><div class='item-number'>#1</div></div>";
        public string easyData = "Una Wai Pen Lar Mul Ron Rau";

        public string mediumHtmlTag = "<div class='multiple-item' data-index='{0}'><div class='item text-label'>Maximum length of a word is 5 letters and minimum length is 4 letters<br></div><label for='CustomModelForm_mediumWords_{0}_word'>Enter word:<b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label><div class='item' data-field-name='CustomModelForm[mediumWords][{0}][word]'><input placeholder='Example: cars' type='text' value='{1}' name='CustomModelForm[mediumWords][{0}][word]' id='CustomModelForm_mediumWords_{0}_word'><div class='errorMessage hidden'>This field is required</div></div><a rel='remove' class='remove-button multiple-remove' href='javascript:void(0)' style='display: none;'><img src='/img/tabs_delete.png'></a><div class='item-number'>#1</div></div>";
        public string mediumData = "Pune Agra Loni Gaya Durg Pali Orai Rewa Jind Tonk Vapi Puri Moga Bhuj Akot Tura Kadi Suri Wani Rath Tuni Ozar Sira Vita Arvi Taki Wadi Mahe Zira Vapi Uran Soro Piro Pali Loha Adra Obra Barh";

        public string hardHtmlTag = "<div class='multiple-item' data-index='{0}'><div class='item text-label'>Maximum length of a word is 6 letters and minimum length is 5 letters<br></div><label for='CustomModelForm_hardWords_{0}_word'>Enter word:<b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label><div class='item' data-field-name='CustomModelForm[hardWords][{0}][word]'><input placeholder='Example: animal' type='text' value='{1}' name='CustomModelForm[hardWords][{0}][word]' id='CustomModelForm_hardWords_{0}_word'></div><a rel='remove' class='remove-button multiple-remove' href='javascript:void(0)' style='display: none;'><img src='/img/tabs_delete.png'></a><div class='item-number'>#1</div></div>";
        public string hardData = "Delhi Surat Patna Thane Salem Noida Kochi Ajmer Jammu Akola Latur Dhule Korba Alwar Sagar Hisar Hapur Arrah Satna Eluru Anand Morvi Sikar Unnao Adoni Sirsa Erode Habra Kolar Udupi Patan Deesa Siwan Udgir Buxar Khair Nagda Tanda Sarni Seoni Parli Jamui Anjar Hansi Gokak Mansa Karur Nabha Pusad Ladnu Sirsi Nokha Diphu Gudur Mandi Unjha Sunam Tirur Yanam Dhuri Umred Panna Arwal Kalpi Nohar Yevla Gooty Salur Gumia Dumka Sihor Athni Sidhi Medak Punch Sailu Vyara Padra Siana Sojat Manvi Lanka Yawal Lahar Wokha Patti Solan Purna Porsa Sedam Maner Mundi Pasan Rasra Adoor Nahan Ladwa Losal Mansa Malur Sohna Risod Nokha Soron Raver Rehli Nagar Polur Tehri Pardi Pauri Sadri Mahad Ratia Rajam Lonar Sandi Malda Rapar Nakur Palai Pauni Nagla Reoti Sirsi Purwa Lathi Rania Patur Sakti Silao Saiha Niwai Adyar Warud";

        private void createHtml(string data, string htmlTag, string filePath)
        {
            string contents = "";

            string[] array = data.Split(new char[] { ' ' });
            for (int count = 0; count < array.Count(); count++)
            {
                string content = String.Format(htmlTag, count, array[count]);
                contents += content;
            }


            System.IO.File.WriteAllText(filePath, contents);
        }

        public void create()
        {
            createHtml(easyData, easyHtmlTag, @"C:\code\AppGyeserConsoleApplication\easyTextHtml.txt");
            createHtml(mediumData, mediumHtmlTag, @"C:\code\AppGyeserConsoleApplication\mediumTextHtml.txt");
            createHtml(hardData, hardHtmlTag, @"C:\code\AppGyeserConsoleApplication\hardTextHtml.txt");
        }


    }
}
