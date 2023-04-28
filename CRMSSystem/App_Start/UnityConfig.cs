using CRMSSystem.Core.Contracts;
using CRMSSystem.Core.Models;
using CRMSSystem.Service;
using CRMSSystem.Services;
using CRMSSystem.SQL;
using System;

using Unity;

namespace CRMSSystem
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IMRepository<User>, SQLRepository<User>>();

            container.RegisterType<ILoginRepository, LoginRepository>();
            container.RegisterType<ILoginService, LoginService>();

            container.RegisterType<IMRepository<Role>, SQLRepository<Role>>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IRoleRepository, RoleRepository>();

            container.RegisterType<IUserService,UserService>();
            container.RegisterType<IUserRepository, UserRepository>();

            container.RegisterType<IMRepository<UserRole>, SQLRepository<UserRole>>();
           
            container.RegisterType<IMRepository<CommonLookUp>, SQLRepository<CommonLookUp>>();
            container.RegisterType<ICommonLookUpService, CommonLookUpService>();

            container.RegisterType<IMRepository<Forms>, SQLRepository<Forms>>();
            container.RegisterType<IFormService, FormsService>();
            container.RegisterType<IFormRepository, FormsRepository>();

            container.RegisterType<IPermissionRepository, PermissionRepository>();
            container.RegisterType<IPermissionService, PermissionService>();

            container.RegisterType<ITicketRepository, TicketRepository>();
            container.RegisterType<ITicketService, TicketService>();

        }
    }
}