# PSO2 Thin Launcher
This project was originally designed to provide an open source launcher that prevents PSO2 NA from launching with the Memory Optimization argument “-optimize”. By preventing the optimizations from being enabled, the constant hitching and lagging experienced while in intense areas such as the Lobby/Gate Area are completely eliminated. Since these optimizations have been resolved this launcher now works as a method to launch the game directly instead of going through the official launcher each time.

![Screenshot](https://i.imgur.com/xnLxobX.png)

When launching through the Thin Launcher, a system tray icon will be created. Once the game has started the launcher will minimize to the tray. If for any reason the launcher needs to be closed, the tray icon can be right clicked to provide a safe means of properly exiting it.

To provide flexibility in how the launcher is used, a number of launch arguments can be specified:
* --FastLaunch - Skips the interface of the Thin Launcher and immediately launches the game.
* --SkipUpdate - Skips performing a check for updates before launching the game.
* --NotifyExit - Makes a notification popup when the game exits and the launcher detects it to begin exiting itself.
* --SkipNotify - Prevents all notifications from the Thin Launcher from appearing.
* --OutputString - Makes status updates write to STDOUT so that other applications can launch the Thin Launcher and monitor its progress.
* --DetectRealPath - Detects the actual install path of the game client instead of trusting the SymLink.
* --NoOptimization - Prevents the "-optimize" launch argument from being enabled on the PSO2 client. Memory optimizations in PSO2 no longer cause issues like stuttering so "-optimize" is being enabled by default again.
* --UseStartup - Causes the PSO2Startup.exe to be renamed instead of PSO2Launcher.exe. This allows changing the launch arguments the PSO2 client uses instead of only removing all arguments like before. This is automatically enabled if `--NoOptimization` is not set on the command line.
