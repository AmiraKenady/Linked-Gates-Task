using DB;
using Task.Models;

namespace Task.Services
{
    public interface IdeviceServices
    {
        public Device AddDevice(DeviceViewModel device);
        //public IEnumerable<DeviceViewModel> GetDevices();
        public List<Device> GetDevices();
        public void AddDeviceAndProprty(DeviceViewModel deviceModel);
        List<PropertiesValues> GetPropertyByDeviceId(int Deviceid);

        //public DeviceViewModel GetDeviceById(int id);
        public Device GetDeviceById(int id);
        public DeviceViewModel EditDevice(DeviceViewModel deviceModel);
        List<PropertiesValues> EditDeviceProp(List<PropertiesValuesViewModel> propertiesValuesViewModels, int DeviceId);
        DeviceViewModel EditDeviceAndProprty(DeviceViewModel deviceModel);



    }
}
