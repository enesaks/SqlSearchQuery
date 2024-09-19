using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SqlSearchQuery.Controllers;
using SqlSearchQuery.Models;
using SqlSearchQuery.Models.Context;

namespace SqlSearchQuery.BackroundServices;

public class TimedHostedService : IHostedService
{
    private Timer timer;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public TimedHostedService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        System.Console.WriteLine($"{nameof(TimedHostedService)} service started...");

        timer = new Timer(DeleteService, null, TimeSpan.Zero, TimeSpan.FromHours(1)); // 1 saatte bir çalışıcak

    }

    private async void DeleteService(object state) // Silme işlemi...
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            System.Console.WriteLine("işlem yapıldı" + DateTime.Now.ToString());
            var context = scope.ServiceProvider.GetRequiredService<SqlSearchQueryContext>();
            HomeController homeController = new HomeController(context);
            await homeController.DeleteForever();
            context.SaveChanges();
        }
    }


    public Task StopAsync(CancellationToken cancellationToken)
    {
        System.Console.WriteLine($"{nameof(TimedHostedService)} service stoped...");

        return Task.CompletedTask;
    }
}
