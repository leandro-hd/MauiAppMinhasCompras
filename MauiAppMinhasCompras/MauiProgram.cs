﻿using Android.Content.Res;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;

namespace MauiAppMinhasCompras
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

                Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
                    {
                        h.PlatformView.BackgroundTintList =
                            Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
                    });


#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        
    }
}
