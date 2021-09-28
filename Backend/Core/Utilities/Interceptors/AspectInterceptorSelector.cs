using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Business.DependencyResolvers.Autofac
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //class ve method attributeları bulma ve listeye aktarma işlemi.
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>  
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
           // classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

            //çalışma sırasını öncelik değerine göre sırala.
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
