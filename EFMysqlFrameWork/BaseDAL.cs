using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace EFMysqlFrameWork
{
    public class BaseDAL<TEntity> where TEntity : class
    {
        //1.0  实例化EF上下文 
        DbContext db = DBContextFactory.GetDbContext();

        //2.0 定义DbSet<T> 对象
        public DbSet<TEntity> _dbset;

        //3.0 在构造函数的初始化_dbset
        public BaseDAL()
        {
            _dbset = db.Set<TEntity>();
        }


        #region 1.0 增

        public virtual void Add(TEntity model)
        {
            //1.0 参数合法性验证
            if (model == null)
            {
                throw new Exception("BaseRepository泛型类中，新增操作的实体不能为空");
            }


            //2.0 进行新增操作 
            _dbset.Add(model);
        }


        #endregion

        #region 2.0 删

        public virtual void Delete(TEntity model)
        {
            //1.0 参数合法性验证
            if (model == null)
            {
                throw new Exception("BaseRepository泛型类中，删除操作的实体不能为空");
            }
            _dbset.Attach(model);
            _dbset.Remove(model);
        }


        #endregion

        #region 3.0 改

        /// <summary>
        /// 编辑，约定model 是一个自定义的实体，没有追加到EF容器中的
        /// </summary>
        /// <param name="model"></param>
        public virtual void Edit(TEntity model, string[] propertyNames)
        {
            //0.0 关闭EF的实体属性合法性检查
            db.Configuration.ValidateOnSaveEnabled = false;

            //1.0 参数合法性验证
            if (model == null)
            {
                throw new Exception("BaseRepository泛型类中，编辑操作的实体不能为空");
            }

            if (propertyNames == null || propertyNames.Length == 0)
            {
                throw new Exception("BaseRepository泛型类中，编辑操作的属性数组必须至少有一个值");
            }

            //2.0 将model追加到EF容器中的
            DbEntityEntry entry = db.Entry(model);
            entry.State = EntityState.Unchanged;

            foreach (var item in propertyNames)
            {
                entry.Property(item).IsModified = true;
            }
        }

        #endregion

        #region 4.0 查

        /// <summary>
        /// 带条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public virtual List<TEntity> QueryWhere(Expression<Func<TEntity, bool>> where)
        {
            return _dbset.Where(where).ToList();
        }
        #endregion


        #region 5.0 统一保存

        /// <summary>
        /// 统一将EF容器对象中的所有代理类生成相应的sql语句发给db服务器执行
        /// </summary>
        /// <returns></returns>
        public virtual int SaveChanges()
        {
            try
            {
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


    }
}
