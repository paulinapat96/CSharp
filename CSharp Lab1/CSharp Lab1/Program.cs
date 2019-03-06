using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab1
{


    public class Table
    {
        private string[] _header;
        private string[] _footer;
        private List<string[]> _rows;

        public Table()
        {
            _header = null;
            _footer = null;
            _rows = new List<string[]>();
        }

        public Table( string[] header, List<string[]> rows, string[] footer)
        {
            _header = header;
            _footer = footer;
            _rows = rows;
        }

        public int AddRow(string[] row)
        {
            _rows.Add(row);
            return 0;
        }

        public int AddHeader(string[] row)
        {
            if (_header == null)
            {
                _header = row;
                return 0;
            }
            else return 1;
        }

        public int AddFooter(string[] row)
        {
            if (_footer == null)
            {
                _footer = row;
                return 0;
            }
            else return 1;

        }

        public string WriteToString()
        {

            string text = "<table border=\"1\">\n";

            if (_header != null)
            {
                text += "<thead style=\"font-weight: bold;\">";
                foreach (string cell in _header)
                {
                    text += "<td> " + cell + " </td>";
                }
                text += "</thead>\n";
            }

            if (_rows.Count > 0)
            {
                int counter = 0;
                foreach (string[] row in _rows)
                {
                    if (counter % 2 == 1) text += "<tr style=\"background-color:#ddd;\">";
                    else text += "<tr>";

                    if (row != null)
                    {
                        foreach (string cell in row)
                        {
                            text += "<td>" + cell + "</td>";
                        }
                    }

                    text += "</tr>\n";
                    counter++;
                }
            }

            if (_footer != null)
            {
                text += "<tfoot style=\"font-size: small; color: #567;\">";
                foreach (string cell in _footer)
                {
                    text += "<td> " + cell + " </td>";
                }
                text += "</tfoot>\n";
            }

            text += "</table>";
            return text;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string option = "";
            Console.Write(  "Wybierz sposób wprowadzania danych do tabeli: \n" +
                            "- Konstruktor (Press 1)\n" +
                            "- Metody (Press 2)\n");
            option = Console.ReadLine();

            Console.Write( "\nWybierz rodzaj testu: \n" +
                            "- Tabelka 2x2 z prostymi liczbami (Press 1)\n" +
                            "- Tabelka 2x3 z dlugimi tekstami (Press 2)\n" +
                            "- Odczyt danych pliku z zapisem tabeli wynikowej do pliku.html (Press 3)\n" +
                            "- Tabela 2x5 z wierszem nagłówkowych + stopka (Press 4)\n");
            option += Console.ReadLine();


            List<string[]> rows = new List<string[]>();
            switch (option)
            {

                #region use Contructors
                case "11":
                    //1.1) tabelka 2x2 z prostymi liczbami,
                    rows.Add(new string[] { "1", "2" });
                    rows.Add(new string[] { "4", "8" });
                    Table table11 = new Table(null, rows, null);

                    WriteToFile(table11.WriteToString());
                    break;

                case "12":
                    //1.2) tabelka 2x3 z dlugimi tekstami,
                    rows.Clear();
                    rows.Add(new string[] { "Długi tekst numer jeden", "Drugi długi tekst w tym samym wierszu" });
                    rows.Add(new string[] { "Kolejny wiersz i trzeci długi tekst", "Czwarty długi tekst w tym samym wierszu co ostatnio" });
                    rows.Add(new string[] { "Trzeci długi wiersz i piąty jeszcze dłuższy tekst", "Szósty długi tekst ale trzecim w wierszu" });
                    Table table12 = new Table(null, rows, null);

                    WriteToFile(table12.WriteToString());
                    break;

                case "13":
                    //1.3) odczyt danych pliku, zapis tabeli wynikowej do pliku.html, wraz z nagªówkiem html,
                    WriteToFile(ReadFromFile().WriteToString());
                    break;

                case "14":
                    //1.4) tabela 2x5 z wierszem nagłówkowych + stopka
                    rows.Clear();
                    rows.Add(new string[] { "Treść11 z Konstruktora", "Treść12 z Konstruktora" });
                    rows.Add(new string[] { "Treść21 z Konstruktora", "Treść22 z Konstruktora" });
                    rows.Add(new string[] { "Treść31 z Konstruktora", "Treść32 z Konstruktora" });
                    rows.Add(new string[] { "Treść41 z Konstruktora", "Treść42 z Konstruktora" });
                    rows.Add(new string[] { "Treść51 z Konstruktora", "Treść52 z Konstruktora" });
                    Table table14 = new Table(new string[] { "Kolumna 1", "Kolumna 2" }, rows, new string[] { "Stopka 1", "Stopka 2" });

                    WriteToFile(table14.WriteToString());
                    break;

                #endregion
                #region use Methods
                case "21":
                    //1.1) tabelka 2x2 z prostymi liczbami,
                    Table table21 = new Table();
                    table21.AddRow(new string[] { "1", "3" });
                    table21.AddRow(new string[] { "9", "27" });

                    WriteToFile(table21.WriteToString());
                    break;

                case "22":
                    //1.2) tabelka 2x3 z dlugimi tekstami,
                    Table table22 = new Table();
                    table22.AddRow(new string[] { "Długie teksty", "Bardziej długie teksty" });
                    table22.AddRow(new string[] { "Jeszcze dłuższe teksty", "Dłuższe teksty od poprzednich" });
                    table22.AddRow(new string[] { "Tak długi tekst jak tylko się da", "Tekst dłuższy od poprzedniego" });

                    WriteToFile(table22.WriteToString());
                    break;

                case "23":
                    //1.3) odczyt danych pliku, zapis tabeli wynikowej do pliku.html, wraz z nagªówkiem html,
                    WriteToFile(ReadFromFile().WriteToString());
                    break;

                case "24":
                    //1.4) tabela 2x5 z wierszem nagłówkowych + stopka
                    Table table24 = new Table();
                    table24.AddHeader(new string[] { "Kolumna 1", "Kolumna 2" });
                    table24.AddRow(new string[] { "Treść11 z metody", "Treść12 z metody" });
                    table24.AddRow(new string[] { "Treść21 z metody", "Treść22 z metody" });
                    table24.AddRow(new string[] { "Treść31 z metody", "Treść32 z metody" });
                    table24.AddRow(new string[] { "Treść41 z metody", "Treść42 z metody" });
                    table24.AddRow(new string[] { "Treść51 z metody", "Treść52 z metody" });
                    table24.AddFooter(new string[] { "Stopka 1", "Stopka 2" });

                    WriteToFile(table24.WriteToString());
                    break;

                 #endregion

            }

            System.Diagnostics.Process.Start("table.html");
        }


        static void WriteToFile(string text)
        {
            using (StreamWriter outputFile = new StreamWriter("table.html"))
            {
                outputFile.WriteLine(text);
            }
        }

        static Table ReadFromFile()
        {
            Table table = new Table();
            var dataFromCSV = File.ReadAllLines("sheet.csv");

            int counter = 0;
            foreach (var line in dataFromCSV)
            {
                string[] cols = line.Split(',');

                if(counter == 0) table.AddHeader(cols);
                else table.AddRow(cols);

                counter++;
            }

            return table;
        }
    }
}
