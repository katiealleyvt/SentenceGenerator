using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace SentenceGenerator.Models.Structure.Phrase
{
    public class PrepPhrase : Phrase
    {
        public PrepPhrase() : base()
        {
            structure = ChooseStruct();
            words = Generate();
        }
        public PrepPhrase(string[] input) : base(input)
        {
            structure = input;
            words = Generate();
        }

        public override string[] ChooseStruct()
        {
            
            return new string[]{ "prep","det","n"};

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
                else if (structure[i].Equals("prep"))
                {
                    wordObj = new Preposition();

                }

                words.Add(wordObj);
                if (isFrontVowel)
                {
                    string[] wordOption = { "an" };
                    wordObj = new Determiner(wordOption);
                    if (i - 1 >= 0)
                    {
                        words[i - 1] = wordObj;
                    }
                    else { return null; }

                }

            }
            return words;
        }
    }
}