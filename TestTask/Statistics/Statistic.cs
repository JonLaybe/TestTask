using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Statistics
{
    /// <summary>
    /// Абстрактный класс, для описание всей буквенной статистики
    /// </summary>
    public abstract class Statistic
    {
        private Dictionary<Language, StatisticsLanguage> _languages; // Словарь название и описание языков

        public Statistic()
        {
            //Создание языков
            _languages = new Dictionary<Language, StatisticsLanguage>()
            {
                { 
                    Language.en, 
                    new StatisticsLanguage() { Language = Language.en, LanguageVowel = "aeiouy", LanguageConsonants = "bcdfghjklmnpqrstvwxz"}
                },
                {
                    Language.ru,
                    new StatisticsLanguage() { Language = Language.ru, LanguageVowel = "ауоыэяюёие", LanguageConsonants = "бвгджзйклмнпрстфхцчшщ"}
                }
            };
        }

        /// <summary>
        /// Ф-ция возвращает тип у переданного символа(гласный или согласный).
        /// </summary>
        /// <param name="statisticsLanguage">Описание языка</param>
        /// <param name="character">Символ для проверки на гласность или согласность</param>
        /// <exception cref="">Wrong character to define voweliness or agreeableness.</exception>
        /// <returns>Тип перечисление CharType</returns>
        private CharType GetVowelConsonants(StatisticsLanguage statisticsLanguage, char character)
        {
            if (statisticsLanguage.LanguageVowel.Contains(char.ToLower(character)))
                return CharType.Vowel;
            else if (statisticsLanguage.LanguageConsonants.Contains(char.ToLower(character)))
                return CharType.Consonants;

            throw new Exception($"Wrong character ({character}) to define voweliness or agreeableness."); // неверный символ для определения гласности или согласности
        }

        /// <summary>
        /// Ф-ция возвращает тип у переданного символа(гласный или согласный).
        /// </summary>
        /// <param name="character">Символ для проверки на гласность или согласность</param>
        /// <param name="lang">Перечисление, язык символа</param>
        /// <exception cref="">Unknown character or character not supported by built-in languages.</exception>
        /// <returns>Тип перечисление CharType</returns>
        protected CharType CheckCharType(char character, Language lang)
        {
            if (!CheckStringLetter(character.ToString())) throw new Exception($"Char ({character}) is not letter.");

            switch(lang)
            {
                case Language.en:
                    return GetVowelConsonants(_languages[Language.en], character);
                case Language.ru:
                    return GetVowelConsonants(_languages[Language.ru], character);
            }

            throw new Exception($"Unknown character ({character}) or character not supported by built-in languages."); //Неизвестный символ или символ, не поддерживаемый встроенными языками.
        }

        /// <summary>
        /// Ф-ция проверяет является ли переданный символ буквой.
        /// </summary>
        /// <param name="str">Символ для проверки</param>
        /// <returns>true - буква, false - любой друой символ отличающийся от буквы</returns>
        protected bool CheckStringLetter(string str)
        {
            foreach (char c in str)
                if (!char.IsLetter(c))
                    return false;

            return true;
        }
        /// <summary>
        /// Ф-ция создает статистку на выражение.
        /// </summary>
        /// <param name="listLetterStats">Список всех статистик</param>
        /// <param name="letter">Строка по которой будет создаваться статистика</param>
        /// <param name="register">Устанавливает регистер. true - не регистрозависимый, false - регистрозависимый. По умолчанию true.</param>
        public abstract void IncStatistic(IList<LetterStats> letterStats, string letter, bool register = true);
        /// <summary>
        /// Ф-ция создает статистку на выражение.
        /// </summary>
        /// <param name="listLetterStats">Список всех статистик</param>
        /// <param name="charType">Перечисление, тип букв(гласные, согласные)<param>
        /// <param name="language">Перечисление, язык букв</param>
        public abstract void RemoveStatistic(IList<LetterStats> letterStats, CharType charType, Language language);
    }
}
