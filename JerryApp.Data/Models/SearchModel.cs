using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JerryApp.Data.Models {
    public class SearchModel {

        [Required(ErrorMessage="Keyword is required !")]
        [MaxLength(5, ErrorMessage="Keyword is more than 5 characters!")]
        public string TitleKeyword { get; set; }
    }
}
