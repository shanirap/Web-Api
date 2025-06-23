using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoriesData : ICategoriesData
    {
        UsersDBContext dBContext;
        public CategoriesData(UsersDBContext usersDBContext)
        {
            dBContext = usersDBContext;
        }
        public async Task<List<Category>> getCategory()//funtion's name starts with a capital letter - change it
        {
            return await dBContext.Categories.ToListAsync<Category>();
        }
    }
}
