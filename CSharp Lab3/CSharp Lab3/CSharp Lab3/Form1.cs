using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace CSharp_Lab3
{
    public partial class Form1 : Form
    {
        private string _currentPath;

        public Form1()
        {
            InitializeComponent();

            _currentPath = AppDomain.CurrentDomain.BaseDirectory;
        }

        private void StartAnalyze()
        {
            string result = FindSlnFiles();
            if (result != "")
            {
                string[] path = result.Split(Path.DirectorySeparatorChar);
                infoLabel.Text += "Znaleziono plik " + path[path.Length - 1] + "\nAnalizuję...\n";

                result = FindProjFiles();
                if (result != "")
                {
                    path = result.Split(Path.DirectorySeparatorChar);
                    infoLabel.Text += "Znaleziono plik " + path[path.Length - 1] + "\nAnalizuję...\n";

                    AnalyzeXML(result);
                }
                else
                {
                    infoLabel.Text += "Nie znaleziono pliku .*proj\n";
                }
            }
            else
            {
                infoLabel.Text += "Nie znaleziono pliku .sln\n";
            }

        }

        private string FindSlnFiles()
        {
            string[] files = Directory.GetFiles(_currentPath, "*.sln");

            if(files.Length != 0) return files[0];
            return "";
        }

        private string FindProjFiles()
        {
            string[] files = Directory.GetFiles(_currentPath, "*.*proj", SearchOption.AllDirectories);

            if (files.Length != 0) return files[0];
            return "";
        }

        private void AnalyzeXML(string fileName)
        {
            infoLabel.Text += "Znalezione pliki: ";
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(fileName);

            XmlNodeList elements1 = doc.GetElementsByTagName("Compile");
            XmlNodeList elements2 = doc.GetElementsByTagName("EmbeddedResource");

            foreach (XmlNode item in elements1)
            {
                infoLabel.Text += item.Attributes["Include"].Value + ", ";
            }

            foreach (XmlNode item in elements2)
            {
                infoLabel.Text += item.Attributes["Include"].Value + ", ";
            }

        }


        private void changeFolderBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();

            _currentPath = folderBrowserDialog1.SelectedPath;
            currentPathLabel.Text = _currentPath;

            StartAnalyze();
        }

    }
}
