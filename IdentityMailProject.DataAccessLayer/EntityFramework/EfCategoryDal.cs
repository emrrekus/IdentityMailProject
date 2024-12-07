using IdentityMailProject.DataAccessLayer.Abstract;
using IdentityMailProject.DataAccessLayer.Context;
using IdentityMailProject.DataAccessLayer.Repositories;
using IdentityMailProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityMailProject.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(IdentityMailContext context) : base(context)
        {
        }
    }
}
