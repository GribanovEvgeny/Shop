using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data.Interfaces;
using Shop.Data.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop
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
			services.AddTransient<IProductService, MockProduct>();   // связь интерфеса с mock-файлом
			services.AddTransient<ICategoryService, MockCategory>();   // связь интерфеса с mock-файлом
			services.AddRazorPages();
			//services.AddMvc();   // подключение mvc
			services.AddMvc(option => option.EnableEndpointRouting = false);   // чтоб UseMvcWithDefaultRoute не ругался
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseDeveloperExceptionPage();   // включение отображения ошибок
			app.UseStatusCodePages();   // отображение кодов страниц (500, 404...)
			app.UseStaticFiles();   // отображение статических файлов
			app.UseMvcWithDefaultRoute();   // для отображения url по умолчанию
		}
	}
}
