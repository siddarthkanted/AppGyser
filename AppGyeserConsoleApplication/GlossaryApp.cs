using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AppGyeserConsoleApplication
{
    public class GlossaryApp
    {

        private string[] jokesImages = { "/img/tmp/crop59254b1905f28.png", "/img/tmp/crop59254b2b2f554.png", "/img/tmp/crop59254b3b069a9.png", "/img/tmp/crop59254b4daf2c9.png", "/img/tmp/crop59254b5b318b0.jpg" };
        private string html = "<div class='multiple-item' data-index='{0}'> <label for='CustomModelForm_items_{0}_itemName'>Enter The Word:<b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label> <div class='item' data-field-name='CustomModelForm[items][{0}][itemName]'> <input type='text' value='{1}' name='CustomModelForm[items][{0}][itemName]' id='CustomModelForm_items_{0}_itemName'> <div class='errorMessage hidden'></div> </div> <label for='CustomModelForm[items][{0}][itemIcon]'>Upload preview image (50x50)<b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label> <div class='item'> <div class='image-upload-container'> <a class='add-picture '> <span class='set-picture-button attach-uploader-crop' data-required-height='50' data-required-width='50' id='CustomModelForm-items--{0}--itemIcon-' href='/widget_edit_crop.php?successJs=window.parent.imageCropped('CustomModelForm-items--{0}--itemIcon-')&amp;callback=&amp;ratio=1.0000'>Attach image</span> <span class='remove-picture'>remove image</span> <span class='ajaxloader'></span> <img src='{2}' class='upload-preview'> <input value='{2}' class='hidden-full' name='CustomModelForm[items][{0}][itemIcon]' id='CustomModelForm_items_{0}_itemIcon' type='hidden'> </a> </div> <div class='errorMessage hidden'></div> </div> <label for='CustomModelForm_items_{0}_translation'>Enter translation or short description:<b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label> <div class='item' data-field-name='CustomModelForm[items][{0}][translation]'> <input type='text' value='{3}' name='CustomModelForm[items][{0}][translation]' id='CustomModelForm_items_{0}_translation'> <div class='errorMessage hidden'></div> </div> <div class='item text-label'>Insert the full description of definition, add the examples to use. Describe in detail the definition. Use the pictures, bold and italic text, list and titles. This will make it easier to understand the meaning. </div> <label for='CustomModelForm_items_{0}_itemDescription'>Enter definition:<b class='required' style='color: #BE311B; font-size: 0.9em;'>*</b></label> <div class='item textEditorItem'> <textarea hidden='true' field-type='textEditor_hidden' field-attr='textEditor_hidden' class='CustomModelForm[items][{0}][itemDescription][hidden]' name='CustomModelForm[items][{0}][itemDescription][hidden]' id='CustomModelForm_items_{0}_itemDescription_hidden'></textarea> <div id='mceu_15' class='mce-tinymce mce-container mce-panel' hidefocus='1' tabindex='-1' role='application' style='visibility: hidden; border-width: 1px; width: 340px;'> <div id='mceu_15-body' class='mce-container-body mce-stack-layout'> <div id='mceu_16' class='mce-toolbar-grp mce-container mce-panel mce-stack-layout-item mce-first' hidefocus='1' tabindex='-1' role='group'> <div id='mceu_16-body' class='mce-container-body mce-stack-layout'> <div id='mceu_17' class='mce-container mce-toolbar mce-stack-layout-item mce-first' role='toolbar'> <div id='mceu_17-body' class='mce-container-body mce-flow-layout'> <div id='mceu_18' class='mce-container mce-flow-layout-item mce-first mce-btn-group' role='group'> <div id='mceu_18-body'> <div id='mceu_0' class='mce-widget mce-btn mce-first' tabindex='-1' aria-labelledby='mceu_0' role='button' aria-label='Bold'><button role='presentation' type='button' tabindex='-1'><i class='mce-ico mce-i-bold'></i></button></div> <div id='mceu_1' class='mce-widget mce-btn mce-last' tabindex='-1' aria-labelledby='mceu_1' role='button' aria-label='Italic'><button role='presentation' type='button' tabindex='-1'><i class='mce-ico mce-i-italic'></i></button></div> </div> </div> <div id='mceu_19' class='mce-container mce-flow-layout-item mce-btn-group' role='group'> <div id='mceu_19-body'> <div id='mceu_2' class='mce-widget mce-btn mce-first' tabindex='-1' aria-labelledby='mceu_2' role='button' aria-label='Align left'><button role='presentation' type='button' tabindex='-1'><i class='mce-ico mce-i-alignleft'></i></button></div> <div id='mceu_3' class='mce-widget mce-btn' tabindex='-1' aria-labelledby='mceu_3' role='button' aria-label='Align center'><button role='presentation' type='button' tabindex='-1'><i class='mce-ico mce-i-aligncenter'></i></button></div> <div id='mceu_4' class='mce-widget mce-btn mce-last' tabindex='-1' aria-labelledby='mceu_4' role='button' aria-label='Align right'><button role='presentation' type='button' tabindex='-1'><i class='mce-ico mce-i-alignright'></i></button></div> </div> </div> <div id='mceu_20' class='mce-container mce-flow-layout-item mce-last mce-btn-group' role='group'> <div id='mceu_20-body'> <div id='mceu_5' class='mce-widget mce-btn mce-first' tabindex='-1' aria-labelledby='mceu_5' role='button' aria-label='Bullet list'><button role='presentation' type='button' tabindex='-1'><i class='mce-ico mce-i-bullist'></i></button></div> <div id='mceu_6' class='mce-widget mce-btn' tabindex='-1' aria-labelledby='mceu_6' role='button' aria-label='Numbered list'><button role='presentation' type='button' tabindex='-1'><i class='mce-ico mce-i-numlist'></i></button></div> <div id='mceu_7' class='mce-widget mce-btn' tabindex='-1' aria-labelledby='mceu_7' role='button' aria-label='Decrease indent'><button role='presentation' type='button' tabindex='-1'><i class='mce-ico mce-i-outdent'></i></button></div> <div id='mceu_8' class='mce-widget mce-btn mce-last' tabindex='-1' aria-labelledby='mceu_8' role='button' aria-label='Increase indent'><button role='presentation' type='button' tabindex='-1'><i class='mce-ico mce-i-indent'></i></button></div> </div> </div> </div> </div> <div id='mceu_21' class='mce-container mce-toolbar mce-stack-layout-item mce-last' role='toolbar'> <div id='mceu_21-body' class='mce-container-body mce-flow-layout'> <div id='mceu_22' class='mce-container mce-flow-layout-item mce-first mce-last mce-btn-group' role='group'> <div id='mceu_22-body'> <div id='mceu_9' class='mce-widget mce-btn mce-first' tabindex='-1' aria-labelledby='mceu_9' role='button' aria-label='Insert/edit link'><button role='presentation' type='button' tabindex='-1'><i class='mce-ico mce-i-link'></i></button></div> <div id='mceu_10' class='mce-widget mce-btn' tabindex='-1' aria-labelledby='mceu_10' role='button' aria-label='Insert image from URL'><button role='presentation' type='button' tabindex='-1'><i class='mce-ico mce-i-image'></i></button></div> <div id='mceu_11' class='mce-widget mce-btn' tabindex='-1' aria-labelledby='mceu_11' role='button' aria-label='Insert/edit video'><button role='presentation' type='button' tabindex='-1'><i class='mce-ico mce-i-media'></i></button></div> <div id='mceu_12' class='mce-widget mce-btn mce-colorbutton' role='button' tabindex='-1' aria-haspopup='true' aria-label='Text color'><button role='presentation' hidefocus='1' type='button' tabindex='-1'><i class='mce-ico mce-i-forecolor'></i><span id='mceu_12-preview' class='mce-preview'></span></button><button type='button' class='mce-open' hidefocus='1' tabindex='-1'> <i class='mce-caret'></i></button></div> <div id='mceu_13' class='mce-widget mce-btn mce-colorbutton' role='button' tabindex='-1' aria-haspopup='true' aria-label='Background color'><button role='presentation' hidefocus='1' type='button' tabindex='-1'><i class='mce-ico mce-i-backcolor'></i><span id='mceu_13-preview' class='mce-preview'></span></button><button type='button' class='mce-open' hidefocus='1' tabindex='-1'> <i class='mce-caret'></i></button></div> <div id='mceu_14' class='mce-widget mce-btn mce-menubtn mce-fixed-width mce-listbox mce-last' tabindex='-1' aria-labelledby='mceu_14' role='button' aria-label='Font Sizes' aria-haspopup='true'><button id='mceu_14-open' role='presentation' type='button' tabindex='-1'>Font Sizes <i class='mce-caret'></i></button></div> </div> </div> </div> </div> </div> </div> <div id='mceu_23' class='mce-edit-area mce-container mce-panel mce-stack-layout-item' hidefocus='1' tabindex='-1' role='group' style='border-width: 1px 0px 0px;'> <iframe id='CustomModelForm_items_{0}_itemDescription_ifr' frameborder='0' allowtransparency='true' title='Rich Text Area. Press ALT-F9 for menu. Press ALT-F10 for toolbar. Press ALT-0 for help' srcdoc='<html><head></head><body id=tinymce class=mce-content-body data-id=CustomModelForm_items_{0}_itemDescription contenteditable=true spellcheck=false>{4}</body></html>' style='width: 100%; height: 200px; display: block;'> </iframe> </div> <div id='mceu_24' class='mce-statusbar mce-container mce-panel mce-stack-layout-item mce-last' hidefocus='1' tabindex='-1' role='group' style='border-width: 1px 0px 0px;'> <div id='mceu_24-body' class='mce-container-body mce-flow-layout'> <div id='mceu_25' class='mce-path mce-flow-layout-item mce-first'> <div role='button' class='mce-path-item mce-last' data-index='{0}' tabindex='-1' id='mceu_25-0' aria-level='0'>p</div> </div> <div id='mceu_26' class='mce-flow-layout-item mce-last mce-resizehandle'><i class='mce-ico mce-i-resize'></i></div> </div> </div> </div> </div> <input type='text' value='<html><head></head><body id=tinymce class=mce-content-body data-id=CustomModelForm_items_{0}_itemDescription contenteditable=true spellcheck=false>{4}</body></html>' hidden='true' field-type='textEditor' field-attr='textEditor' class='editorTextarea' name='CustomModelForm[items][{0}][itemDescription]' id='CustomModelForm_items_{0}_itemDescription' aria-hidden='true' style='display: none;'></input> <div class='errorMessage hidden'></div> </div> <style> .mce-path {{display: none !important;}} .imgur{{text-align: center;padding-top: 20px;}} .mce-primary{{background-color: #f89c21;}} .mce-primary:hover{{background-color: rgba(248, 156, 33, 0.7);}} </style> <a rel='remove' class='remove-button multiple-remove' href='javascript:void(0)' style='display: none;'><img src='/img/tabs_delete.png'></a> <div class='item-number'>#1</div> </div>";

        private void GenerateHtml(List<GlossaryData> glossaryData, string[] images, string path)
        {
            string content = "";
            for (int count = 0; count < glossaryData.Count(); count++)
            {
                content += String.Format(html, count, glossaryData[count].Title, images[count % images.Count()], GetInnerHtml(glossaryData[count].DescriptionHtml), glossaryData[count].DescriptionHtml);
            }
            File.WriteAllText(path, content);
        }


        private string GetInnerHtml(string htmlString)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlString);

            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//text()"))
            {
                if (!String.IsNullOrEmpty(node.InnerText))
                    return node.InnerText.Trim();
            }
            return String.Empty;
        }

        public void GenerateChukle()
        {
            string text = File.ReadAllText(@"C:\code\AppGyeserConsoleApplication\100SantaBantaJokesData.txt");
            string[] token = Regex.Split(text, @"\d\d\.");
            token = token.Select(x => x.Trim()).ToArray();
            token = token.Distinct().ToArray();
            token = token.Where(x => !String.IsNullOrEmpty(x)).ToArray();
            token = token.Select(x => Regex.Replace(x, "\r\n", "<br/>")).ToArray();
            token = token.OrderBy(a => Guid.NewGuid()).ToArray();
            List<GlossaryData> glossaryData = token.Select((x,i) => new GlossaryData(String.Format("संता बंता Joke {0}", i+1), String.Format("<p>{0}</p>", x))).ToList();
            GenerateHtml(glossaryData, jokesImages, @"C:\code\AppGyeserConsoleApplication\100SantaBantaJokesHtml.txt");
        }
    }

        class GlossaryData
        {
            public string Title { get; set; }
            public string DescriptionHtml { get; set; }

            public GlossaryData(string Title, string DescriptionHtml)
        {
            this.Title = Title;
            this.DescriptionHtml = DescriptionHtml;
        }
    }
    }
