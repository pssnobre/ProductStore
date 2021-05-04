﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ProductStore.Repository
{
    public abstract class AbstractRepository<TEntity, TKey> where TEntity : class
    {
        protected string StringConnection { get; } = WebConfigurationManager.ConnectionStrings["PRODUTOSTORE"].ConnectionString;

        public abstract List<TEntity> GetAll();
        public abstract TEntity GetById(TKey id);
        public abstract void Save(TEntity entity);
        public abstract void Update(TEntity entity);
        public abstract void Delete(TEntity entity);
        public abstract void DeleteById(TKey id);
    }
}