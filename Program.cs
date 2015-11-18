//Justin Snow SnowPlayer

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.DirectX.AudioVideoPlayback;
using Microsoft.Win32;
using Win32;

namespace SnowPlayer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public const string RegistryKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\SnowPlayer";
        public const string RegistryPath = "DefaultPathName";
        public const string RegistryAudioVolume = "AudioVolume";
        public const string RegistryStringData = "StringData";

        [STAThread]
        static void Main(string[] Args)
        {
            string Argument = "";
            if (Args.Length != 0) Argument = Args[0];
            if (!IsAlreadyRunning(Argument))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MAIN_Form(Argument));
            }
            else
            {
                
                Application.Exit(); 
            }
        }

        static bool IsAlreadyRunning(string Argument) 
	    {
            bool bRet = false;
            IntPtr hFound;
		    Process currentProcess = Process.GetCurrentProcess();
		    foreach (Process p in Process.GetProcesses()) 
		    { 
                if (p.Id != currentProcess.Id)
                {
                    if (p.ProcessName.Equals(currentProcess.ProcessName) == true)
                    {
                        bRet = true;
                        hFound = p.MainWindowHandle;
                        if (Api.IsIconic(hFound)) 
                        {                        
                            Api.ShowWindow(hFound, Api.SW_RESTORE);
                            Api.SetForegroundWindow(hFound);
                        }
                        if (Argument.Length != 0)
                        {
                            Registry.SetValue(RegistryKey, RegistryStringData, Argument);
                            Api.PostMessage(hFound, Api.WM_STRINGDATA, 0, 0);
                        }
                        break;
                    }
                }
		    } 
			return bRet; 
	    } 

    }
}