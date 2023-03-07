using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace SentenceGenerator.Models.Structure
{
    public class Determiner : Word
    {
        public Determiner(string[] input) : base(input)
        {
            wordType = "det";
            nextType = "n";
            words = input;
            chosen = ChooseWord();
        }
        public Determiner() : base()
        {
            wordType = "det";
            nextType = "n";
            words = GetOptions();
            chosen = ChooseWord();
        }



    }
}