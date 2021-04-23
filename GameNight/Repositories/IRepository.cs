﻿using GameNight.Extensions;
using GameNight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameNight.Repositories
{
    public interface IRepository<T> : ISelectList, IAccount, IUtility where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T obj);
        void Delete(T obj);
        void Update(T obj);
    }
}
