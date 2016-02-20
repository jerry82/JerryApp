using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JerryApp.Data.Models;

namespace JerryApp.Data {

    /*
     * define an interface for data service layer
     * */
    public interface IDataService {

        IEnumerable<TitleModel> GetAllTitles();

        IEnumerable<TitleNameModel> SearchTitleByName(string name);

        Title GetTitleDetails(int titleId);

    }
}
