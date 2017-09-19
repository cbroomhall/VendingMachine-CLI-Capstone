using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TDDExercises
{
    public class WordsToNumbers
    {
        public int WordsToNums(string n)
        {
            if (n == "zero")
            {
                return 0;
            }

            Dictionary<string, int> numLookup = new Dictionary<string, int>()
            {
                { "one", 1},{"two", 2 },{"three", 3},{"four",4 },{ "five",5 },{ "six",6 },{ "seven", 7 },{ "eight",8 },{ "nine",9 },{ "ten",10 },{ "eleven", 11 },
                { "twelve",12 },{ "thirteen",13 },{ "fourteen",14 },{ "fifteen",15 },{ "sixteen",16 },{ "seventeen",17 },{ "eighteen",18 },{ "nineteen",19 },
                { "twenty",20 },{ "thirty",30 },{ "forty",40 },{ "fifty",50 },{ "sixty",60 },{ "seventy",70 },{ "eighty",80 },{ "ninety",90 }

            };

            if (numLookup.ContainsKey(n))
            {
                return numLookup[n];
            }


            string[] split = n.Split('-', ' ', '\t');

            
            
            if(split.Contains("thousand")&& split.Length==3)
            {
                int splitReturn = (numLookup[split[0]] + numLookup[split[1]]) * 1000;
                return splitReturn;
            }
            else if(split.Contains("thousand") && split[2]=="thousand" && split.Length==5)
            {

                int splitReturn = ((numLookup[split[0]] + numLookup[split[1]]) * 1000) + numLookup[split[4]];
                return splitReturn;
            }
            else if( split.Contains("thousand") && split[2]=="thousand" && split.Length==6)
            {
                if (split[5] == "hundred")
                {
                    int splitReturn = ((numLookup[split[0]] + numLookup[split[1]]) * 1000) + (numLookup[split[4]] * 100);
                    return splitReturn;
                }
                else
                {
                    int splitReturn = ((numLookup[split[0]] + numLookup[split[1]]) * 1000) + (numLookup[split[4]] + numLookup[split[5]]);
                    return splitReturn;
                }
            }
                        
                                                      
            
            
            
            else if (split.Contains("thousand") && split.Length <3)
            {
                int splitReturn = numLookup[split[0]] * 1000;
                return splitReturn;
            }
            else if (split.Contains("thousand") && split.Length < 5)
            {
                int splitReturn = numLookup[split[0]] * 1000 + numLookup[split[3]];
                return splitReturn;

            }
            else if (split.Contains("thousand") && split.Length < 6)
            {
                if (split[4] == "hundred")
                {
                    int splitReturn = numLookup[split[0]] * 1000 + numLookup[split[3]] * 100;
                    return splitReturn;
                }
                else
                {
                    int splitReturn = numLookup[split[0]] * 1000 + numLookup[split[3]] + numLookup[split[4]];
                    return splitReturn;
                }
            }
            else if(split.Contains("thousand") && split.Length < 8)
            {
                int splitReturn = numLookup[split[0]] * 1000 + numLookup[split[3]] * 100 + numLookup[split[6]];
                return splitReturn;
            }
            else if(split.Contains("thousand") && split.Length < 9)
            {
                int splitReturn = numLookup[split[0]] * 1000 + numLookup[split[3]] * 100 + numLookup[split[6]] + numLookup[split[7]];
                return splitReturn;
            }

            else if (split.Contains("hundred") && split.Length < 3)
            {
                int splitReturn = numLookup[split[0]] * 100;
                return splitReturn;
            }
            else if (split.Contains("hundred") && split.Length < 5)
            {
                int splitReturn3 = numLookup[split[0]] * 100 + numLookup[split[3]];
                return splitReturn3;
            }
            else if (split.Contains("hundred") && split.Length < 6)
            {
                int splitReturn4 = numLookup[split[0]] * 100 + numLookup[split[3]] + numLookup[split[4]];
                return splitReturn4;
            }

            else
            {
                int splitReturn2 = numLookup[split[0]] + numLookup[split[1]];
                return splitReturn2;
            }
            return 0;
        }



    }
}

