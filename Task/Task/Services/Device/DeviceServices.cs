using DB;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Services
{
    public class DeviceServices: IdeviceServices
    {
        private readonly Context Db;
        public DeviceServices(Context _db)
        {
            Db = _db;
        }

        public void AddDevice(DeviceViewModel deviceModel)
        {   
            Device device = new Device()
            {
                Name = deviceModel.DeviceName,
                AcquisitionDate = deviceModel.DeviceAcquisitionDate,
                Memo = deviceModel.DeviceMemo,
                CategoryId = deviceModel.CategoryId,  
            };
            Db.device.Add(device);
            Db.SaveChanges();

        }

        public IEnumerable<DeviceViewModel> GetDevices()
        {
            var Devices = Db.device.Select(d => new DeviceViewModel()
            {
                DeviceName= d.Name,
                DeviceMemo= d.Memo,
                DeviceAcquisitionDate= d.AcquisitionDate,
                CategoryId= d.CategoryId
            });

            return Devices;

        }
    }
}
