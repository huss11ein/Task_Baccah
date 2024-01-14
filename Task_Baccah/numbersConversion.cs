using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Baccah
{
    public class numbersConversion
    {
        private string[] basicNumbersAboveNine = new string[10]{
    "ten",
    "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen",
    "eighteen", "nineteen"};
        private string[] basicNumbersBelowNine = new string[10] {
            "zero",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
        };
        string[] tensNumbers = new string[10]
        {
    "","", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
        };
        private double convertedNumber;
        private bool isFloat;
        string pos;
        public numbersConversion(double number)
        {
            convertedNumber = number;
            if ((int)number == number)
                isFloat = false;
            else
                isFloat = true;
            if (number > 0)
                pos = "positive";
            else
            {
                convertedNumber /= -1;
                pos = "negative";
            }
        }
        private string getLessThanTwenty(long number)
        {
            if (number >= 0 && number <= 9)
                return basicNumbersBelowNine[number];
            else
                return basicNumbersAboveNine[number - 10];
        }
        #region stillnotcompleted
        /* public long numbersAfterPoint(double number) {
             if (number == 0)
                 return 0;
             return (long)(number * 10) + numbersAfterPoint((number * 10)-((long)(number*10) ));
         }*/
        #endregion
        public string startComputing()
        {
            if (isFloat)
            {
                return pos + " " + returnResultInEnglish((long)convertedNumber) + " point ";
            }
            else
            {
                return pos + " " + returnResultInEnglish((long)convertedNumber);
            }


        }
        private string getTens(long number)
        {
            if (number % 10 == 0)
                return tensNumbers[number / 10];
            else
                return tensNumbers[number / 10] + " " + basicNumbersBelowNine[number % 10];
        }

        private string returnResultInEnglish(long number)
        {
            if (number >= 0 && number <= 19)
                return getLessThanTwenty(number);
            else if (number < 100)
            {
                return getTens(number);
            }
            else if (number < 1000) //900
            {
                if (number % 100 == 0)
                    return returnResultInEnglish(number / 100) + " hundred ";
                else
                    return returnResultInEnglish(number / 100) + " hundred " + "and " + returnResultInEnglish(number % 100);
            }

            else if (number < 1000000)
            { //600000
                if (number % 1000 == 0)
                    return returnResultInEnglish(number / 1000) + " thousand ";
                else
                    return returnResultInEnglish(number / 1000) + " thousand " + "and " + returnResultInEnglish(number % 1000);
            }

            else if (number < 1000000000) //600000000
            {
                long x = number;
                if (number % 1000000 == 0) //60
                    return returnResultInEnglish(number / 1000000) + " million ";
                else //6123456
                    return returnResultInEnglish(number / 1000000) + " million " + "and " + returnResultInEnglish(number % 1000000); //6 123456
            }
            return "not valid";


        }

    }
}
