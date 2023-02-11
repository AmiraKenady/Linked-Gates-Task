using DB;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
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

        public Device AddDevice(DeviceViewModel deviceModel)
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
            return device;

        }

        public void AddDeviceProp(List<PropertiesValuesViewModel> propertiesValuesViewModels, int DeviceId)
        {
            List<PropertiesValues> properties = new List<PropertiesValues>();
            foreach (var item in propertiesValuesViewModels)
            {
                PropertiesValues propertiesValues = new PropertiesValues()
                {
                    DeviceId = DeviceId,
                    PropertyId = item.propertyId,
                    Values = item.value
                };
                properties.Add(propertiesValues);
            }
            Db.PropertiesValues.AddRange(properties);
            Db.SaveChanges();
        }
        public void AddDeviceAndProprty(DeviceViewModel deviceModel)
        {
            var DeviceAdded = AddDevice(deviceModel);
            var devicid = DeviceAdded.Id;
            AddDeviceProp(deviceModel.Properties, devicid);
        }

        public List<Device> GetDevices()
        {
            var Devices = Db.device.ToList();

            return Devices;

        }

        public void EditDevice(DeviceViewModel deviceModel)
        {
            var editedDevice = Db.device.Where(d => d.Id == deviceModel.Id).FirstOrDefault();
            editedDevice.Name = deviceModel.DeviceName;
            editedDevice.AcquisitionDate = deviceModel.DeviceAcquisitionDate;
            editedDevice.Memo = deviceModel.DeviceMemo;

            Db.SaveChanges();
        }
    }
}
