using Hangfire;
using IESolution;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace IESolution
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("HangireConnection");
            app.UseHangfireDashboard();
            app.UseHangfireServer();
            // #if !DEBUG
            ////run background job
            //RecurringJob.AddOrUpdate(() => BackgroundJob.BackgroundJob.CreateOrder(), Cron.Minutely);
            //#endif
        }
    }
}
