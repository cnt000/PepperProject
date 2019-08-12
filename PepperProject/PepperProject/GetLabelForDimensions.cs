using System.Collections.Generic;
using System.Linq;

namespace PepperProject
{
    public static class GetLabelForDimensions
    {
        public static string GetLabelForItem(string[] dimensions, Dictionary<string, Dictionary<string[], string[]>> configuration)
        {
            var match = configuration.Values.Where(x => x.Keys.Any(y => y.Contains("100"))).Last(a => a.Any(y => y.Key.Where(b => b.Contains("100")).Any()));
            // ReSharper disable once GenericEnumeratorNotDisposed
            Dictionary<string[], string[]>.Enumerator matchEnum = match.GetEnumerator();
            matchEnum.MoveNext();

            return string.Join("/", matchEnum.Current.Value);
        }

        public static string GetLabelForItemForEach(string[] dimensions, Dictionary<string, Dictionary<string[], string[]>> configuration)
        {
            var label = "";
            foreach (var item in configuration)
            {
                var labels = item
                                .Value
                                .SingleOrDefault(p => ContKey(p, dimensions[0])).Value ?? new string[] { };
                label = labels.Length > 0 ? string.Join("/", labels) : label;
            }

            return label;
        }

        public static string GetLabelForItemSplitted(Dictionary<string, string> dimensions, Dictionary<string, Dictionary<string[], string[]>> configuration)
        {
            string[] code10LabelPath = configuration["code10"].Where(x => x.Key.Contains(dimensions["code10"])).Select(x => x.Value).SingleOrDefault();
            string[] microLabelPath = configuration["micro"].Where(x => x.Key.Contains(dimensions["micro"])).Select(x => x.Value).SingleOrDefault();
            string[] macroLabelPath = configuration["macro"].Where(x => x.Key.Contains(dimensions["macro"])).Select(x => x.Value).SingleOrDefault();

            if (macroLabelPath != null && macroLabelPath.Length > 0) return string.Join("/", macroLabelPath);
            if (microLabelPath != null && microLabelPath.Length > 0) return string.Join("/", microLabelPath);
            if (code10LabelPath != null && code10LabelPath.Length > 0) return string.Join("/", code10LabelPath);

            return "";
        }

        private static bool ContKey(KeyValuePair<string[], string[]> p, string n) => p.Key.Contains(n);
    }
}