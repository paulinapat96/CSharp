using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
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
            string slnFilePath = FindFile(_currentPath, "*.sln", false);
            if (slnFilePath != "")
            {
                infoLabel.Text += "Znaleziono plik " + GetNameOfFileFromPath(slnFilePath) + "\nAnalizuję...\n";

                string projFilePath = FindFile(_currentPath, "*.*proj", true);
                if (projFilePath != "")
                {
                    infoLabel.Text += "Znaleziono plik " + GetNameOfFileFromPath(projFilePath) + "\nAnalizuję...\n";

                    string pathToCopiedFiles = CopyFiles(GetPathOfParentDirectory(slnFilePath), AnalyzeXML(projFilePath));

                    infoLabel.Text += "\n\n*** Kończę pracę i otwieram folder ze skopiowanymi plikami ***";
                    System.Diagnostics.Process.Start("explorer.exe", pathToCopiedFiles);
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

        private string FindFile(string path, string fileName, bool searchInSubdirectories)
        {
            string[] files = (searchInSubdirectories)? Directory.GetFiles(path, fileName, SearchOption.AllDirectories) : Directory.GetFiles(path, fileName);

            if (files.Length != 0) return files[0];
            return "";
        }

        private List<string> AnalyzeXML(string fileName)
        {
            string pathToFile = GetPathOfParentDirectory(fileName);
            List<string> files = new List<string>();

            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.Load(fileName);

            List<XmlNodeList> elements = new List<XmlNodeList>();
            elements.Add(doc.GetElementsByTagName("Compile"));
            elements.Add(doc.GetElementsByTagName("EmbeddedResource"));
            elements.Add(doc.GetElementsByTagName("None"));

            infoLabel.Text += "Znalezione pliki: ";
            foreach (XmlNodeList element in elements)
            {
                foreach (XmlNode item in element)
                {
                    infoLabel.Text += item.Attributes["Include"].Value + ", ";
                    files.Add(pathToFile + item.Attributes["Include"].Value);
                }
            }

            infoLabel.Text += "\n";
            return files;
        }

        private string CopyFiles(string destinationPath, List<string> filesToCopyPaths)
        {
            string nameOfCreatedFolder = destinationPath + "Kopia";
            while(Directory.Exists(nameOfCreatedFolder))
            {
                infoLabel.Text += "\nZnaleziono już folder " + nameOfCreatedFolder + "\nSzukam wolnej nazwy...";
                nameOfCreatedFolder += "a";
            }

            Directory.CreateDirectory(nameOfCreatedFolder);
            infoLabel.Text += "\nTworzę folder " + nameOfCreatedFolder + " i przenoszę do niego znelezione pliki.";

            foreach (string filePath in filesToCopyPaths)
            {
                string fileName = filePath;
                if (filePath.Contains(Path.DirectorySeparatorChar)) fileName = GetNameOfFileFromPath(filePath);

                File.Copy(filePath, nameOfCreatedFolder + Path.DirectorySeparatorChar + fileName);
            }

            return nameOfCreatedFolder;
        }

        private string GetPathOfParentDirectory(string filePath)
        {
            string[] path = filePath.Split(Path.DirectorySeparatorChar);
            return filePath.Substring(0, filePath.Length - path[path.Length - 1].Length);
        }

        private string GetNameOfFileFromPath(string filePath)
        {
            string[] path = filePath.Split(Path.DirectorySeparatorChar);
            return path[path.Length - 1];
        }

        private void changeFolderBtn_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            _currentPath = folderBrowserDialog1.SelectedPath;

            if(_currentPath == "") _currentPath = AppDomain.CurrentDomain.BaseDirectory;
            currentPathLabel.Text = _currentPath;
            infoLabel.Text = "Log List:\n";

            StartAnalyze();
        }

    }
}
