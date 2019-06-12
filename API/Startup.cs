using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.UsersCommands;
using Application.Commands.CitiesCommands;
using EFCommands.UserCommands;
using EFDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using EFCommands.CityCommands;
using Application.Commands.RolesCommands;
using EFCommands.RoleCommands;
using EFCommands.ActorCommands;
using Application.Commands.ActorsCommands;
using Application.Commands.CategoriesCommands;
using EFCommands.CategoryCommands;
using Application.Commands.CommentsCommands;
using EFCommands.CommentCommands;
using Application.Commands.ShowCommands;
using EFCommands.ShowCommands;

namespace API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<TVShowsContext>();
            
            //users

            services.AddTransient<IAddUserCommand, EFAddUserCommand>();
            services.AddTransient<IGetUserCommand, EFGetUserCommand>();
            services.AddTransient<IGetUsersCommand, EFGetUsersCommand>();
            services.AddTransient<IEditUserCommand, EFEditUserCommand>();
            services.AddTransient<IDeleteUserCommand, EFDeleteUserCommand>();
            
            //cities
            
            services.AddTransient<IGetCitiesCommand, EFGetCitiesCommand>();
            services.AddTransient<IAddCityCommand, EFAddCityCommand>();
            services.AddTransient<IGetCityCommand, EFGetCityCommand>();
            services.AddTransient<IDeleteCItyCommand, EFDeleteCityCommand>();
            services.AddTransient<IEditCityCommand, EFEditCityCommand>();

            //roles

            services.AddTransient<IGetRolesCommand, EFGetRolesCommand>();
            services.AddTransient<IGetRoleCommand, EFGetRoleCommand>();
            services.AddTransient<IAddRoleCommand, EFAddRoleCommand>();
            services.AddTransient<IEditRoleCommand, EFEditRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EFDeleteRoleCommand>();

            //actors

            services.AddTransient<IAddActorCommand, EFAddActorCommand>();
            services.AddTransient<IGetActorsCommand, EFGetActorsCommand>();
            services.AddTransient<IGetActorCommand, EFGetActorCommand>();
            services.AddTransient<IEditActorCommand, EFEditActorCommand>();            
            services.AddTransient<IDeleteActorCommand, EFDeleteActorCommand>();

            //categories

            services.AddTransient<IGetCategoriesCommand, EFGetCategoriesCommand>();
            services.AddTransient<IGetCategoryCommand, EFGetCategoryCommand>();
            services.AddTransient<IAddCategoryCommand, EFAddCategoryCommand>();
            services.AddTransient<IEditCategoryCommand, EFEditCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EFDeleteCategoryCommand>();

            //comments

            services.AddTransient<IGetCommentsCommand, EFGetCommentsCommand>();
            services.AddTransient<IGetCommentCommand, EFGetCommentCommand>();
            services.AddTransient<IAddCommentCommand, EFAddCommentCommand>();
            services.AddTransient<IEditCommentCommand, EFEditCommentCommand>();
            services.AddTransient<IDeleteCommentCommand, EFDeleteCommentCommand>();

            //shows

            services.AddTransient<IAddShowCommand, EFAddShowCommands>();
            services.AddTransient<IEditShowCommand, EFEditShowCommand>();
            services.AddTransient<IGetShowCommand, EFGetShowCommand>();
            services.AddTransient<IGetShowsCommand, EFGetShowsCommand>();
            services.AddTransient<IDeleteShowCommand, EFDeleteShowCommand>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
