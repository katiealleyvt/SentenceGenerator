

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace SentenceGenerator.Models.Structure
{
    public abstract class Word
    {
        public string chosen;
        public Word next;
        public string[] words;
        public string wordType;
        public string nextType;
        public string prevType;

        public Word(string[] input)
        {
            
        }
        public Word()
        {
            
        }

        public string ChooseWord()
        {

            
            if (words.Length >= 1)
            {
                byte[] bytes = new byte[4];
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                rng.GetBytes(bytes);
                int seed = BitConverter.ToInt32(bytes, 0);
                Random random = new Random(seed);
                int randInt = random.Next(0, words.Length);
                return words[randInt];
            }
            return null;

        }
        public virtual string[] GetOptions()
        {
            string jsonString = File.ReadAllText("C:/Users/Katie/source/repos/SentenceGenerator/SentenceGenerator/Dictionary/words.json");
            var optionsDict = JsonConvert.DeserializeObject<Dictionary<string,string[]>>(jsonString);
            var wordOptions = optionsDict[wordType];
            return wordOptions;
        }
        public virtual string[] GetOptions(char start)
        {
            return null;
        }

        public bool IsFrontVowel(string word)
        {
            return word.StartsWith("a") || word.StartsWith("e") || word.StartsWith("i") || word.StartsWith("o") || word.StartsWith("u");
        }
    }

    
}