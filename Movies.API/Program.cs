using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Movies.API.Commands;
using Movies.API.Handlers;
using Movies.Application.Models;
using Movies.Application.Services.Implementation;
using Movies.Application.Services.Interfaces;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddHttpClient();
builder.Services.AddTransient<IRequestHandler<MovieSearchQuery, List<MovieResponse>>, MovieSearchQueryHandler>();
builder.Services.AddTransient<IMovieSearchService,MovieSearchService>();
builder.Services.AddTransient<ITmdbApiService, TmdbApiService>();
builder.Services.AddTransient<IRequestHandler<AddToWatchlistCommand>, AddToWatchlistCommandHandler>();
//builder.Services.AddTransient<IRequestHandler<MarkAsWatchedCommand>, MarkAsWatchedCommandHandler>();
//builder.Services.AddTransient<IRequestHandler<GetWatchlistItemsQuery, List<WatchlistItemRequest>>, GetWatchlistItemsQueryHandler>();
//builder.Services.Configure<ApiKeyConfiguration>(Configuration.GetSection("ApiKeyConfiguration"));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Title", Version = "v1" });
});
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Title v1");
    c.DocExpansion(DocExpansion.None);
});

app.Run();
