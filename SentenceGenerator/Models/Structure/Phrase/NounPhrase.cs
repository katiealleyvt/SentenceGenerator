using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace SentenceGenerator.Models.Structure.Phrase
{
    public class NounPhrase : Phrase
    {

        public NounPhrase() : base()
        {
            structure = ChooseStruct();
            words = Generate();
        }
        public NounPhrase(string[] input) : base(input)
        {
            structure = input;
            words = Generate();
        }

        public override string[] ChooseStruct()
        {
            List<List<string>> options = new List<List<string>>();
            List<string> option1 = new List<string> { "det", "n" };
            List<string> option2 = new List<string> { "det", "adj", "n" };
            options.Add(option1);
            options.Add(option2);

            byte[] bytes = new byte[4];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            int seed = BitConverter.ToInt32(bytes, 0);
            Random random = new Random(seed);
            int randInt = random.Next(0, 2);
            return options[randInt].ToArray();

        }

        public List<Word> Generate()
        {
            List<Word> wordList = new List<Word>();

            for (int i = 0; i < structure.Length; i++)
            {
                Word wordObj = null;
                bool isFrontVowel = false;
                //Parse string to Word type, to create Word
                if (structure[i].Equals("det"))
                {
                    string[] wordOptions = { "the", "a" };
                    wordObj = new Determiner(wordOptions);
                }
                else if (structure[i].Equals("n"))
                {
                    wordObj = new Noun();
                    isFrontVowel = wordObj.IsFrontVowel(wordObj.chosen) ? true : false;

                }
                else if (structure[i].Equals("adj"))
                {
                    wordObj = new Adjective();
                    isFrontVowel = wordObj.IsFrontVowel(wordObj.chosen) ? true : false;

                }

                words.Add(wordObj);
                if (isFrontVowel)
                {
                    string[] wordOption = { "an" };
                    wordObj = new Determiner(wordOption);
                    if (i - 1 >= 0)
                    {
                        if(words[i - 1].wordType == "det")
                        {
                            words[i - 1] = wordObj;
                        }
                        
                    }

                }

            }
            return words;
        }
        
    }
}