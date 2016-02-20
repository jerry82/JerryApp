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

        CustomValidator validator = new CustomValidator();

        [HttpGet]
        public IHttpActionResult Get(string keyword) {
            string error = validator.ValidateKeyword(keyword);
            if (!String.IsNullOrEmpty(error)) {
                return BadRequest(error);
            }
            try {
                IEnumerable<TitleNameModel> models = DataAccess.Instance.SearchTitleByName(keyword);
                return Ok(models);
            }
            catch (Exception ex) {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id) {
            try {
                Title model = DataAccess.Instance.GetTitleDetails(id);
                return Ok(model);
            }
            catch (Exception ex) {
                return BadRequest(ex.ToString());
            }
        }
    }
}
