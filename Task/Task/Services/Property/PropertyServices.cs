using DB;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Services
{
    public class PropertyServices:IpropertyServices
    {
        private readonly Context Db;
        public PropertyServices(Context _Db)
        {
            Db = _Db;
        }

        public List<Classtest> getProperties(int id)
        {
            List<Classtest> catprop = new List<Classtest>();
            var categories = Db.category.Include("Properties").Select(C => new { id = C.Id, pid = C.Properties.ToList() })
               .Where(c => c.id == id).ToList();
            foreach (var c in categories)
            {
                var cat = c.id;
                foreach (var item in c.pid)
                {
                    var prop = new Classtest() { id = cat, pid = item.Id, value = item.Name };
                    catprop.Add(prop);
                  
                }
            }
            return catprop;
        }

        public void AddPropertiesValues(PropertiesValuesViewModel PropModel)
        {
            PropertiesValues propertyValues = new PropertiesValues()
            {
                Values = PropModel.values,
                DeviceId = PropModel.DeviceId,
                PropertyId = PropModel.propertyId
            };
            Db.PropertiesValues.Add(propertyValues);
        }

        //public void Addtest(PropertiesValuesViewModel PropModel)
        //{
        //    PropertiesValues propertyValues = new PropertiesValues();
        //    Db.PropertiesValues.Include("Device")


        //}
    }
}
