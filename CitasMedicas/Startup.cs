using System.Text.Json.Serialization;
using CitasMedicas.Filtros;
using CitasMedicas.Middlewares;
using CitasMedicas.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace CitasMedicas

{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(opciones =>
            {
                opciones.Filters.Add(typeof(FiltroDeExcepcion));
            }).AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            services.AddTransient<IService, ServiceB>();

            services.AddTransient<ServiceTransient>();

            services.AddScoped<ServiceScoped>();

            services.AddSingleton<ServiceSingleton>();
            
            services.AddTransient<FiltroDeAccion>();
            
            services.AddHostedService<EscribirEnArchivo>();
            
            services.AddResponseCaching();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CitasMedicas", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseHttpMiddleware();
            
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseResponseCaching();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
