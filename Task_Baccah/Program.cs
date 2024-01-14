namespace Task_Baccah
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            numbersConversion english = new numbersConversion(457);
            NumberConversionInArabic arabic = new NumberConversionInArabic(199);
            Console.WriteLine(arabic.startComputing());
            Console.WriteLine(english.startComputing());
            Console.ReadLine();
        }
    }
}