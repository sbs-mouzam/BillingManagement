﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.GenericPattern.Interface
{
    public interface IGenericPattern<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Insert(T entity);
        void Delete(int id);
        T GetById(int id);
        void Upate(T entity);
        List<T> GetMultipleTablesDataById(string SQLQuery);
    }
}
