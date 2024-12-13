using Business.Interface;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using PresentationMainApp.Services;

var serviceProvider = new ServiceCollection()
    .AddSingleton<IFileService, FileService>()
    .AddSingleton<IContactService, ContactService>()
    .AddSingleton<IMenuService, MenuService>()
    .BuildServiceProvider();

var menuService = serviceProvider.GetService<IMenuService>();

menuService.MainMenu();