/*
Awesome Media Player

https://github.com/BluDay/awesome-media-player-winui3

MIT License

Copyright (c) 2024 BluDay

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

ServiceCollection services = new();

services
    .AddSingleton<AppActivationService>()
    .AddSingleton<AppDialogService>()
    .AddSingleton<AppNavigationService>()
    .AddSingleton<AppThemeService>()
    .AddSingleton<AppWindowService>();

services
    .AddSingleton<ImplementationProvider<IBluWindow>>();

services
    .AddSingleton(WeakReferenceMessenger.Default);

services
    .AddSingleton<App>()
    .AddSingleton<ResourceLoader>();

services
    .AddScoped(_ => DispatcherQueue.GetForCurrentThread());

services
    .AddScoped<ShellViewModel>();

services
    .AddViewModels();

services
    .AddTransient<Shell>();

services
    .AddTransient<MainView>()
    .AddTransient<SettingsView>();

services
    .AddLogging(loggingBuilder =>
    {
        loggingBuilder
            .AddConsole()
            .AddDebug()
            .SetMinimumLevel(LogLevel.Debug);
    });

IServiceProvider serviceProvider = services.BuildServiceProvider();

serviceProvider.CreateWinui3App<App>();