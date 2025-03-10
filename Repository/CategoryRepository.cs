﻿using Entits;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        AdoNetManageContext _AdoNetManageContext;

        public CategoryRepository(AdoNetManageContext manageDbContext)
        {
            this._AdoNetManageContext = manageDbContext;
        }

 

        public async Task<List<Category>> GetCategory()
        {
            return await _AdoNetManageContext.Categories.ToListAsync();

        }






    }
}
