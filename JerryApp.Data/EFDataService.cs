using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JerryApp.Data.Models;
using System.Globalization;

namespace JerryApp.Data {

    /*
     * implementation of Entity Framework 6 data access layer
     * */
    public class EFDataService : IDataService {

        public IEnumerable<TitleModel> GetAllTitles() {
            using (TitlesEntities context = new TitlesEntities()) {
                return Helpers.Parse(context.Titles);
            }
        }

        public IEnumerable<TitleNameModel> SearchTitleByName(string name) {
            using (TitlesEntities context = new TitlesEntities()) {
                var result = context.OtherNames.ToList().Where(t => t.TitleNameSortable.Contains(name, StringComparison.InvariantCultureIgnoreCase));
                return Helpers.Parse(result);
            }
        }

        /*
         * explicitly control lazy load objects
         * */
        public Title GetTitleDetails(int titleId) {
            using (TitlesEntities context = new TitlesEntities()) {
                context.Configuration.ProxyCreationEnabled = false; 
                context.Configuration.LazyLoadingEnabled = false;
                var title = context.Titles.FirstOrDefault(t => t.TitleId == titleId);

                context.Entry(title).Collection(t => t.Awards).Load();
                context.Entry(title).Collection(t => t.OtherNames).Load();
                context.Entry(title).Collection(t => t.TitleGenres).Load();
                context.Entry(title).Collection(t => t.StoryLines).Load();

                foreach (var tg in title.TitleGenres) {
                    context.Entry(tg).Reference(x => x.Genre).Load();
                }
                
                return title;
            }
        }

    }
}
