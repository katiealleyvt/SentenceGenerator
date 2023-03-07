using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace SentenceGenerator.Models.Structure
{
    public class TransativeVerb : Word
    {
        //Needs to take a noun after it
        
        public TransativeVerb(string[] input) : base(input)
        {
            wordType = "tv";
            nextType = "det";
            words = input;
            chosen = ChooseWord();
        }
        public TransativeVerb() : base()
        {
            wordType = "tv";
            nextType = "det";
            words = GetOptions();
            chosen = ChooseWord();
        }

    }
}