﻿using MangoWebApi.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MangoWebApi.BLL.Interfaces
{
    public interface ICategoryService
    {
        Task<Categories> Add(Categories categories);
        Task<IEnumerable<Categories>> Get();
        Task<Categories> GetById(int id);
        Task<bool> Update(int id, Categories categories);
        Task<bool> Delete(int id);
    }
}
