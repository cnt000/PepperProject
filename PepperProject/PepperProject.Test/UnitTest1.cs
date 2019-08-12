using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GetLab

namespace PepperProject.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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
                        {new[] {"20", "40", "60"}, new[] {"x", "y", "j.json"}}
                    }
                },
                {
                    "macro", new Dictionary<string[], string[]>
                    {
                        {new[] {"1", "15", "15"}, new[] {"a", "b", "readytowear.json"}},
                        {new[] {"2", "4", "6"}, new[] {"x", "y", "z.json"}}
                    }
                }
            };

            string[] ids = {"100", "2", "3"};

            var label = GetLabelForDimensions.GetLabelForItem(ids, configuration);
        }
    }
}
