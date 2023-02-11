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
        public void EditDevice (DeviceViewModel deviceModel);



    }
}
