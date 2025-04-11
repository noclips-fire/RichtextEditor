using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using Microsoft.Win32;
using System.Drawing;
using System.Drawing.Imaging;


namespace RichtextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnImportHtml_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "HTML files (*.html;*.htm)|*.html;*.htm"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string htmlContent = File.ReadAllText(openFileDialog.FileName);
                using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(htmlContent)))
                {
                    richEditControl.LoadDocument(stream, DocumentFormat.Html);
                }
                //MessageBox.Show("HTML loaded successfully!");
            }
        }

        private void btnExportHtml_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "HTML files (*.html)|*.html"
            };

            string imageFolder = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Images");
            if (!Directory.Exists(imageFolder))
            {
                Directory.CreateDirectory(imageFolder);
            }

            if (saveFileDialog.ShowDialog() == true)
            {
                using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    richEditControl.SaveDocument(stream, DevExpress.XtraRichEdit.DocumentFormat.Html);
                }

                //MessageBox.Show("Export to HTML is complete!");
            }
        }

        private void btnExit_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            Close();
        }

        
    }
}