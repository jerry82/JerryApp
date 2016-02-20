using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JerryApp.Data.Models {

    /*
     * proxy class for data presentation layer
     * */
    public class TitleModel {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string TitleNameSortable { get; set; }
        public Nullable<int> TitleTypeId { get; set; }
        public Nullable<int> ReleaseYear { get; set; }
        public Nullable<System.DateTime> ProcessedDateTimeUTC { get; set; }
        public Dictionary<string, string> OtherNames { get; set; }
    }
}
