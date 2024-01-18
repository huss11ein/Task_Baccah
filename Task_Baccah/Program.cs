namespace Task_Baccah
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            numbersConversion english = new numbersConversion(303000);
            NumberConversionInArabic arabic = new NumberConversionInArabic(1000145);
            Console.WriteLine(arabic.startComputing());
            Console.WriteLine(english.startComputing());
            Console.ReadLine();
        }
    }
}