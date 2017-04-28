using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Reflection; // add this for assembly
using Autofac; // add
using Autofac.Integration.Mvc; // add for Autofac

namespace HelloWorld
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RegisterAutofac();//as application starts Autofac gets called
        }

        //Autofac Registeration
        private void RegisterAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsSelf().AsImplementedInterfaces();

            //builder.RegisterType<ContactRepository>().As<IContactRepository>();

            var container = builder.Build();

            // Configure dependency resolver.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        protected void xxApplication_Error() // do xx before doing Cookie
        {
            var exception = Server.GetLastError();
            Server.ClearError();
            var routeData = new RouteData();
            routeData.Values.Add("controller", "Error"); // modify me
            routeData.Values.Add("action", "Error");

            IController errorController = new Controllers.ErrorController(); //modify me
            errorController.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));
        }

    }
}
