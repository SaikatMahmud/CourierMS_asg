using AutoMapper;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTOs;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string Username, string Password)
        {
            var res = DataAccessFactory.AuthData().Authenticate(Username, Password); //true if uname & pass matched,
                                                                                     //then generate token and return the token to the user

            if (res == true)
            {
                var allTkn = DataAccessFactory.TokenData().Get();
                var exTkn = (from t in allTkn
                             where t.CreatedBy.Equals(Username) &&
                             t.ExpiredAt == null
                             select t).SingleOrDefault();
                if (exTkn != null) //if the user already has a token, return the token
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(exTkn);
                }
                else //create new one
                {
                    var token = new Token();
                    token.CreatedBy = Username;
                    token.CreatedAt = DateTime.Now;
                    token.TKey = Guid.NewGuid().ToString();
                    var ret = DataAccessFactory.TokenData().Create(token);
                    if (ret != null)
                    {
                        var cfg = new MapperConfiguration(c =>
                        {
                            c.CreateMap<Token, TokenDTO>();
                        });
                        var mapper = new Mapper(cfg);
                        return mapper.Map<TokenDTO>(ret);
                    }
                }
            }
            return null;
        }
        public static TokenDTO IsTokenValid(string tkey)//return token obj
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);
            if (extk != null && extk.ExpiredAt == null)
            {
                var cfg = new MapperConfiguration(c =>
                {
                    c.CreateMap<Token, TokenDTO>();
                });
                var mapper = new Mapper(cfg);
                return mapper.Map<TokenDTO>(extk);
            }
            return null;
        }
        public static string TokenUserType(string tkey)//return token User type
        {
            var token = IsTokenValid(tkey);
            if (token != null)
            {
                var user = DataAccessFactory.UserData().Get(token.CreatedBy);
                return user.UserType.ToString();
            }
            return null;
        }
        public static bool Logout(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Get(tkey);
            extk.ExpiredAt = DateTime.Now;
            if (DataAccessFactory.TokenData().Update(extk) != null) return true;
            return false;

        }
    }
}
