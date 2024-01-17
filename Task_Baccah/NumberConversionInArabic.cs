using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task_Baccah
{
    public class NumberConversionInArabic
    {
        private string[] basicNumbersAboveNine = new string[10]{
    "عشرة",
    "أحد عشر", "اثنا عشر", "ثلاثة عشر", "أربعة عشر", "خمسة عشر", "ستة عشر", "سبعة عشر",
    "ثمانية عشر", "تسعة عشر"};

        private string[] basicNumbersBelowNine = new string[10] {
    "صفر",
    "واحد",
    "اثنان",
    "ثلاثة",
    "أربعة",
    "خمسة",
    "ستة",
    "سبعة",
    "ثمانية",
    "تسعة"
};

        string[] tensNumbers = new string[10]
{
    "", "", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون"
};
        string[] numbers100200 = new string[7] {
        "مائة",
        "مأتان",
            "ألف",
            "الفان",
            "آلاف",
            "مليون",
            "ملايين"
        };

        private double convertedNumber;
        private bool isFloat;
        string pos;
        public NumberConversionInArabic(double number)
        {
            convertedNumber = number;
            if ((int)number == number)
                isFloat = false;
            else
                isFloat = true;
            if (number > 0)
                pos = "موجب";
            else
            {
                convertedNumber /= -1;
                pos = "سالب";
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
                return pos + " " + returnResultInEnglish((long)convertedNumber) + " و ";
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
                return basicNumbersBelowNine[number % 10] + " و " + tensNumbers[number / 10];
        }
        private string getHundereds(long number)
        {
            string hundredText = "";
            
            bool isUnique = false;
            if (number / 100 == 1 || number / 100 == 2)
            {
                hundredText = numbers100200[(number / 100) -1];
                isUnique = true;
            }
            if (number % 100 == 0)
                return isUnique == true ? hundredText : basicNumbersBelowNine[number / 100] + " مائة";
            else
                return (isUnique == true ? (hundredText) : (basicNumbersBelowNine[number / 100] + " مائة")) + " و " + returnResultInEnglish(number % 100);


        }

        private string getThousands(long number) {
            string thousandText = "";

            bool isUnique = false;
            if (number / 1000 == 1 || number / 1000 == 2)
            {
                thousandText = numbers100200[(number / 1000) +1];
                isUnique = true;
            }
            if (number % 1000 == 0)
                return (isUnique == true ? thousandText : returnResultInEnglish(number / 1000)) +(number <= 10000 ? " آلاف" : "ألف");
            else
                return (isUnique == true ? (thousandText) : (returnResultInEnglish(number / 1000) + (number <= 10000 ? " آلاف" : "ألف"))) + " و " + returnResultInEnglish(number % 1000);


        }
        private string getMillions(long number) {
            

            bool isUnique = false;
            if (number / 1000000 == 1 || number / 1000000 == 2)
            {
                isUnique = true;
            }
            if (number % 1000 == 0)
                return isUnique == true ? "مليون" : basicNumbersBelowNine[number / 1000000] + " ملايين";
            else
                return (isUnique == true ? ("مليون") : (basicNumbersBelowNine[number / 1000000] + " ملايين")) + " و " + returnResultInEnglish(number % 1000000);
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

                return getHundereds(number);
            }

            else if (number < 1000000)
            { //600000
                return getThousands(number);
            }

            else if (number < 1000000000) //600000000
            {
                long x = number;
                if (number % 1000000 == 0) //60
                    return returnResultInEnglish(number / 1000000) + " مليون ";
                else //6123456
                    return returnResultInEnglish(number / 1000000) + " مليون " + " و " + returnResultInEnglish(number % 1000000); //6 123456
            }
            return "not valid";


        }
    }
}
