using System;
using System.Diagnostics;

namespace FinalizeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("Hello World!");
            ExampleClass ex = new ExampleClass();
            ex.ShowDuration();

            for (int i = 0; i < 100; i++)
            {
                Console.ReadLine();

            }
            Console.ReadKey();
        }
    }

    public class ExampleClass
    {
        Stopwatch sw;

        public ExampleClass()
        {
            sw = Stopwatch.StartNew();
            Debug.WriteLine("Instantiated object");
        }

        public void ShowDuration()
        {
            Debug.WriteLine("This instance of {0} has been in existence for {1}",
                              this, sw.Elapsed);
        }

        ~ExampleClass()
        {
            Debug.WriteLine("Finalizing object");
            sw.Stop();
            Debug.WriteLine("This instance of {0} has been in existence for {1}",
                              this, sw.Elapsed);
        }
    }

    // The example displays output like the following:
    //    Instantiated object
    //    This instance of ExampleClass has been in existence for 00:00:00.0011060
    //    Finalizing object
    //    This instance of ExampleClass has been in existence for 00:00:00.0036294
}
