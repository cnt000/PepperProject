using System;
using System.Collections.Generic;
using System.Linq;

namespace PepperProject
{
    public static class GetLabelForDimensions
    {
        public static string GetLabelForItem(Dictionary<string, string> dimensions,
            Dictionary<string, Dictionary<string[], string[]>> configuration)
        {
            //var result = configuration.Where(x => x.Value.Where(y => y.Key.Contains(dimensions["macro"])).Select(z => z.Value).Count() > 0);
            //var result = configuration.ToList().ForEach(x => x.Key.Contains(dimensions["code10"])
            //    .Select(x => x.Value).DefaultIfEmpty(new string[] { }).Single());
            return "";
        }
        public static string GetLabelForItemForEach(Dictionary<string, string> dimensions,
            Dictionary<string, Dictionary<string[], string[]>> configuration)
        {
            foreach (var item in configuration.Reverse())
            {
                var labelPath = item.Value.Where(x => x.Key.Contains(dimensions[item.Key])).Select(x => x.Value)
                    .DefaultIfEmpty(new string[] { }).Single();
                if (labelPath.Length > 0) return string.Join("/", labelPath);
            }

            return "";
        }

        public static string GetLabelForItemSplitted(Dictionary<string, string> dimensions,
            Dictionary<string, Dictionary<string[], string[]>> configuration)
        {
            var code10LabelPath = configuration["code10"].Where(x => x.Key.Contains(dimensions["code10"]))
                .Select(x => x.Value).DefaultIfEmpty(new string[] { }).Single();
            var microLabelPath = configuration["micro"].Where(x => x.Key.Contains(dimensions["micro"]))
                .Select(x => x.Value).DefaultIfEmpty(new string[] { }).Single();
            var macroLabelPath = configuration["macro"].Where(x => x.Key.Contains(dimensions["macro"]))
                .Select(x => x.Value).DefaultIfEmpty(new string[] { }).Single();

            if (macroLabelPath.Length > 0) return string.Join("/", macroLabelPath);
            if (microLabelPath.Length > 0) return string.Join("/", microLabelPath);
            if (code10LabelPath.Length > 0) return string.Join("/", code10LabelPath);

            return "";
        }

    }
}
