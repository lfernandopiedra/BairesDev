using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Jokes.Controllers
{
    public class JokeService : Joke
    {

        public string SearchResults(string word)
        {
            string Data;
            string TextHTML;
            List<string> ListJokes = new List<string>();
            List<string> ShortJoke = new List<string>();
            List<string> MediumJoke = new List<string>();
            List<string> LargeJoke = new List<string>();

            int countShort = 0, countMedium = 0, countLarge = 0;
            Int32 jokeLenght;

            try
            {
                Data = SearchCore(word);
                var Obj = JObject.Parse(Data);


                foreach (var child in Obj["results"])
                {
                    ListJokes.Add(child["joke"].ToString());

                }

                foreach (string Value in ListJokes)
                {
                    string ValReplace;
                    jokeLenght = countWords(Value);
                    if (jokeLenght > 1 && jokeLenght < 10)
                    {
                        ValReplace = Regex.Replace(Value, word, "<strong>" + word.ToUpper() + "</strong>", RegexOptions.IgnoreCase);
                        ShortJoke.Add(ValReplace);
                        countShort++;
                    }

                    if (jokeLenght >= 10 && jokeLenght < 20)
                    {
                        ValReplace = Regex.Replace(Value, word, "<strong>" + word.ToUpper() + "</strong>", RegexOptions.IgnoreCase);
                        MediumJoke.Add(ValReplace);
                        countMedium++;
                    }

                    if (jokeLenght >= 20)
                    {
                        ValReplace = Regex.Replace(Value, word, "<strong>" + word.ToUpper() + "</strong>", RegexOptions.IgnoreCase);
                        LargeJoke.Add(ValReplace);
                        countLarge++;
                    }
                }
                TextHTML = "<h3>Short Jokes (Total:" + (countShort).ToString() + ")</h3><blockquote>";


                foreach (string ValueShort in ShortJoke)
                {
                    TextHTML = TextHTML + ValueShort + "<br>";
                }
                TextHTML = TextHTML + "</blockquote><h3>Medium Jokes (Total:" + (countMedium).ToString() + ")</h3><blockquote>";
                foreach (string ValueMedium in MediumJoke)
                {
                    TextHTML = TextHTML + ValueMedium + "<br>";
                }

                TextHTML = TextHTML + "</blockquote><h3>Long Jokes (Total:" + (countLarge).ToString() + ")</h3><blockquote>";
                foreach (string ValueLarge in LargeJoke)
                {
                    TextHTML = TextHTML + ValueLarge + "<br>";
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