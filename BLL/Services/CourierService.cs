using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CourierService
    {
        public static List<CourierDetailsDTO> Get() //get full list
        {
            var data = DataAccessFactory.CourierData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Courier, CourierDetailsDTO>(); //*** converted using AutoMapper v10.0.0
                c.CreateMap<CustomerInfo, CustomerInfoDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<CourierDetailsDTO>>(data);
        }
        public static CourierDetailsDTO Get(int consignmentNo) //get only one by id
        {
            var data = DataAccessFactory.CourierData().Get(consignmentNo);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Courier, CourierDetailsDTO>();
                c.CreateMap<CustomerInfo, CustomerInfoDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<CourierDetailsDTO>(data);
        }

        public static bool Create(CourierDetailsDTO courier)
        {
            var courierData = new Courier
            {
                ParcelType = courier.ParcelType,
                Weight = courier.Weight,
                ShippingCost = courier.ShippingCost,
                PlacingDate = DateTime.Now,
                CurrentLocation = courier.CurrentLocation,
                FromLocation = courier.FromLocation,
                Destination = courier.Destination,
                ETA = courier.ETA,
                Status = "Processing"
            };
            var res1 = DataAccessFactory.CourierData().Create(courierData);

            var customerData = new CustomerInfo
            {
                ConsignmentNo = res1.ConsignmentNo,
                SenderName = courier.CustomerInfo.SenderName,
                SenderMobile = courier.CustomerInfo.SenderMobile,
                SenderAddress = courier.CustomerInfo.SenderAddress,
                ReceiverName = courier.CustomerInfo.ReceiverName,
                ReceiverMobile = courier.CustomerInfo.ReceiverMobile,
                ReceiverAddress = courier.CustomerInfo.ReceiverAddress,
            };
            var res2 = DataAccessFactory.CustomerInfoData().Create(customerData);

            return (res1 != null && res2 != null);
        }

        public static bool Update(CourierDetailsDTO courier)
        {
            var courierData = new Courier
            {
                ConsignmentNo = courier.ConsignmentNo,
                ParcelType = courier.ParcelType,
                Weight = courier.Weight,
                ShippingCost = courier.ShippingCost,
                PlacingDate = courier.PlacingDate,
                DeliveryDate = courier.DeliveryDate,
                CurrentLocation = courier.CurrentLocation,
                FromLocation = courier.FromLocation,
                Destination = courier.Destination,
                ETA = courier.ETA,
                Status = courier.Status,
            };
            var res1 = DataAccessFactory.CourierData().Update(courierData);

            var customerData = new CustomerInfo
            {
                ConsignmentNo = courier.ConsignmentNo,
                SenderName = courier.CustomerInfo.SenderName,
                SenderMobile = courier.CustomerInfo.SenderMobile,
                SenderAddress = courier.CustomerInfo.SenderAddress,
                ReceiverName = courier.CustomerInfo.ReceiverName,
                ReceiverMobile = courier.CustomerInfo.ReceiverMobile,
                ReceiverAddress = courier.CustomerInfo.ReceiverAddress,
            };
            var res2 = DataAccessFactory.CustomerInfoData().Update(customerData);

            return (res1 != null && res2 != null);

        }
        public static bool Delete(int consignmentNo)
        {
            var res1 = DataAccessFactory.CustomerInfoData().Delete(consignmentNo);
            var res2 = DataAccessFactory.CourierData().Delete(consignmentNo);
            return (res1 && res2);
        }


        public static bool CourierShipped(int consignmentNo)
        {
            var existing = DataAccessFactory.CourierData().Get(consignmentNo);
            existing.Status = "On the way";
            var res = DataAccessFactory.CourierData().Update(existing);
            return (res != null) ? true : false;
        } 
        
        public static bool CourierDelivered(int consignmentNo)
        {
            var existing = DataAccessFactory.CourierData().Get(consignmentNo);
            existing.DeliveryDate = DateTime.Now;
            existing.Status = "Delivered";
            var res = DataAccessFactory.CourierData().Update(existing);
            return (res != null) ? true : false;
        }

        public static bool CourierReceivedBy(int consignmentNo, string hubLocation)//for changing current location (such as hubs)
        {
            var existing = DataAccessFactory.CourierData().Get(consignmentNo);
            existing.CurrentLocation = hubLocation;
            var res = DataAccessFactory.CourierData().Update(existing);
            return (res != null) ? true : false;
        }



    }
}
