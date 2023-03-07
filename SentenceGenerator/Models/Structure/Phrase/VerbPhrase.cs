using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace SentenceGenerator.Models.Structure.Phrase
{
    public class VerbPhrase : Phrase
    {
        public VerbPhrase() : base()
        {
            structure = ChooseStruct();
            words = Generate();
        }
        public VerbPhrase(string[] input) : base(input)
        {
            structure = input;
            words = Generate();
        }

        public override string[] ChooseStruct()
        {
            List<List<string>> options = new List<List<string>>();
            List<string> option1 = new List<string> { "tv", "np" };
            List<string> option2 = new List<string> { "iv", "pp" };
            List<string> option3 = new List<string> { "iv" };
            options.Add(option1);
            options.Add(option2);
            options.Add(option3);

            byte[] bytes = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            int seed = BitConverter.ToInt32(bytes, 0);
            Random random = new Random(seed);
            int randInt = random.Next(0, 3);
            return options[randInt].ToArray();

        }

        public List<Word> Generate()
        {
            List<Word> wordList = new List<Word>();

            for (int i = 0; i < structure.Length; i++)
            {
                Word wordObj = null;
                //Parse string to Word type, to create Word
                if (structure[i].Equals("iv"))
                {
                    
                    string[] wordOptions = { "deteriorates", "votes", "sits", "increases", "laughs", "originates", "fluctuates", "trends" };
                    wordObj = new IntransativeVerb(wordOptions);
                    words.Add(wordObj);
                }
                else if (structure[i].Equals("tv"))
                {
                    string[] wordOptions = { "addresses", "borrows", "brings", "discusses", "raises", "offers", "pays", "writes", "promises", "has" };
                    wordObj = new TransativeVerb(wordOptions);
                    words.Add(wordObj);

                }
                else if (structure[i].Equals("pp"))
                {
                    PrepPhrase phrase = new PrepPhrase();
                    phrase.words.ForEach(w => words.Add(w));

                }
                else if (structure[i].Equals("np"))
                {
                    NounPhrase phrase = new NounPhrase();
                    phrase.words.ForEach(w => words.Add(w));

                }


            }
            return words;
        }
    }
}