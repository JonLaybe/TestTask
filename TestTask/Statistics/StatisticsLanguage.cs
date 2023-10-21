using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Statistics
{
    /// <summary>
    /// Класс описывает язык букв. Короткое название, все гласные и согласные языка.
    /// </summary>
    public class StatisticsLanguage
    {
        public Language Language { get; set; } //язык
        public string LanguageVowel { get; set; } // гласные
        public string LanguageConsonants { get; set; } // согласные
    }
}
