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
        public static List<CourierDTO> Get() //get full list
        {
            var data = DataAccessFactory.CourierData().Get();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Courier, CourierDTO>(); //*** converted using AutoMapper v10.0.0

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<List<CourierDTO>>(data);
        }
        public static CourierDTO Get(int consignmentNo) //get only one by id
        {
            var data = DataAccessFactory.CourierData().Get(consignmentNo);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Courier, CourierDTO>();

            });
            var mapper = new Mapper(cfg);
            return mapper.Map<CourierDTO>(data);
        }

        public static bool Create(CourierDTO courier)
        {

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CourierDTO, Courier>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Courier>(courier);
            var res = DataAccessFactory.CourierData().Create(mapped);
            return (res != null);
        }

        public static bool Update(CourierDTO courier)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<CourierDTO, Courier>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Courier>(courier);
            var res = DataAccessFactory.CourierData().Update(mapped);
            return (res != null) ? true : false;

        }
        public static bool Delete(int consignmentNo)
        {
            return (DataAccessFactory.CourierData().Delete(consignmentNo));
        }
    }
}
