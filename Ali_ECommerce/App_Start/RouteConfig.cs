using System.Web.Mvc;
using System.Web.Routing;

namespace Ali_ECommerce.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Routes for UserBuyer controller
            routes.MapRoute(
                name: "UserBuyerList",
                url: "UserBuyer/List",
                defaults: new { controller = "UserBuyers", action = "List" }
            );

            routes.MapRoute(
                name: "UserBuyerDetails",
                url: "UserBuyer/Details/{id}",
                defaults: new { controller = "UserBuyers", action = "Details" }
            );

            routes.MapRoute(
                name: "UserBuyerCreate",
                url: "UserBuyer/Create",
                defaults: new { controller = "UserBuyers", action = "Create" }
            );

            routes.MapRoute(
                name: "UserBuyerEdit",
                url: "UserBuyer/Edit/{id}",
                defaults: new { controller = "UserBuyers", action = "Edit" }
            );

            routes.MapRoute(
                name: "UserBuyerDelete",
                url: "UserBuyer/Delete/{id}",
                defaults: new { controller = "UserBuyers", action = "Delete" }
            );

            routes.MapRoute(
                name: "UserBuyerNew",
                url: "UserBuyer/New",
                defaults: new { controller = "UserBuyers", action = "New" }
            );

            routes.MapRoute(
                name: "UserBuyerError",
                url: "UserBuyer/Error",
                defaults: new { controller = "UserBuyers", action = "Error" }
            );

            // Routes for UserSeller controller
            routes.MapRoute(
                name: "UserSellerList",
                url: "UserSeller/List",
                defaults: new { controller = "UserSellers", action = "List" }
            );

            routes.MapRoute(
                name: "UserSellerDetails",
                url: "UserSeller/Details/{id}",
                defaults: new { controller = "UserSellers", action = "Details" }
            );

            routes.MapRoute(
                name: "UserSellerCreate",
                url: "UserSeller/Create",
                defaults: new { controller = "UserSellers", action = "Create" }
            );

            routes.MapRoute(
                name: "UserSellerEdit",
                url: "UserSeller/Edit/{id}",
                defaults: new { controller = "UserSellers", action = "Edit" }
            );

            routes.MapRoute(
                name: "UserSellerDelete",
                url: "UserSeller/Delete/{id}",
                defaults: new { controller = "UserSellers", action = "Delete" }
            );

            routes.MapRoute(
                name: "UserSellerNew",
                url: "UserSeller/New",
                defaults: new { controller = "UserSellers", action = "New" }
            );

            routes.MapRoute(
                name: "UserSellerError",
                url: "UserSeller/Error",
                defaults: new { controller = "UserSellers", action = "Error" }
            );

            // Routes for Merchant controller
            routes.MapRoute(
                name: "MerchantList",
                url: "Merchant/List",
                defaults: new { controller = "Merchants", action = "List" }
            );

            routes.MapRoute(
                name: "MerchantDetails",
                url: "Merchant/Details/{id}",
                defaults: new { controller = "Merchants", action = "Details" }
            );

            routes.MapRoute(
                name: "MerchantCreate",
                url: "Merchant/Create",
                defaults: new { controller = "Merchants", action = "Create" }
            );

            routes.MapRoute(
                name: "MerchantEdit",
                url: "Merchant/Edit/{id}",
                defaults: new { controller = "Merchants", action = "Edit" }
            );

            routes.MapRoute(
                name: "MerchantDelete",
                url: "Merchant/Delete/{id}",
                defaults: new { controller = "Merchants", action = "Delete" }
            );

            routes.MapRoute(
                name: "MerchantNew",
                url: "Merchant/New",
                defaults: new { controller = "Merchants", action = "New" }
            );

            routes.MapRoute(
                name: "MerchantError",
                url: "Merchant/Error",
                defaults: new { controller = "Merchants", action = "Error" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        public static void RegisterRoutes()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
