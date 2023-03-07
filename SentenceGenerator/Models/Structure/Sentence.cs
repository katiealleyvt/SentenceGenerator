using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SentenceGenerator.Models;
using SentenceGenerator.Models.Structure.Phrase;

namespace SentenceGenerator.Models.Structure
{
    public class Sentence
    {
        public List<Word> words;
        public string[] structure = { "np", "vp" };

        public Sentence()
        {

            words = new List<Word>();
            Generate();
        }

        public void Generate()
        {
            foreach (var input in structure)
            {
                if (input.Equals("np")){
                    NounPhrase phrase = new NounPhrase();
                    phrase.words.ForEach(w => words.Add(w));
                }
                else if (input.Equals("vp"))
                {
                    VerbPhrase phrase = new VerbPhrase();
                    phrase.words.ForEach(w => words.Add(w));
                }
                

            }
        }


    }
}