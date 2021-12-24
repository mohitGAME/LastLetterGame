using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace GrpcLastLetter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //create object
            // int initialCapacity = 82765;
            // int maxEditDistanceDictionary = 2; //maximum edit distance per dictionary precalculation
            // var symSpell = new SymSpell(initialCapacity, maxEditDistanceDictionary);

            // //load dictionary
            // string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            // string dictionaryPath = baseDirectory + "../../../frequency_dictionary_en_82_765.txt";
            // int termIndex = 0; //column of the term in the dictionary text file
            // int countIndex = 1; //column of the term frequency in the dictionary text file
            // if (!symSpell.LoadDictionary(dictionaryPath, termIndex, countIndex))
            // {
            //     Console.WriteLine("File not found!");
            //     //press any key to exit program
            //     Console.ReadKey();
            //     return;
            // }

            // //lookup suggestions for single-word input strings
            // string inputTerm = "hous";
            // int maxEditDistanceLookup = 0; //max edit distance per lookup (maxEditDistanceLookup<=maxEditDistanceDictionary)
            // var suggestionVerbosity = SymSpell.Verbosity.Top; //Top, Closest, All
            // var suggestions = symSpell.Lookup(inputTerm, suggestionVerbosity, maxEditDistanceLookup);

            // //display suggestions, edit distance and term frequency
            // foreach (var suggestion in suggestions)
            // {
            //     Console.WriteLine(suggestion.term + " " + suggestion.distance.ToString() + " " + suggestion.count.ToString("N0"));
            // }



        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
