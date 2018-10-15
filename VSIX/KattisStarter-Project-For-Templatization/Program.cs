using System;
using System.Collections.Generic;

namespace AvanadeKattisStarter1
{
    class Program
    {
        /// <summary>
        /// Here you will get a list each item is an input line. 
        /// </summary>
        /// <param name="lstInputLines"> these represent a line/item representation of the input file </param>
        public static void SolveKattisAndWriteOutput(List<string> lstInputLines)
        {
           
        }
        #region LIB
        /// <summary>
        /// Returns an array of Ints based on input lines
        /// </summary>
        /// <param name="strLine"></param>
        /// <returns></returns>
        static int[] SplitInts(string strLine)
        {
            var items = strLine.Split(new[] { ' ' });
            int[] retInts = new int[items.Length];
            int i = 0;
            foreach (string s in items)
            {
                retInts[i] = int.Parse(items[i++]);

            }
            return retInts;
        }


        #endregion

        #region IGNORE
        static void Main(string[] args)
        {
            List<string> lstInputLines = new List<string>();
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                lstInputLines.Add(line);
            }
            SolveKattisAndWriteOutput(lstInputLines);
        }

    }
    #endregion

}