using Microsoft.EntityFrameworkCore;
using SqlSearchQuery.BackroundServices;
using SqlSearchQuery.Models.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DB Context Options
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<SqlSearchQueryContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddHostedService<TimedHostedService>();

//EmailSender
builder.Services.AddTransient<IEmailSender, EmailSender>();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
