using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : DBRepo, IRepo<Token, string, Token>
    {
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public Token Get(string tkey)
        {
            return db.Tokens.FirstOrDefault(t => t.TKey.Equals(tkey));
        }

        public Token Update(Token obj)
        {
            var exToken = Get(obj.TKey);
            db.Entry(exToken).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
