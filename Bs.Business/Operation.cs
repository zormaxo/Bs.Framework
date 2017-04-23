using Bs.Data.Context;
using Bs.Utility;
using System;
using System.Data.Entity;
using System.Runtime.CompilerServices;

namespace Bs.Data
{
    public abstract class Operation<TEntity> where TEntity : class
    {
        protected readonly BsContext dbContext;
        protected BsOpResult<TEntity> opResult;
        protected BsRepository genericRepository;

        protected Operation()
        {
            dbContext = new BsContext();
            dbContext.Database.Log = BsLogger.LogInfo;
            genericRepository = new BsRepository(dbContext);
        }

        public BsOpResult<TEntity> Execute([CallerMemberName] string metod = "", [CallerLineNumber] int satir = -1)
        {
            BsLogger.LogInfo(string.Format("Caller Method: {0}, Line: {1}", metod, satir));
            opResult = new BsOpResult<TEntity>();
            opResult.IsSuccess = true;
            try
            {
                DoJob();
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                BsLogger.LogException(ex, ex.GetType().Name);

                opResult.IsSuccess = false;
                opResult.ErrorInfo = new BsOpError();
                opResult.ErrorInfo.ErrorMessage = ex.Message;
            }
            finally
            {
                dbContext.Dispose();
            }
            return opResult;
        }

        protected abstract void DoJob();
    }

}