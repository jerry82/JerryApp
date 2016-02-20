using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JerryApp.Data.Models {
    public class TitleNameModel {
        public Nullable<int> TitleId { get; set; }
        public Dictionary<string, string> NamesDict { get; set; }

        /*
        public string TitleNameLanguage { get; set; }
        public string TitleNameType { get; set; }
        public string TitleNameSortable { get; set; }
        public string TitleName { get; set; }
        public int Id { get; set; }
        */

    }
}
