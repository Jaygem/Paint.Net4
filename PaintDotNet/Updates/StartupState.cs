﻿namespace PaintDotNet.Updates
{
    using PaintDotNet.Resources;
    using PaintDotNet.Settings.App;
    using PaintDotNet.SystemLayer;
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Threading;

    internal class StartupState : UpdatesState
    {
        private const int FreshBuildAgeDaysForFrequentChecks = 10;
        private const int FreshBuildUpdateCheckIntervalDays = 1;
        private const int MaxBuildAgeDaysForUpdateChecking = 0xe42;

        public StartupState() : base(false, false, MarqueeStyle.Marquee)
        {
        }

        private static void DeleteUpdateMsi()
        {
            string fileName = Path.GetFileName(AppSettings.Instance.Updates.PackageFileName.Value);
            string extension = Path.GetExtension(fileName);
            string dirPath = Environment.ExpandEnvironmentVariables(@"%TEMP%\pdnSetup");
            string[] textArray1 = new string[] { "UpdateMonitor.exe", "UpdateMonitor.exe.config" };
            foreach (string str5 in textArray1)
            {
                FileSystem.TryDeleteFile(dirPath, str5);
            }
            if (string.IsNullOrWhiteSpace(fileName) || ((string.Compare(".msi", extension, StringComparison.InvariantCultureIgnoreCase) != 0) && (string.Compare(".exe", extension, StringComparison.InvariantCultureIgnoreCase) != 0)))
            {
                goto Label_00DF;
            }
            string str6 = Environment.ExpandEnvironmentVariables("%TEMP%");
            try
            {
                string filePath = Path.Combine(str6, fileName);
                for (int i = 3; i > 0; i--)
                {
                    if (FileSystem.TryDeleteFile(filePath))
                    {
                        goto Label_00CB;
                    }
                    Thread.Sleep(500);
                }
            }
            catch (Exception)
            {
            }
        Label_00CB:
            AppSettings.Instance.Updates.PackageFileName.Reset();
        Label_00DF:
            if (Directory.Exists(dirPath))
            {
                FileSystem.TryDeleteDirectory(dirPath);
            }
        }

        public override void OnEnteredState()
        {
            DeleteUpdateMsi();
            if ((Security.IsAdministrator || Security.CanElevateToAdministrator) && ShouldCheckForUpdates())
            {
                AppSettings.Instance.Updates.PingLastAutoCheckTime();
                base.StateMachine.QueueInput(PrivateInput.GoToChecking);
            }
            else
            {
                base.StateMachine.QueueInput(UpdatesAction.Continue);
            }
        }

        public override void ProcessInput(object input, out PaintDotNet.Updates.State newState)
        {
            if (input.Equals(UpdatesAction.Continue))
            {
                newState = new ReadyToCheckState();
            }
            else
            {
                if (!input.Equals(PrivateInput.GoToChecking))
                {
                    throw new ArgumentException();
                }
                newState = new CheckingState();
            }
        }

        public static bool ShouldCheckForUpdates()
        {
            bool defaultValue;
            if (WinAppModel.HasCurrentPackage)
            {
                return false;
            }
            if (PdnInfo.IsTestMode)
            {
                bool isUpdateRebootPending = OS.IsUpdateRebootPending;
                return true;
            }
            if (PdnInfo.IsDebugBuild && OS.IsUpdateRebootPending)
            {
                return false;
            }
            bool flag3 = AppSettings.Instance.Updates.AutoCheck.Value || PdnInfo.IsPrereleaseBuild;
            TimeSpan span = TimeSpan.FromDays(10.0);
            TimeSpan span2 = TimeSpan.FromDays(3650.0);
            TimeSpan span3 = (TimeSpan) (DateTime.UtcNow - PdnInfo.BuildTimeUtc);
            if (span3 > span2)
            {
                defaultValue = false;
            }
            else if (flag3)
            {
                TimeSpan span4;
                if (span3 <= span)
                {
                    span4 = TimeSpan.FromDays(1.0);
                }
                else
                {
                    span4 = TimeSpan.FromDays((double) NormalUpdateCheckIntervalDays);
                }
                try
                {
                    DateTime time = AppSettings.Instance.Updates.LastCheckTimeUtc.Value;
                    TimeSpan span5 = (TimeSpan) (DateTime.UtcNow - time);
                    defaultValue = span5 >= span4;
                }
                catch (Exception)
                {
                    defaultValue = AppSettings.Instance.Updates.AutoCheck.DefaultValue;
                }
            }
            else
            {
                defaultValue = false;
            }
            if (defaultValue)
            {
                defaultValue &= !OS.IsUpdateRebootPending;
            }
            return defaultValue;
        }

        private static int NormalUpdateCheckIntervalDays
        {
            get
            {
                if (PdnInfo.IsFinalBuild)
                {
                    return 10;
                }
                return 1;
            }
        }
    }
}

