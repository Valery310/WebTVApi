using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebTVApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddWebEncoders(o => {
                o.TextEncoderSettings = new TextEncoderSettings(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic, UnicodeRanges.CyrillicExtendedA, UnicodeRanges.CyrillicExtendedB);
            });
            services.AddSingleton(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



            System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("ru_RU");

        }
    }
}
