using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace SentenceGenerator.Models.Structure
{
    public class IntransativeVerb : Word
    {

        public IntransativeVerb(string[] input) : base(input)
        {
            wordType = "iv";
            nextType = "!det";
            words = input;
            chosen = ChooseWord();
        }
        public IntransativeVerb() : base()
        {
            wordType = "iv";
            nextType = "!det";
            words = GetOptions();
            chosen = ChooseWord();
        }


    }
}