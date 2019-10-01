using System.Web.Mvc;

namespace Jokes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult randomJokes()
        {

            return View();
        }

        public string getRandJokes()
        {
            string data;
            Joke ContJoke = new Joke();
            data = ContJoke.getRandJokes();
            return data;
        }

        [HttpPost]
        public ActionResult Search(string word)
        {
            string data;
            JokeService ResJoke = new JokeService();
            data = ResJoke.SearchResults(word);
            ViewBag.Message = MvcHtmlString.Create(data ?? string.Empty);
            return View();
        }


    }
}