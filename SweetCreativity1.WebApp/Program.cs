using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SweetCreativity.Reposotories.Interfaces;
using SweetCreativity.Reposotories.Repos;
using SweetCreativity1.Core.Context;
using SweetCreativity1.Core.Entities;
using SweetCreativity1.Reposotories.Interfaces;
using SweetCreativity1.Reposotories.Repos;
using SweetCreativity1.WebApp.ChatHub;
//using SweetCreativity1.WebApp.Hubs;
//[assembly: OwinStartup(typeof(SweetCreativity1.Startup))]

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SweetCreativity1Connection") ?? throw new InvalidOperationException("Connection string 'SweetCreativity1Connection' not found.");
builder.Services.AddDbContext<SweetCreativity1Context>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<User>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    //options.Password.RequiredLength = 4;
}).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SweetCreativity1Context>();

//builder.Services.AddSingleton<UserManager<User>>();
builder.Services.AddScoped<IListingReposotory, ListingReposotory>();
builder.Services.AddScoped<IUserReposotory, UserReposotory>();
builder.Services.AddScoped<IOrderReposotory, OrderReposotory>();
builder.Services.AddScoped<IConstructionReposotory, ConstructionReposotory>();
builder.Services.AddScoped<IFavoriteReposotory, FavoriteReposotory>();
builder.Services.AddScoped<IEventReposotory, EventReposotory>();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//builder.Services.AddScoped<IChatMessageReposotory, ChatMessageReposotory>();
//?
builder.Services.AddFluentValidationAutoValidation();
// enable client-side validation
builder.Services.AddFluentValidationClientsideAdapters();
// Load an assembly reference rather than using a marker type.
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSignalR();//?
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "ConfirmDelete",
//    pattern: "{controller=Listing}/{action=DeleteConfirmed}/{id?}",
//    defaults: new { controller = "Listing", action = "DeleteConfirmed" }
//);

//app.MapControllerRoute(
//    name: "Analitic",
//    pattern: "/user/analitic",
//    defaults: new { controller = "User", action = "Analitic" });


//app.MapControllerRoute(
//    name: "MyListings",
//    pattern: "/listing/mylistings",
//    defaults: new { controller = "Listing", action = "MyListings" });

//app.MapControllerRoute(
//    name: "Favorite",
//    pattern: "/favorite/index",
//    defaults: new { controller = "Favorite", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
        name: "favorites",
        pattern: "{controller=Favorite}/{action=RemoveFromFavorites}/{id?}");

app.MapRazorPages();

//app.MapHub<ChatHub>("/chatHub");
//app.MapHub<ChatHub>("/chatHub");
//app.MapSignalR();
app.Run();