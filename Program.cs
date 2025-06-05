/**
 * Awesome Media Player
 * 
 * https://github.com/bluday/awesome-media-player
 * 
 * Copyright (c) 2025 BluDay
 */

await new ServiceCollection()
    .Add(App.ConfigureServices)
    .BuildServiceProvider()
    .CreateWinui3AppAsync<App>();