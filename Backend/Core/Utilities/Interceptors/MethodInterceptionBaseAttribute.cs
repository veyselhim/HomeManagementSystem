using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    // Attribute class ve methodlarda kullanılabilsin , birden çok kullanıma izin verilsin ve inherit edilen sınıflarda da kullanılabilisin dedij.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }  // Attribute önceliği

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
