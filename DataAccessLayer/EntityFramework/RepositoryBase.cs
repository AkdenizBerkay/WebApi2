using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class RepositoryBase
    {
        private static NorthwindEntities dbcontext;
        private static object loc = new object();

        protected RepositoryBase()
        {

        }
        public static NorthwindEntities CreateContext()
        {
            if (dbcontext == null)
            {
                lock (loc)
                {
                    if (dbcontext == null)
                    {
                        dbcontext = new NorthwindEntities();
                    }
                }
            }
            return dbcontext;
        }
    }
}
