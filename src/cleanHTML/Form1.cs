using System;
using System.Windows.Forms;
using System.IO;
using Ganss.XSS;
using System.Collections.Generic;

namespace cleanHTML
{
    public partial class cleanHTML : Form
    {
		public cleanHTML()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "All files|*.html;*.htm" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    textBox1.Text = ofd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IEnumerable<string> allowedCss = new string[] { "border", "border-bottom", "border-bottom-color", "border-bottom-left-radius", "border-bottom-right-radius", "border-bottom-style", "border-bottom-width", "border-collapse", "border-color", "border-image", "border-image-outset", "border-image-repeat", "border-image-slice", "border-image-source", "border-image-width", "border-left", "border-left-color", "border-left-style", "border-left-width", "border-radius", "border-right", "border-right-color", "border-right-style", "border-right-width", "border-spacing", "border-style", "border-top", "border-top-color", "border-top-left-radius", "border-top-right-radius", "border-top-style", "border-top-width", "border-width", "bottom", "caption-side", "clear", "clip", "color", "content", "counter-increment", "counter-reset", "cursor", "direction", "display", "empty-cells", "float", "font", "font-feature-settings", "font-kerning", "font-language-override", "font-size", "font-size-adjust", "font-stretch", "font-style", "font-synthesis", "font-variant", "font-variant-alternates", "font-variant-caps", "font-variant-east-asian", "font-variant-ligatures", "font-variant-numeric", "font-variant-position", "font-weight", "height", "left", "letter-spacing", "line-height", "list-style", "list-style-image", "list-style-position", "list-style-type", "margin", "margin-bottom", "margin-left", "margin-right", "margin-top", "max-height", "max-width", "min-height", "min-width", "opacity", "orphans", "outline", "outline-color", "outline-offset", "outline-style", "outline-width", "overflow", "overflow-wrap", "overflow-x", "overflow-y", "padding", "padding-bottom", "padding-left", "padding-right", "padding-top", "page-break-after", "page-break-before", "page-break-inside", "quotes", "right", "table-layout", "text-align", "text-decoration", "text-decoration-color", "text-decoration-line", "text-decoration-skip", "text-decoration-style", "text-indent", "text-transform", "top", "unicode-bidi", "vertical-align", "visibility", "white-space", "widows", "width", "word-spacing", "z-index" };

            if (textBox2.Text == string.Empty)
            {
                label3.Text = "請填寫存放位置";
            }
            else 
            {
                try
                {
                    string dirtyHtml = File.ReadAllText(textBox1.Text);

                    var sanitizer = new HtmlSanitizer(null, null, null, null, allowedCss);
                    var clean = sanitizer.Sanitize(dirtyHtml);
                    File.WriteAllText(textBox2.Text + "/" + Path.GetFileName(textBox1.Text), clean);

                    label3.Text = "完成";
                }
                catch
                {
                    label3.Text = "失敗，無效檔案！";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            textBox2.Text = path.SelectedPath;
        }
    }
}
