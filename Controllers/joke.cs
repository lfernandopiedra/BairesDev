
using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace Jokes.Controllers
{
    public class Joke
    {
        private string url = "https://icanhazdadjoke.com/";
        private string valJoke;
        public string getRandJokes()
        {
            var Joke = new WebClient();

            //Json
            Joke.Headers.Add("Accept", "application/json");
            var jsonJoke = Joke.DownloadString(url);
            var Obj = JObject.Parse(jsonJoke);
            valJoke = Obj["joke"].ToString();
            return valJoke;
        }

        public string SearchCore(string Term)
        {
            var Joke = new WebClient();

            Joke.Headers.Add("Accept", "application/json");
            var jsonJoke = Joke.DownloadString(url + "search?term=" + Term + "&limit=30");
            valJoke = Convert.ToString(jsonJoke);
            return valJoke;
        }

        public int countWords(string word)
        {
            int count = 0;

            if (word != null)
                count = word.Split().Length;

            return count;
        }


    }
}