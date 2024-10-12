//		Отче наш, Иже еси на небесех! 
//		Да святится имя Твое, 
//		да приидет Царствие Твое, 
//		да будет воля Твоя, 
//		яко на небеси и на земли. 
//		Хлеб наш насущный даждь нам днесь; 
//		и остави нам долги наша, якоже и мы оставляем должником нашим; 
//		и не введи нас во искушение,
//		но избави нас от лукаваго.
//		Ибо Твое есть Царство и сила и слава во веки.
//		Аминь.
//                       .-=====-.
//                       | .""". |
//                       | |   | |
//                       | |   | |
//                       | '---' |
//                       |       |
//                       |       |
//    .-================-'       '-================-.
//    |  _                                          |
//    |.'o\                                    __   |
//    | '-.'.                                .'o.`  |
//    '-==='.'.=========-.       .-========.'.-'===-'
//           '.`'._    .===,     |     _.-' /
//             '._ '-./  ,//\   _| _.-'  _.'
//                '-.| ,//'  \-'  `   .-'
//                   `//'_`--;    ;.-'
//                     `\._ ;|    |
//                        \`-'  . |
//						  |_.-'-._|
//                        \  _'_  /
//                        |; -:- |
//						  || -.- \
//						  |;     .\
//					     / `'\'`\-;
//					    ;`   '. `_/
//					    |,`-._;  .;
//                      `;\  `.-'-;
//						 | \   \  |
//						 |  `\  \ |
//						 |   )  | |
//						 |  /  /` /
//						 | |  /|  |
//						 | | / | /
//						 | / |/ /|
//						 | \ / / |
//						 |  /o | |
//						 |  |_/  |
//						 |       |
//						 |       |
//						 |       |
//						 |       |
//						 |       |
//						 |       |
//						 |       |
//						 '-=====-'


using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiKlinic.Client.Pages;
using MiKlinic.Components;
using MiKlinic.Components.Account;
using MiKlinic.Data;

namespace MiKlinic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddScoped<IdentityUserAccessor>();
            builder.Services.AddScoped<IdentityRedirectManager>();
            builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

            builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = IdentityConstants.ApplicationScheme;
                    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
                })
                .AddIdentityCookies();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            // Add additional endpoints required by the Identity /Account Razor components.
            app.MapAdditionalIdentityEndpoints();

            app.Run();
        }
    }
}
