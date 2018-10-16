using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using System.Xml;
using System.Windows.Markup;
using Microsoft.Win32;


namespace WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // ((Run)FirstParagraph.Inlines.FirstInline).Text = "-*-";
            Run r = new Run("ewityesi sehfsoieyf ");
            Paragraph p = new Paragraph(r);
            ListItem li = new ListItem(p);
            listhistory.ListItems.Add(li);
            listhistory.ListItems.Add(new ListItem(new Paragraph(new Run(" ") { })));

            using (FileStream fs = File.Open(@"\\dc\Студенты\ПКО\SEP-172.1\WPF\documGertsen2.xaml", FileMode.Open))
            {
                FlowDocument doc = XamlReader.Load(fs) as FlowDocument;
                if(doc != null)
                {
                    dcDocument.Document = doc;
                }
                else
                {
                    MessageBox.Show("document error ");
                }
            }


            
        }

        private void btnSaveDocument_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog openFile = new SaveFileDialog();
            openFile.Filter = "RichTextBox (*.rtf)|*.rtf|All Files (*.*)|*.*";
            if (openFile.ShowDialog() == true)
            {
                TextRange docTr = new TextRange(
                    MyRichTextBox.Document.ContentStart,
                    MyRichTextBox.Document.ContentEnd);
                using (FileStream fs = File.Create(openFile.FileName))
                {
                    docTr.Save(fs, DataFormats.Rtf);
                }
            }

        }

        private void btnLoadDocument_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "RichTextBox (*.rtf)|*.rtf|All Files (*.*)|*.*";
            if(openFile.ShowDialog()==true)
            {
                TextRange docTr = new TextRange(
                    MyRichTextBox.Document.ContentStart,
                    MyRichTextBox.Document.ContentEnd);
                using (FileStream fs = File.Open(openFile.FileName, FileMode.Open))
                {
                    docTr.Load(fs, DataFormats.Rtf);
                }
            }
        }
    }
}
