using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Movies.API.Commands;
using Movies.API.Handlers;
using Movies.API.Middlewares;
using Movies.API.PipelineBehaviors;
using Movies.API.Query;
using Movies.Application.Models;
using Movies.Application.Profiles;
using Movies.Application.Services.Implementation;
using Movies.Application.Services.Interfaces;
using Movies.Infrastructure.Models;
using Movies.Infrastructure.Services.DataAccess.Implementation;
using Movies.Infrastructure.Services.DataAccess.Interfaces;
using Movies.Persistence.Data;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Movies.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection Services)
        {
            Services.AddControllers();
            Services.AddMediatR(typeof(Program).Assembly);
            Services.AddHttpClient();
            Services.AddTransient<IMovieSearchService, MovieSearchService>();
            Services.AddTransient<IMovieWatchlistService, MovieWatchlistService>();
            Services.AddTransient<IWatchlistRepository, WatchlistRepository>();
            Services.AddTransient<ITmdbApiService, TmdbApiService>();
            Services.AddTransient<IRequestHandler<MovieSearchCommand, List<MovieResponse>>, MovieSearchQueryHandler>();
            Services.AddTransient<IRequestHandler<AddMovieToWatchlistCommand, WatchlistItemResponse>, AddToWatchlistCommandHandler>();
            Services.AddTransient<IRequestHandler<MarkAsWatchedCommand, WatchlistItemResponse>, MarkAsWatchedCommandHandler>();
            Services.AddTransient<IRequestHandler<GetWatchlistItemsQuery, List<WatchlistItemResponse>>, GetWatchlistItemsQueryHandler>();
            Services.Configure<ApiKeyConfiguration>(Configuration.GetSection("ApiKeyConfiguration"));
            Services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            Services.AddValidatorsFromAssembly(typeof(Startup).Assembly);
            Services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
            Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Title", Version = "v1" });
            });
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MovieProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            Services.AddSingleton(mapper);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", " API V1");
            });


            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           
           
        }
    }
}
