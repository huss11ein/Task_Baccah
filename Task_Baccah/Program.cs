namespace Task_Baccah
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            NumberConversionInArabic n = new NumberConversionInArabic(199);
            Console.WriteLine(n.startComputing());
            Console.ReadLine();
        }
    }
}