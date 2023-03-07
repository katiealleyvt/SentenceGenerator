using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SentenceGenerator.Models.Structure.Phrase
{
    public abstract class Phrase
    {
        public List<Word> words;
        public string[] structure;

        public Phrase()
        {
            structure = ChooseStruct();
            words = new List<Word>();
        }
        public Phrase(string[] input)
        {
            structure = input;
            words = new List<Word>();
        }

        public abstract string[] ChooseStruct();

    }
}