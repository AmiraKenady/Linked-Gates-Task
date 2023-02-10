using DB;
using Task.Models;

namespace Task.Services
{
    public interface IpropertyServices
    {
        public List<Classtest> getProperties(int id);
        public void AddPropertiesValues(PropertiesValuesViewModel PropModel);
        //public void Addtest(PropertiesValuesViewModel PropModel);
    }
}
