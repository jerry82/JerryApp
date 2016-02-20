using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JerryApp.Web.Services {

    public class CustomValidator {

        //we can check whether any not-allowed keyword 
        //the implementation depends on business logic
        public string ValidateKeyword(string keyword) {
            if (String.IsNullOrEmpty(keyword))
                return "keyword is empty!";
            return "";
        }
    }
}