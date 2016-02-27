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

    [RoutePrefix("api/Titles")]
    public class TitlesController : ApiController {

        CustomValidator validator = new CustomValidator();

        [HttpPost]
        [Route("Search")]
        public IHttpActionResult FindTitles(SearchModel model) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            try {
                IEnumerable<TitleNameModel> models = DataAccess.Instance.SearchTitleByName(model.TitleKeyword);
                return Ok(models);
            }
            catch (Exception ex) {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("{titleId}/Participants")]
        public IHttpActionResult FindParticipants(int titleId) {
            try {
                List<Participant> models = DataAccess.Instance.GetParticipants(titleId);
                return Ok(models);
            }
            catch (Exception ex) {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("{id}")]
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
