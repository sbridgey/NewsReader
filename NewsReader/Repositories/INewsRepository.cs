﻿using System.Collections.Generic;
using System.Threading.Tasks;
using NewsReader.Repositories.Models;

namespace NewsReader.Repositories
{
    public interface INewsRepository
    {
        Task<List<NewsData>> Get();
    }
}
