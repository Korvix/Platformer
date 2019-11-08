using System;
using System.Linq;
using UnityEngine;

namespace Platformer.GameSystem
{
    public class Localization : Singleton<Localization>
    {
        private string actualLanguage;
        private TextAsset csvFile;
        private string[,] grid;

        private void Awake()
        {
            CreateLocalizationGrid();
            SetActualLanguage("EN");
        }

        public void SetActualLanguage(string language)
        {
            actualLanguage = language;
        }

        public string GetTranslation(string key)
        {
            return grid[GetLanguageIndex(actualLanguage), GetKeyIndex(key)];
        }

        public string GetTranslation(string key, string language)
        {
            return grid[GetLanguageIndex(language), GetKeyIndex(key)];
        }

        private void CreateLocalizationGrid()
        {
            csvFile = Resources.Load<TextAsset>("Localization");
            grid = SplitCsvGrid(csvFile.text);
        }

        private int GetLanguageIndex(string language)
        {
            for (int i = 0; i <= grid.GetUpperBound(0); i++)
            {
                if (language == grid[i, 0])
                {
                    return i;
                }
            }
            return 0;
        }

        private int GetKeyIndex(string key)
        {
            for (int i = 0; i <= grid.GetUpperBound(1); i++)
            {
                if (key == grid[0, i])
                {
                    return i;
                }
            }
            return 1;
        }

        // splits a CSV file into a 2D string array
        private string[,] SplitCsvGrid(string csvText)
        {
            string[] lines = csvText.Split("\n"[0]);

            // finds the max width of row
            int width = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] row = SplitCsvLine(lines[i]);
                width = Mathf.Max(width, row.Length);
            }

            // creates new 2D string grid to output to
            string[,] outputGrid = new string[width + 1, lines.Length + 1];
            for (int y = 0; y < lines.Length; y++)
            {
                string[] row = SplitCsvLine(lines[y]);
                for (int x = 0; x < row.Length; x++)
                {
                    outputGrid[x, y] = row[x];

                    // This line was to replace "" with " in my output. 
                    // Include or edit it as you wish.
                    outputGrid[x, y] = outputGrid[x, y].Replace("\"\"", "\"");
                }
            }

            return outputGrid;
        }

        // splits a CSV row 
        private string[] SplitCsvLine(string line)
        {
            return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(line,
            @"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)",
            System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
                    select m.Groups[1].Value).ToArray();
        }
    }
}