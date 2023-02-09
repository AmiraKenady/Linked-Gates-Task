using DB;
using Task.Models;

namespace Task.Services.Device
{
    public class DeviceServices: IdeviceServices
    {
        private readonly Context Db;
        public DeviceServices(Context _db)
        {
            Db = _db;
        }

        public IEnumerable<DeviceViewModel> AddDevice()
        {
            throw new NotImplementedException();
        }

        public void EditDevice(DeviceViewModel device)
        {
            throw new NotImplementedException();
        }
    }
}
