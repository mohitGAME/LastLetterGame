using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcLastLetter.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;


namespace GrpcLastLetter
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddSingleton<SymSpell>(serviceProvider =>
            {
                // CreateHostBuilder(args).Build().Run();
                //create object
                int initialCapacity = 82765;
                int maxEditDistanceDictionary = 2; //maximum edit distance per dictionary precalculation
                var symSpell = new SymSpell(initialCapacity, maxEditDistanceDictionary);

                //load dictionary
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string dictionaryPath = baseDirectory + "../../../SymSpell/frequency_dictionary_en_82_765.txt";
                int termIndex = 0;  //column of the term in the dictionary text file
                int countIndex = 1; //column of the term frequency in the dictionary text file
                symSpell.LoadDictionary(dictionaryPath, termIndex, countIndex);
                return symSpell;
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ChatService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
