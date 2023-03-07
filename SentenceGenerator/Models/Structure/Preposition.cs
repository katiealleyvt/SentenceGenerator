using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SentenceGenerator.Models.Structure
{
    public class Preposition : Word
    {
        public Preposition(string[] input) : base(input)
        {
            wordType = "prep";
            nextType = "det";
            words = input;
            chosen = ChooseWord();
        }
        public Preposition() : base()
        {
            wordType = "prep";
            nextType = "det";
            words = GetOptions();
            chosen = ChooseWord();
        }

        public override string[] GetOptions()
        {
            return new string[] { "at", "in", "on", "by", "for" };
        }

    }
}