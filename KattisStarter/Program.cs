using System;
using System.Collections.Generic;
using System.Text;

namespace KattisStarter
{
    class Program
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstInputLines"> these are </param>
        public static void SolveKattisAndWriteOutput(List<string> lstInputLines)
        { 
            foreach (string s in lstInputLines)
            {
                Console.WriteLine(s);
            }
        }
        #region IGNORE
        static void Main(string[] args)
        {
            List<string> lstInputLines = new List<string>();
      
            string line;
            while ((line = TrimFront()) != null)
            {
                lstInputLines.Add(line.Trim());
            }
            SolveKattisAndWriteOutput(lstInputLines);
        }



        private static string TrimFront()
        {
            var s = Console.ReadLine();
            if (s == null)
                return s;
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                if (Char.IsLetterOrDigit(c))
                {
                    sb.Append(c);
                }
                    
            }
            return (sb.ToString());
        }
        #endregion

    }
}
