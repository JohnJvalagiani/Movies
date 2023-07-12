using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Movies.API;
using Movies.API.Commands;
using Movies.API.Handlers;
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
using System.Reflection;

   
        var host = CreateHostBuilder(args).Build();

        host.Run();
  
     static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

      


