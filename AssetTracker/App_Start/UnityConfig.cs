using System;
using System.Data.Entity;
using AssetTracker.Core.BLL;
using AssetTracker.Core.DAL;
using AssetTracker.Core.Models.EntityModel;
using AssetTracker.Core.Models.Interfaces.IManager;
using AssetTracker.Core.Models.Interfaces.IRepository;
using AssetTracker.Core.Repository;
using Microsoft.Practices.Unity;

namespace AssetTracker
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<DbContext, AssetTrackerContext>();
            
            container.RegisterType<IOrganizationManager, OrganizationManager>();
            container.RegisterType<IOrganizationRepository, OrganizationRepository>();

            container.RegisterType<IOrganizationBranchManager, OrganizationBranchManager>();
            container.RegisterType<IOrganizationBranchRepository, OrganizationBranchRepository>();

            container.RegisterType<IDesignationManager, DesignationManager>();
            container.RegisterType<IDesignationRepository, DesignationRepository>();

            container.RegisterType<IVendorManager, VendorManager>();
            container.RegisterType<IVendorRepository, VendorRepository>();

            container.RegisterType<IDepartmentManager, DepartmentManager>();
            container.RegisterType<IDepartmentRepository, DepartmentRepository>();

            container.RegisterType<IEmployeeManager, EmployeeManager>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();

            container.RegisterType<IGeneralCategoryManager, GeneralCategoryManager>();
            container.RegisterType<IGeneralCategoryRepository, GeneralCategoryRepository>();

            container.RegisterType<ICategoryManager, CategoryManager>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();

            container.RegisterType<ISubCategoryManager, SubCategoryManager>();
            container.RegisterType<ISubCategoryRepository, SubCategoryRepository>();

            container.RegisterType<IDetailCategoryManager, DetailCategoryManager>();
            container.RegisterType<IDetailCategoryRepository, DetailCategoryRepository>();
            
            container.RegisterType<IWarrantyPeriodUnitManager, WarrantyPeriodUnitManager>();
            container.RegisterType<IWarrantyPeriodUnitRepository, WarrantyPeriodUnitRepository>();
            

           
        }
    }
}
