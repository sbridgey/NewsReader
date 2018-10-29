using System.Linq;
using System.Collections.Generic;
using NewsReader.Data;
using NewsReader.Repositories.Models;

namespace NewsReader.Repositories
{
    public class DataRepository : IDataRepository
    {
        private DataContext _db;

        public DataRepository(DataContext db)
        {
            _db = db;
        }

        public void StoreData(List<NewsData> data)
        {
            foreach (var story in data)
            {
                var supplier = _db.Suppliers.FirstOrDefault(_ => _.SupplierName == story.SupplierName);
                int supplierId;
                if(supplier == null)
                {
                    supplierId = _db.Suppliers.Max(_ => _.SupplierID) + 1;
                    _db.Add(new Suppliers(){
                        SupplierName = story.SupplierName,
                        SupplierID = supplierId                    
                    });
                }else{
                    supplierId = supplier.SupplierID;
                }

                _db.Add(new NewStories()
                {
                    SupplierID = supplierId,
                    AddedDateTime = story.AddedDateTime,
                    ImagePath = story.ImagePath,
                    NewsStory = story.NewsStory,
                    Title = story.Title
                });
            }

            _db.SaveChanges();
        }
    }
}
