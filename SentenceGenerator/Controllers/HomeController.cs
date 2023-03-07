using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SentenceGenerator.Models;

namespace SentenceGenerator.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }
        public ActionResult Index()
        {
            return View();
        }

       public string GetDefaultSentence(string structureStr)
        {
            if (string.IsNullOrEmpty(structureStr))
            {
                return "Invalid Input.";
            }
            var structureInput = structureStr.Split(' ')
                                  .Where(s => !string.IsNullOrWhiteSpace(s))
                                  .ToArray();
            bool isValid = true;
            string[] validInput = { "det", "n", "v", "prep", "iv", "tv", "adj", "s", "np", "vp", "pp" };

            if (structureInput.Length <= 0)
            {
                isValid = false;
            }

            for (int i=0; i<structureInput.Length;i++)
            {
                if (!validInput.Contains(structureInput[i]) || structureInput[i].Equals(""))
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                string[] structure = structureInput;
                Generator gen = new Generator(structure);
                var wordList = gen.Generate();
                var sentence = gen.GetSentence(wordList);
                return sentence;
            }
            else
            {
                return "Invalid input.";
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}