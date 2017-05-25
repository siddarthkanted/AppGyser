using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGyeserConsoleApplication
{
    public class WordSearch
    {

        private string categoryHtml = "<div class='multiplePages-item-wrapper'> <div class='multiplePages-item' data-index='{0}'> <div class='multiplePages-header'> <div class='multiplePages-caption'>category <span class='multiplePages-item-number'>#1</span></div> <a rel='remove' class='multiplePages-remove' href='javascript:void(0)' style='display: none;'>Remove category</a> </div> <div class='item text-label'>Enter category name, for example 'Animals' or 'Food'. Add 10-20 words for each category.</div> <label for='CustomModelForm_categories_{0}_categoryName'>Category name:<b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label> <div class='item' data-field-name='CustomModelForm[categories][{0}][categoryName]'> <input type='text' value='{1}' name='CustomModelForm[categories][{0}][categoryName]' id='CustomModelForm_categories_{0}_categoryName'> <div class='errorMessage hidden'></div> </div> <div class='group-title'>List of words: </div> <div class='group-separator'></div> <div class='multiple-container' data-min-count='1' data-max-count='50' data-initial-count='2' data-multiple-name='CustomModelForm[categories][{0}][categoryWords]'>";
        private string wordHtml = "<div class='multiple-item' data-index='{1}'> <div class='item text-label'>Add new word for searching in this category:</div> <label for='CustomModelForm_categories_{0}_categoryWords_{1}_word'>Enter word:<b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label> <div class='item' data-field-name='CustomModelForm[categories][{0}][categoryWords][{1}][word]'> <input type='text' value='{2}' name='CustomModelForm[categories][{0}][categoryWords][{1}][word]' id='CustomModelForm_categories_{0}_categoryWords_{1}_word'> <div class='errorMessage hidden'></div> </div> <div class='item text-label'>Please use only One word per field. <b>No spaces.</b> </div> <a rel='remove' class='remove-button multiple-remove' href='javascript:void(0)' style='display: none;'><img src='/img/tabs_delete.png'></a> <div class='item-number'>#1</div> </div>";
        private string footerHtml = "<div class='add-new'><a class='add multiple-add' href='javascript:void(0);'><span>Add more</span></a></div> </div> </div> <div class='add-new-multiplePages'><a class='add multiplePages-add' href='javascript:void(0);'><span>+ New category </span></a></div> </div>";


        //0 categoryNumber 1 wordcount
        private void GenerateHtml(List<string> words, string path)
        {
            string content = "";

            int take = 20, skip = 0;
            List<string> paged = words.Skip(skip).Take(take).ToList();
            int count = 0;

            while (paged.Count() > 0)
            {
                string level = string.Format("Level {0}", count+1);
                content += string.Format(categoryHtml, count, level);
                
                    for(int i=0; i< paged.Count(); i++)
                {
                    content += string.Format(wordHtml, count, i, paged[i]);
                }
                content += footerHtml;
                count++;
                skip += take;
                paged = words.Skip(skip).Take(take).ToList();
            }

            File.WriteAllText(path, content);

        }

        public void HindiMovies()
        {
            List<string> allLinesText = File.ReadAllLines(@"C:\code\AppGyeserConsoleApplication\tamilMovieNames.txt").ToList();
            allLinesText = allLinesText.Select(x => x.ToUpper()).ToList();
            allLinesText = allLinesText.Where(x => !IsMultipleWords(x)).ToList();
            allLinesText = allLinesText.Distinct().ToList();
            allLinesText = allLinesText.OrderBy(a => Guid.NewGuid()).ToList();
            GenerateHtml(allLinesText, @"C:\code\AppGyeserConsoleApplication\tamilMovieHtml.txt");
        }

        private bool IsMultipleWords(string line)
        {
            string[] tokens = line.Split(new char[] { ' ' });
            return tokens.Count() > 1;
        }
    }
}
