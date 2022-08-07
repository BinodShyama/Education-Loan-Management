using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanManagement.Helpers.Extensions
{
    public static class ExtensionHelper
    {
        public static string ToWord(this decimal amount)
        {
            return ConvertToWord(amount);

        }
        public static string ConvertToWord(decimal amount)
        {

            var a = amount.ToString().Split('.');
            var no = a[0];
            int divider;
            var point = a.Length>1? a[1]:"";
            var hundred = "";
            var digits_1 = no.ToString().Length;
           var i = 0;
            var str = new List<string>();

            var words = new Dictionary<string, string>();
            words.Add("0", "");
            words.Add("1", "One"); 
            words.Add("2", "Two");
            words.Add("3", "Three"); 
            words.Add("4", "Four"); words.Add("5", "Five"); words.Add("6", "Six"); words.Add("7", "Seven"); words.Add("8", "Eight"); words.Add("9", "Nine"); words.Add("10", "Ten"); words.Add("11", "Eleven"); words.Add("12", "Twelve"); words.Add("13", "Thirteen"); words.Add("14", "Fourteen"); words.Add("15", "Fifteen"); words.Add("16", "Sixteen"); words.Add("17", "Seventeen"); words.Add("18", "Eighteen"); words.Add("19", "Nineteen"); words.Add("20", "Twenty"); words.Add("30", "Thirty"); words.Add("40", "Forty"); words.Add("50", "Fifty"); words.Add("60", "Sixty"); words.Add("70", "Seventy"); words.Add("80", "Eighty"); words.Add("90", "Ninety");

            var digits = new string[] { "", "Hundred", "Thousand", "Lakh", "Crore" };

            while (i < digits_1)
            {
                 divider = (i == 2) ? 10 : 100;
                amount = Math.Floor(Decimal.Parse(no) % divider);
                no = Math.Floor(Decimal.Parse(no) / divider).ToString();
                i += (divider == 10) ? 1 : 2;
                if (amount>0)
                {
                   var  counter = str.Count();
                  var  plural = (counter>0 && amount > 9) ? "s" : "";
                    hundred = (counter == 1 && string.IsNullOrEmpty(point)) ? "and " : "";
                    str.Add((amount < 21) ? words[amount.ToString()] + " " + digits[counter] + plural + " " + hundred : words[(Math.Floor(amount / 10) * 10).ToString()] + " " + words[(amount % 10).ToString()] + " " + digits[counter] + plural + " " + hundred);
                }
                else
                {
                    str.Add("");
                }
            }
            str = Enumerable.Reverse(str).ToList();
          var  result = string.Join("", str).TrimEnd();
           var points = (!string.IsNullOrEmpty(point)) ? " and" + words[(int.Parse(point) / 10).ToString()] + " " + words[(decimal.Parse( point) % 10).ToString()] + " Paisa Only." : " Only";
            return result.Trim() + points;
        }
    }
}
