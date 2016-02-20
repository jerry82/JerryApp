using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using JerryApp.Data;
using JerryApp.Data.Models;

namespace JerryApp.Web.Services {
    public class DataAccess {

        IDataService dataService = null;

        #region Singleton
        private static readonly object padlock = new object();
        private static DataAccess instance = null;
        private DataAccess() {
            dataService = new EFDataService();
        }

        public static DataAccess Instance {
            get {
                lock (padlock) {
                    if (instance == null) {
                        instance = new DataAccess();
                    }
                    return instance;
                }
            }
        }
        #endregion

        #region apis
        public IEnumerable<TitleModel> GetAllTitles() {
            return dataService.GetAllTitles();
        }

        public IEnumerable<TitleNameModel> SearchTitleByName(string name) {
            return dataService.SearchTitleByName(name);
        }

        public Title GetTitleDetails(int titleId) {
            return dataService.GetTitleDetails(titleId);
        }
        #endregion
    }
}