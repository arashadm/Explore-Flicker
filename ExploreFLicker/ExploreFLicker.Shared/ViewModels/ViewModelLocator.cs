﻿
using Autofac;
using Autofac.Features.OwnedInstances;
using ExploreFlicker.Helpers;
using ExploreFlicker.Helpers.Interfaces;


#pragma warning disable 4014

namespace ExploreFlicker.Viewmodels
{
    public class ViewModelLocator
    {
        /// <summary>
        /// This container will be used internaly to resolve registered intances
        /// </summary>
        private static readonly IContainer Container;

        /// <summary>
        /// Register all required types in this static constructor,
        /// This will be executed the first time ViewModelLocator is accessed in code
        /// </summary>
        static ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            #region DataServices and Helpers

            builder.RegisterType<ViewModelLocator>().SingleInstance();
            builder.RegisterType<NetworkHelper>().SingleInstance();
            builder.Register<INetworkHelper>(c => c.Resolve<NetworkHelper>());
            builder.RegisterType<ToastService>().SingleInstance();
            builder.Register<IToastService>(c => c.Resolve<ToastService>());

            //Register navigation Service
            builder.RegisterType<NavigationService>().SingleInstance().
                OnActivating(service =>
                {
                    //Here before the first request to Navigation Service is completed
                    //We will register the mapping between viewmodels and views
                    //This mapping will be used in navigation

                });
            builder.Register<INavigationService>(c => c.Resolve<NavigationService>());

            //Database Registerations
            #endregion

            #region ViewModels registeration

            #endregion

            Container = builder.Build();
        }

        #region data Services and Helpers Properties


        public IToastService ToastService
        {
            get { return Container.Resolve<IToastService>(); }
        }

        #endregion

        #region View Models Properties



        #endregion

        /// <summary>
        ///Create instance in App.xaml resources so you can use it in data binding in all xaml pages
        ///And don't forget to set this instance from App.xaml.cs, So you can access it from code behind in pages(if required)
        /// </summary>
        public static ViewModelLocator Locator { set; get; }

    }
}