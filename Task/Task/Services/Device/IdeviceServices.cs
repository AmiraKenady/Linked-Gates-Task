using Task.Models;

namespace Task.Services.Device
{
    public interface IdeviceServices
    {
        public IEnumerable<DeviceViewModel> AddDevice();
        public void EditDevice(DeviceViewModel device);

    }
}
