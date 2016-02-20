using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JerryApp.Data;
using JerryApp.Data.Models;
using JerryApp.Web.Services;

namespace JerryApp.Web.Controllers {

    public class TitlesController : ApiController {
        [HttpGet]
        public IEnumerable<TitleModel> Get() {
            return DataAccess.Instance.GetAllTitles();
        }

        [HttpGet]
        public IEnumerable<TitleNameModel> Get(string keyword) {
            return DataAccess.Instance.SearchTitleByName(keyword);
        }

        [HttpGet]
        public Title Get(int id) {
            return DataAccess.Instance.GetTitleDetails(id);
        }
    }
}
