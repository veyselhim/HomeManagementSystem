using System;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.Mapper.AutoMapper.Profiles;
using Castle.DynamicProxy;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete;
using Entity.DTOs.Aparment;
using Microsoft.AspNetCore.Http;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        // Uygulama ayağa kalktığında Load çalışır.
        protected override void Load(ContainerBuilder builder)
        {  

            builder.RegisterType<ApartmentManager>().As<IApartmentService>().InstancePerLifetimeScope();
            builder.RegisterType<DuesManager>().As<IDuesService>().InstancePerLifetimeScope();
            builder.RegisterType<DuesPaymentManager>().As<IDuesPaymentService>().InstancePerLifetimeScope();
            builder.RegisterType<MessageManager>().As<IMessageService>().InstancePerLifetimeScope();
            builder.RegisterType<BillManager>().As<IBillService>().InstancePerLifetimeScope();
            builder.RegisterType<BillPaymentManager>().As<IBillPaymentService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthManager>().As<IAuthService>().InstancePerLifetimeScope();
            builder.RegisterType<UserManager>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().InstancePerLifetimeScope();
            builder.RegisterType<CardMongoDbManager>().As<ICardMongoDbService>().InstancePerLifetimeScope();


            builder.RegisterType<JwtHelper>().As<ITokenHelper>().InstancePerLifetimeScope();


            builder.RegisterType<EfUserDal>().As<IUserDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfApartmentDal>().As<IApartmentDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfMessageDal>().As<IMessageDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfDuesDal>().As<IDuesDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfDuesPaymentDal>().As<IDuesPaymentDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfBillDal>().As<IBillDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfBillPayment>().As<IBillPaymentDal>().InstancePerLifetimeScope();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().InstancePerLifetimeScope();
            builder.RegisterType<CardMongoDbDal>().As<ICardMongoDbDal>().InstancePerLifetimeScope();


            //AutoMapper registering
            builder.RegisterAutoMapper(Assembly.GetExecutingAssembly());


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            //çalışan uygulama içerisinde interfaceleri bul ve AspectInterceptorları çağır.

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).InstancePerLifetimeScope();

        }
    }
}
