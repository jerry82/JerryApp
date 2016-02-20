using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JerryApp.Data.Models;
using System.Globalization;

namespace JerryApp.Data {
    public static class Helpers {
    
        public static IEnumerable<TitleModel> Parse(IEnumerable<Title> entities) {
            List<TitleModel> titleModels = new List<TitleModel>();

            foreach (var entity in entities) {
                TitleModel tempModel = new TitleModel() {
                    TitleId = entity.TitleId,
                    TitleName = entity.TitleName,
                    TitleNameSortable = entity.TitleNameSortable,
                    ReleaseYear = entity.ReleaseYear,
                    ProcessedDateTimeUTC = entity.ProcessedDateTimeUTC
                };
                titleModels.Add(tempModel);
            }

            IEnumerable<TitleModel> titles = titleModels;
            return titles;
        }

        public static IEnumerable<TitleNameModel> Parse(IEnumerable<OtherName> entities) {
            Dictionary<int?, TitleNameModel> dict = new Dictionary<int?, TitleNameModel>();

            foreach (var e in entities) {
                TitleNameModel nm = null;
                if (!dict.ContainsKey(e.TitleId)) {
                    nm = new TitleNameModel() {
                        TitleId = e.TitleId,
                        NamesDict = new Dictionary<string, string>()
                    };
                    dict.Add(e.TitleId, nm);
                }
                else {
                    nm = dict[e.TitleId];
                }

                if (!nm.NamesDict.ContainsKey(e.TitleNameLanguage))
                    nm.NamesDict.Add(e.TitleNameLanguage, e.TitleNameSortable);
            }
            return dict.Values.ToList();
        }

        //string extension method
        public static bool Contains(this string target, string value, StringComparison comparison) {
            return target.IndexOf(value, comparison) >= 0;
        }

    }
}
