using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class ValidationControl
    {
        public static Personeller IsPersonel(string name, string surname)
        {
            NorthwindEntities db = new NorthwindEntities();
            db.Configuration.ProxyCreationEnabled = false;
            Personeller personel = (from pers in db.Personeller where pers.Adi.ToLower().Equals(name.ToLower()) && pers.SoyAdi.ToLower().Equals(surname.ToLower()) select pers).FirstOrDefault();
            if (personel != null)
            {
                return personel;
            }
            else
            {
                return null;
            }
        }
    }
}
