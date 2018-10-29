using System.Collections.Generic;
using NewsReader.Repositories.Models;

namespace NewsReader.Repositories
{
    public interface IDataRepository
    {
        void StoreData(List<NewsData> data);
    }
}
