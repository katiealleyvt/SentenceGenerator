using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace SentenceGenerator.Models.Structure
{
    public class Noun : Word
    {
        public Noun(string[] input) : base(input)
        {
            wordType = "n";
            words = input;
            chosen = ChooseWord();

        }
        public Noun() : base()
        {

            wordType = "n";
            words = GetOptions();
            chosen = ChooseWord();
            
        }
        

        public string ChooseWord(string prevWord)
        {
            string word = "";

                if (words.Length >= 1)
                {
                    byte[] bytes = new byte[4];
                    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                    rng.GetBytes(bytes);
                    int seed = BitConverter.ToInt32(bytes, 0);
                    Random random = new Random(seed);
                    int randInt = random.Next(0, words.Length);
                    word = words[randInt];
                
            }

            return word;
        }
        



    }
}