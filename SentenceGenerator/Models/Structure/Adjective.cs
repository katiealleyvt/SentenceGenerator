using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SentenceGenerator.Models.Structure
{
    public class Adjective : Word
    {
        public Adjective(string[] input) : base(input)
        {
            wordType = "adj";
            prevType = "v";
            words = input;
            chosen = ChooseWord();

        }
        public Adjective() : base()
        {

            wordType = "adj";
            prevType = "v";
            words = GetOptions();
            chosen = ChooseWord();

        }
    }
}