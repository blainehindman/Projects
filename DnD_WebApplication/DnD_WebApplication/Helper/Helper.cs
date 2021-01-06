using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DnD_WebApplication.Helper
{
    public class Helper_Functions
    {
        Dictionary<string, string> dictionary;
        public void UserDictionary(string[] Names, string[] Alignments)
        {
            dictionary = new Dictionary<string, string>();

            if (Names != null && Alignments != null)
            {
                int ArraySize = Names.Length;

                for (int i = 0; i < ArraySize; i++)
                {
                    dictionary.Add(Names[i], Alignments[i]);
                }
            }
        }

        public Dictionary<string, string> getDictionary()
        {
            return this.dictionary;
        }
    }
}
