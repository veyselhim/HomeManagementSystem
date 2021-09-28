using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Business.DependencyResolvers.Autofac
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);  //Method çağırılmadan önce
            try
            {
                invocation.Proceed();  //çalıştır
            }
            catch (Exception e) //Hata alırsa
            {
                isSuccess = false;
                OnException(invocation, e); //exception fırlat
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation); //success
                }
            }
            OnAfter(invocation);
        }
    }
}
