using SentenceGenerator.Models.Structure;
using SentenceGenerator.Models.Structure.Phrase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SentenceGenerator.Models
{
    public class Generator
    {
        public string[] structure;


        public Generator(string[] input)
        {
            structure = input;
        }

        public List<Word> Generate()
        {
            List<Word> sentenceList = new List<Word>();
            for (int i = 0; i < structure.Length; i++)
            {
                if (structure[i].Equals("s")){
                    Sentence sentence = new Sentence();
                    sentence.words.ForEach(w => sentenceList.Add(w));
                }
                else if (structure[i].Equals("np"))
                {
                    NounPhrase phrase = new NounPhrase();
                    phrase.words.ForEach(w => sentenceList.Add(w));
                }
                else if (structure[i].Equals("vp"))
                {
                    VerbPhrase phrase = new VerbPhrase();
                    phrase.words.ForEach(w => sentenceList.Add(w));
                }
                if (structure[i].Equals("det"))
                {
                    string[] wordOptions = { "the", "a" };
                    var wordObj = new Determiner(wordOptions);
                    sentenceList.Add(wordObj);
                }
                else if (structure[i].Equals("n"))
                {
                    var wordObj = new Noun();
                    var isFrontVowel = wordObj.IsFrontVowel(wordObj.chosen) ? true : false;
                    sentenceList.Add(wordObj);
                    if (isFrontVowel)
                    {
                        string[] wordList = { "an" };
                        var determiner = new Determiner(wordList);
                        if (i - 1 >= 0)
                        {
                            if(sentenceList[i-1].chosen == "det")
                            {
                                sentenceList[i - 1] = determiner;
                            }
                            
                        }

                    }

                }
                else if (structure[i].Equals("prep"))
                {
                    var wordObj = new Preposition();
                    sentenceList.Add(wordObj);
                }
                else if (structure[i].Equals("iv"))
                {

                    string[] wordOptions = { "deteriorates", "votes", "sits", "increases", "laughs", "originates", "fluctuates", "trends" };
                    var wordObj = new IntransativeVerb(wordOptions);
                    sentenceList.Add(wordObj);
                }
                else if (structure[i].Equals("tv"))
                {
                    string[] wordOptions = { "addresses", "borrows", "brings", "discusses", "raises", "offers", "pays", "writes", "promises", "has" };
                    var wordObj  = new TransativeVerb(wordOptions);
                    sentenceList.Add(wordObj);

                }
                else if (structure[i].Equals("pp"))
                {
                    PrepPhrase phrase = new PrepPhrase();
                    phrase.words.ForEach(w => sentenceList.Add(w));

                }
            }
                
            return sentenceList;
        }
        /*public List<Word> Generate()
        {
            Word prevWord = null;
            Word nextWord = null;

            for (int i = 0; i < structure.Count; i++)
            {
                Word wordObj = null;
                bool isFrontVowel = false;
                //Parse string to Word type, to create Word
                if (structure[i].Equals("det"))
                {
                    string[] wordList = { "the", "a" };
                    wordObj = new Determiner(wordList);
                }
                else if (structure[i].Equals("n"))
                {
                    wordObj = new Noun();
                    isFrontVowel = wordObj.IsFrontVowel(wordObj.chosen) ? true : false;

                }
                else if (structure[i].Equals("v"))
                {
                    wordObj = new Verb();

                }
                else if (structure[i].Equals("iv"))
                {
                    string[] wordList = { "eats", "swims", "rides" };
                    wordObj = new IntransativeVerb(wordList);

                }
                else if (structure[i].Equals("tv"))
                {
                    string[] wordList = { "needs", "returns", "helps" };
                    wordObj = new TransativeVerb(wordList);

                }
                else if (structure[i].Equals("prep"))
                {
                    string[] wordList = { "at", "in", "on", "by", "for" };
                    wordObj = new Preposition(wordList);

                }
                else if (structure[i].Equals("adj"))
                {
                    wordObj = new Adjective();

                }
                else if (structure[i].Equals("pp"))
                {


                }




                words.Add(wordObj);
                if (isFrontVowel)
                {
                    string[] wordList = { "an" };
                    wordObj = new Determiner(wordList);
                    if (i - 1 >= 0)
                    {
                        words[i - 1] = wordObj;
                    }
                    else { return null; }

                }

            }
            return words;
        }*/

        public string GetSentence(List<Word> words)
        {
            if (words != null)
            {
                string result = "";
                words[0].chosen = char.ToUpper(words[0].chosen[0]) + words[0].chosen.Substring(1);

                for (int i = 0; i < words.Count; i++)
                {
                    result += words[i].chosen;

                    if (words.Count - 1 != i)
                    {
                        result += " ";
                    }
                    else
                    {
                        result += ".";
                    }
                }

                return result;
            }
            else
            {
                return "Invalid Input.";
            }

        }

        /*public bool CheckValid(int i, Word wordObj)
        {
            bool error = false;
            if (wordObj.nextType != null)
            {
                if (i + 1 < structure.Count)
                {
                    if (wordObj.nextType.Equals("!" + structure[i + 1]))
                    {
                        error = true;
                    }
                    else if (!wordObj.nextType.Equals(structure[i + 1]) && !wordObj.nextType.Contains('!'))
                    {
                        error = true;
                    }


                }

            }

            if (wordObj.prevType != null)
            {

                if (i - 1 >= 0)
                {
                    if (wordObj.prevType.Equals("!" + structure[i - 1]))
                    {
                        error = true;
                    }
                    else if (!wordObj.prevType.Equals(structure[i - 1]) && !wordObj.prevType.Contains('!'))
                    {
                        error = true;
                    }


                }

            }
            return error;
        }*/
    }
}