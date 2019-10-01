using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace Jokes.Controllers
{
    public class JokeService : Joke
    {

        public string SearchResults(string word)
        {
            string Data;
            string TextHTML;
            string[] ListJokes = new string[30];
            string[] ShortJoke = new string[30];
            string[] MediumJoke = new string[30];
            string[] LargeJoke = new string[30];

            int countShort = 0, countMedium = 0, countLarge = 0, i;
            Int32 jokeLenght;

            try
            {
                Data = SearchCore(word);
                var Obj = JObject.Parse(Data);

                i = 0;
                foreach (var child in Obj["results"])
                {
                    ListJokes[i] = child["joke"].ToString();
                    i++;
                }

                for (i = 0; i < ListJokes.Length; i++)
                {
                    jokeLenght = countWords(ListJokes[i]);
                    if (jokeLenght > 1 && jokeLenght < 10)
                    {
                        ListJokes[i] = Regex.Replace(ListJokes[i], word, "<strong>" + word.ToUpper() + "</strong>", RegexOptions.IgnoreCase);
                        ShortJoke[countShort] = ListJokes[i];
                        countShort++;
                    }

                    if (jokeLenght >= 10 && jokeLenght < 20)
                    {
                        ListJokes[i] = Regex.Replace(ListJokes[i], word, "<strong>" + word.ToUpper() + "</strong>", RegexOptions.IgnoreCase);
                        MediumJoke[countMedium] = ListJokes[i];
                        countMedium++;
                    }

                    if (jokeLenght >= 20)
                    {
                        ListJokes[i] = Regex.Replace(ListJokes[i], word, "<strong>" + word.ToUpper() + "</strong>", RegexOptions.IgnoreCase);
                        LargeJoke[countLarge] = ListJokes[i];
                        countLarge++;
                    }
                }
                TextHTML = "<h3>Short Jokes (Total:" + (countShort).ToString() + ")</h3><blockquote>";
                for (i = 0; i < ShortJoke.Length; i++)
                {
                    if (ShortJoke[i] != null)
                        TextHTML = TextHTML + ShortJoke[i] + "<br>";
                }
                TextHTML = TextHTML + "</blockquote><h3>Medium Jokes (Total:" + (countMedium).ToString() + ")</h3><blockquote>";
                for (i = 0; i < MediumJoke.Length; i++)
                {
                    if (MediumJoke[i] != null)
                        TextHTML = TextHTML + MediumJoke[i] + "<br>";
                }

                TextHTML = TextHTML + "</blockquote><h3>Long Jokes (Total:" + (countLarge).ToString() + ")</h3><blockquote>";
                for (i = 0; i < LargeJoke.Length; i++)
                {
                    if (LargeJoke[i] != null)
                        TextHTML = TextHTML + LargeJoke[i] + "<br>";
                }
                TextHTML = TextHTML + "</blockquote>";

                return TextHTML;
            }
            catch (Exception)
            {
                return "<h3>Search error, please try again later<h3>";
            }
        }
    }

  
}