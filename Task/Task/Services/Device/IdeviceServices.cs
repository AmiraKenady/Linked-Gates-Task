using DB;
using Task.Models;

namespace Task.Services
{
    public interface IdeviceServices
    {
        public void AddDevice(DeviceViewModel device);
        public IEnumerable<DeviceViewModel> GetDevices();
        

    }
}
