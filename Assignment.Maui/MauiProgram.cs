using Assignment.Maui.ViewModels;
using Business.Interface;
using Business.Services;
using Microsoft.Extensions.Logging;

namespace Assignment.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<AddContactViewModel>();
            builder.Services.AddSingleton<IFileService, FileService>();
            builder.Services.AddSingleton<IContactService, ContactService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
