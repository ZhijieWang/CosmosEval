using System;

namespace Cosmos
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Azure Cosmos Table Samples");
            BM1 bM1 = new BM1();
            bM1.RunSamples().Wait();
            //BasicSamples basicSamples = new BasicSamples();
            //basicSamples.RunSamples().Wait();

            //AdvancedSamples advancedSamples = new AdvancedSamples();
            //advancedSamples.RunSamples().Wait();

            Console.WriteLine();
            //Console.WriteLine("Press any key to exit");
            //Console.Read();
        }
    }
}
