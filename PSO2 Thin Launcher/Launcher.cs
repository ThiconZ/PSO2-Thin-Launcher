using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Management.Deployment;
using Windows.ApplicationModel;

namespace PSO2_Thin_Launcher
{
    public partial class Launcher : Form
    {
        const string GAME_STORE_ID = "100B7A24.oxyna";
        const string GAME_STORE_LAUNCH_ID = @"shell:appsFolder\100B7A24.oxyna_wyfsmff9ynw7j!Game";

        string GamePath = null;
        string Binary_Launcher = "pso2launcher";
        string Binary_Game = "pso2";
        NotifyIcon TrayIcon = new NotifyIcon();
        bool SkipUpdateCheck = false;
        bool FastLaunch = false;
        bool NotifyOnExit = false;
        bool SkipNotify = false;
        bool OutputString = false;
        bool DetectRealPath = false;

        string GameDocsDir => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SEGA", "PHANTASYSTARONLINE2_NA");
        string GameLauncherPath => Path.Combine(GamePath, $"{Binary_Launcher}.exe");
        string GameLauncherPathTemp => Path.Combine(GamePath, $"{Binary_Launcher}_temp.exe");
        string GameExePath => Path.Combine(GamePath, $"{Binary_Game}.exe");

        public Launcher()
        {
            InitializeComponent();
            TrayContextMenuStrip.Renderer = new DarkRenderer();
        }

        private void LogMessage(string message)
        {
            if (OutputString)
            {
                Console.WriteLine($"PSO2TL: {message}");
            }
        }

