using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Statistics
{
    /// <summary>
    /// Класс описывает статистику для букв
    /// </summary>
    public class StatisticLetter : Statistic
    {
        /// <summary>
        /// Ф-ция создает статистку на выражение.
        /// </summary>
        /// <param name="listLetterStats">Список всех статистик</param>
        /// <param name="letter">Строка по которой будет создаваться статистика</param>
        /// <param name="register">Устанавливает регистер. true - не регистрозависимый, false - регистрозависимый. По умолчанию true.</param>
        public override void IncStatistic(IList<LetterStats> listLetterStats, string letter, bool register = true)
        {
            if (CheckStringLetter(letter))
            {
                letter = register ? letter : letter.ToLower();
                int index = -1;
                LetterStats letterStat = new LetterStats();

                foreach (LetterStats item in listLetterStats)
                {
                    index++;
                    if (item.Letter == letter)
                    {
                        letterStat = item;
                        break;
                    }
                }

                if (letterStat.Letter == null)
                    listLetterStats.Add(new LetterStats() { Letter = letter, Count = 1 });
                else
                    listLetterStats[index] = new LetterStats() { Letter = letterStat.Letter, Count = ++letterStat.Count };
            }
        }


        /// <summary>
        /// Ф-ция создает статистку на выражение.
        /// </summary>
        /// <param name="listLetterStats">Список всех статистик</param>
        /// <param name="charType">Перечисление, тип букв(гласные, согласные)<param>
        /// <param name="language">Перечисление, язык букв</param>
        public override void RemoveStatistic(IList<LetterStats> letterStats, CharType charType, Language language)
        {
            List<LetterStats> listRemove = new List<LetterStats>();

            foreach (var item in letterStats)
                try
                {
                    if (item.Letter.Length > 0 && charType != CheckCharType(item.Letter[0], language))
                        listRemove.Add(item);
                }catch
                {

                }

            foreach(var item in listRemove)
                letterStats.Remove(item);

            listRemove.Clear();
        }
    }
}
