﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using DbMvc.Models.Entity;
namespace DbMvc.Repositories
{
    public class GenericRepository<T> where T: class,new()
    {
        CVEntities db = new CVEntities();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }
        public void Tdelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }
        public T Tget(int id)
        {
            return db.Set<T>().Find();
        }
        public void TUpdate(T p)
        {
            db.SaveChanges();
        }
        public T Find(Expression<Func<T,bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}