        private void Launcher_Load(object sender, EventArgs e)
        {
            // Handle any launch arguments passed in
            foreach (string argument in Environment.GetCommandLineArgs())
            {
                switch (argument.ToLower())
                {
                    case "--skipupdate":
                        SkipUpdateCheck = true;
                        break;
                    case "--fastlaunch":
                        FastLaunch = true;
                        break;
                    case "--notifyexit":
                        NotifyOnExit = true;
                        break;
                    case "--skipnotify":
                        SkipNotify = true;
                        break;
                    case "--outputstring":
                        OutputString = true;
                        break;
                    case "--detectrealpath":
                        DetectRealPath = true;
                        break;
                    default:
                        break;
                }
            }

            LogMessage("Loading");
            // Setup our tray icon that will be displayed while the launcher is in the background
            TrayIcon = new NotifyIcon
            {
                Text = "PSO2 Thin Launcher",
                Visible = false,
                Icon = this.Icon,
                BalloonTipTitle = "PSO2 Thin Launcher",
                BalloonTipText = "The launcher is running in the background.\nWhen the game exits the launcher will automatically close.",
                ContextMenuStrip = TrayContextMenuStrip
            };

            GamePath = FindInstallPath();
            PathValueLabel.Text = GamePath ?? "Game intall not found";

            if (GamePath == null)
            {
                LogMessage("Failed to find install");
                LaunchBtn.Enabled = false;
                MessageBox.Show("Failed to find PSO2 Install.", "PSO2 Thin Launcher - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            TrayIcon.Visible = true;
            
            if (FastLaunch)
            {
                LogMessage("Performing fast launch");
                LaunchBtn.Enabled = false;
                if(!PerformUpdateCheck())
                {
                    Task task = Task.Factory.StartNew(() =>
                    {
                        BeginInvoke(new MethodInvoker(delegate { Hide(); }));
                        PerformLaunch();
                    });
                    return;
                }
                else
                {
                    // Don't want to continue to UI if user interacted with a messagebox from the update check already
                    this.Close();
                }
            }
        }

        private string FindInstallPath()
        {
            PackageManager packageManager = new PackageManager();

            // Check if game is installed
            IEnumerable<Package> packages = packageManager.FindPackages();
            Package appPackage = packages.FirstOrDefault(x => x.Id.Name == GAME_STORE_ID);

            if(DetectRealPath)
            {
                IEnumerable<PackageVolume> packageVolumes = packageManager.FindPackageVolumes();
                foreach (var volume in packageVolumes)
                {
                    string searchDirectory = volume.MountPoint + @"\Program Files\ModifiableWindowsApps\pso2_bin";
                    if (Directory.Exists(searchDirectory))
                    {
                        return searchDirectory;
                    }
                }
            }

            // Return back the symlink to install location
            return appPackage?.MutableLocation?.Path;
        }

        private bool IsUpdateRequired()
        {
            string mb_url = "http://patch01.pso2.com/patch_prod/patches/management_beta.txt";
            string local_version_file = Path.Combine(GameDocsDir, "version.ver");

            if(!File.Exists(local_version_file))
            {
                return true;
            }

            using (var wc = new WebClient())
            {
                wc.Headers.Set(HttpRequestHeader.UserAgent, "AQUA_HTTP");
                wc.Headers.Set(HttpRequestHeader.CacheControl, "no-cache");
                wc.Headers.Set(HttpRequestHeader.Pragma, "no-cache");
                wc.Headers.Set(HttpRequestHeader.Host, "patch01.pso2.com");

                string management_beta = wc.DownloadString(mb_url);
                string patch_url = management_beta.Substring(management_beta.LastIndexOf("PatchURL=")).Trim();

                // valid url found
                if (patch_url.Length > 9)
                {
                    patch_url = patch_url.Remove(0, 9);
                }
                else
                {
                    return true;
                }

                wc.Headers.Set(HttpRequestHeader.UserAgent, "AQUA_HTTP");
                wc.Headers.Set(HttpRequestHeader.Host, "download.pso2.com");
                string ver_url = patch_url + "version.ver";
                string version = wc.DownloadString(ver_url);
                bool versionsMatch = File.ReadAllText(local_version_file) == version;

                return !versionsMatch;
            }
        }

        private void LaunchBtn_Click(object sender, EventArgs e)
        {
            if(!PerformUpdateCheck())
            {
                PerformLaunch();
            }
        }

        private bool PerformUpdateCheck()
        {
            LogMessage("Checking for updates");
            try
            {
                if (SkipUpdateCheck == false && IsUpdateRequired())
                {
                    LogMessage("Update required");
                    string UpdateRequired = "A game update is required to play the game. Would you like to launch the Official Launcher to begin updating?";
                    UpdateRequired += "\n\nNote: You will not be able to launch from the PSO2 Thin Launcher until the game is updated.";
                    if (MessageBox.Show(UpdateRequired, "PSO2 Thin Launcher - Update Required", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Process.Start(GAME_STORE_LAUNCH_ID);
                        System.Threading.Thread.Sleep(1000);
                        this.Close();
                    }
                    return true;
                }
                LogMessage("No update required");
                return false;
            }
            catch (Exception ex)
            {
                LogMessage("Error checking for updates");
                if (MessageBox.Show($"There was an error checking for updates.\nError:\n{ex.Message}\nWould you like to run the Official Lancher instead?\n\nNote: Selecting [No] will close the Thin Launcher.", "PSO2 Thin Launcher - Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    Process.Start(GAME_STORE_LAUNCH_ID);
                    System.Threading.Thread.Sleep(1000);
                    this.Close();
                }
                this.Close();
                return true;
            }
        }

        private async void PerformLaunch()
        {
            LogMessage("Performing launch");
            // Rename the original launcher to a temp file and rename the game to take its place
            // Due to the memory optimization forced by the launcher we do this to avoid -optimization being added as a launch argument
            RenameLauncherFiles(false);

            Process.Start(GAME_STORE_LAUNCH_ID);
            LogMessage("Game launched");

            this.Hide();
            if(!SkipNotify)
            {
                TrayIcon.ShowBalloonTip(5000);
            }
            Process GameProcess = await GetGameProcess();
            if(GameProcess == null)
            {
                LogMessage("Failed to detect game process");
                MessageBox.Show("Failed to detect game process!\nThe Thin Launcher will now restore the file names and exit.", "PSO2 Thin Launcher - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RenameLauncherFiles(true);
                this.Close();
            }

            LogMessage("Waiting for game to exit");
            GameProcess.WaitForExit();

            // Rename the binaries back to their original names once the game has exited
            LogMessage("Game exited");
            RenameLauncherFiles(true);
            if (SkipNotify == false && NotifyOnExit == true)
            {
                TrayIcon.BalloonTipText = "Original file names have been restored.\nLauncher is now exiting.";
                TrayIcon.ShowBalloonTip(5000);
            }
            System.Threading.Thread.Sleep(1000);
            LogMessage("Launcher exiting");
            this.Close();
        }

        private void RenameLauncherFiles(bool RestoreOriginal = false)
        {
            if(RestoreOriginal)
            {
                LogMessage("Restoring files to original name");
                if (File.Exists(GameLauncherPath) && !File.Exists(GameExePath))
                {
                    File.Move(GameLauncherPath, GameExePath);
                }

                if (File.Exists(GameLauncherPathTemp) && !File.Exists(GameLauncherPath))
                {
                    File.Move(GameLauncherPathTemp, GameLauncherPath);
                }
            }
            else
            {
                LogMessage("Renaming files to launch directly");
                if (File.Exists(GameLauncherPath) && !File.Exists(GameLauncherPathTemp))
                {
                    File.Move(GameLauncherPath, GameLauncherPathTemp);
                }

                if (File.Exists(GameExePath) && !File.Exists(GameLauncherPath))
                {
                    File.Move(GameExePath, GameLauncherPath);
                }
            }
        }

        public async Task<Process> GetGameProcess()
        {
            for (int i = 0; i < 30; i++)
            {
                Process process = Process.GetProcessesByName(Binary_Launcher).FirstOrDefault();
                if (process != null)
                {
                    return process;
                }

                await Task.Delay(TimeSpan.FromSeconds(1));
            }

            return null;
        }

        private void ExitLauncherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogMessage("Exiting launcher from tray");
            // If trying to exit the launcher before the game has closed, immediately perform file renaming
            RenameLauncherFiles(true);

            this.Close();
        }
    }
}
