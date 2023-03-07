using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SentenceGenerator.Models.Structure
{
    public class Verb : Word
    {
        public Verb(string[] input) : base(input)
        {
            wordType = "v";
            words = input;
            chosen = ChooseWord();
        }
        public Verb() : base()
        {
            wordType = "v";
            words = GetOptions();
            chosen = ChooseWord();
        }

        public override string[] GetOptions()
        {
            string jsonString = File.ReadAllText("C:/Users/Katie/source/repos/SentenceGenerator/SentenceGenerator/Dictionary/verbs.json");
            var optionsDict = JsonConvert.DeserializeObject<dynamic>(jsonString);
            var verbArray = optionsDict.v;
            var verbs = new Dictionary<string, List<string>>();
            verbs["present"] = new List<string>();

            foreach (var verb in verbArray)
            {
                string present = verb.present;
                verbs["present"].Add(present+'s');
            }

            return verbs["present"].ToArray();
        }
    }
}