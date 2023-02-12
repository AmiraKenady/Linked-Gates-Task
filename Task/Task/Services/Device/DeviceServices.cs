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
        //public DeviceViewModel GetDeviceById(int id)
        //{
        //    var device = Db.device.Where(d => d.Id == id).Select(d => new DeviceViewModel()
        //    {
        //        DeviceName = d.Name,
        //        DeviceAcquisitionDate = d.AcquisitionDate,
        //        DeviceMemo = d.Memo,
        //        CategoryId = d.CategoryId,

        //    }).FirstOrDefault();
        //    Db.SaveChanges();
        //    return device;

        //}
        public Device GetDeviceById(int id)
        {
            var device = Db.device.Where(d => d.Id == id).FirstOrDefault();
            
            return device;

        }
        public List<PropertiesValues> GetPropertyByDeviceId(int Deviceid)
        {

            var properties = Db.PropertiesValues.Where(d => d.DeviceId == Deviceid).ToList();

            return properties;
        }

        public DeviceViewModel EditDevice(DeviceViewModel deviceModel)
        {
            var editedDevice = GetDeviceById(deviceModel.Id);

            editedDevice.Name = deviceModel.DeviceName;
            editedDevice.Memo = deviceModel.DeviceMemo;
            editedDevice.AcquisitionDate = deviceModel.DeviceAcquisitionDate;
            editedDevice.CategoryId= deviceModel.CategoryId;
            
            Db.device.Update(editedDevice);
            Db.SaveChanges();
            return deviceModel;
        }
          
        public List<PropertiesValues> EditDeviceProp(List<PropertiesValuesViewModel> propertiesValuesViewModels, int DeviceId)
        {
            var properties = GetPropertyByDeviceId(DeviceId);
            foreach(var item in propertiesValuesViewModels)
            {
                foreach(var a in properties)
                {
                    a.PropertyId = item.propertyId;
                    //a.DeviceId = DeviceId;
                    a.Values = item.value;
                }
               
            };
            Db.PropertiesValues.UpdateRange(properties);
            Db.SaveChanges();
            return properties;


        }
        public DeviceViewModel EditDeviceAndProprty(DeviceViewModel deviceModel)
        {

            var EditedDevice = EditDevice(deviceModel);
            var devicid = EditedDevice.Id;
            EditDeviceProp(deviceModel.Properties, devicid);
            return EditedDevice;
        }
    }
}
