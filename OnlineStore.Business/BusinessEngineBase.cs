using OnlineStore.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business
{
    public class BusinessEngineBase
    {
        public IConfigurationHelper ConfigurationHelper;
        private readonly ILogger _logger;

        public BusinessEngineBase()
        {
            // TODO: DI Framework eklendikden sonra bu field initialize edilecek..
        }

        protected T ExecuteWithExceptionHandledOperation<T>(Func<T> func)
        {
            try
            {
                var result = func.Invoke();

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);

                throw;
            }
        }

        protected void ExecuteWithExceptionHandledOperation<T>(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);

                throw;
            }
        }
    }
}
