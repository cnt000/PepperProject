using System;
using System.Collections.Generic;

namespace PepperProject
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {
            var configuration = new Dictionary<string, Dictionary<string[], string[]>>
            {
                {
                    "code10", new Dictionary<string[], string[]>
                    {
                        {new[] {"100", "300", "500"}, new[] {"a", "b", "d.json"}},
                        {new[] {"1", "400", "50"}, new[] {"x", "y", "z.json"}}
                    }
                },
                {
                    "micro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "30", "50"}, new[] {"a", "b", "f.json"}},
                        {new[] {"20", "100", "60"}, new[] {"d", "g", "j.json"}}
                    }
                },
                {
                    "macro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "15", "15"}, new[] {"a", "b", "readytowear.json"}},
                        {new[] {"100", "4", "6"}, new[] {"x", "y", "z.json"}}
                    }
                }
            };

            Dictionary<string, string> ids = new Dictionary<string, string> {
                { "code10", "100" },
                { "micro", "2" },
                { "macro", "3" }
            };

            var label = GetLabelForDimensions.GetLabelForItemSplitted(ids, configuration);
            // var res = configuration.Values.First(p => p.Keys.Count(q => q.Contains("6")) > 0).Values.ToList()[0];

            Console.WriteLine(label);
        }

    }
}