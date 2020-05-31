# PSO2 Thin Launcher
This project is designed to provide an open source launcher that prevents PSO2 NA from launching with the Memory Optimization argument “-optimization”. By preventing the optimizations from being enabled, the constant hitching and lagging experienced while in intense areas such as the Lobby/Gate Area are completely eliminated.

![Screenshot](https://i.imgur.com/xnLxobX.png)

When launching through the Thin Launcher, a system tray icon will be created. Once the game has started the launcher will minimize to the tray. If for any reason the launcher needs to be closed, the tray icon can be right clicked to provide a safe means of properly exiting it.

To provide flexibility in how the launcher is used, a number of launch arguments can be specified:
* --FastLaunch - Skips the interface of the Thin Launcher and immediately launches the game.
* --SkipUpdate - Skips performing a check for updates before launching the game.
* --NotifyExit - Makes a notification popup when the game exits and the launcher detects it to begin exiting itself.
* --SkipNotify - Prevents all notifications from the Thin Launcher from appearing.
* --OutputString - Makes status updates write to STDOUT so that other applications can launch the Thin Launcher and monitor its progress.
