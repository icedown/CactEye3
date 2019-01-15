using KSP.UI.Screens;
using System;
using UnityEngine;

namespace CactEye3.UI
{
    [KSPAddon(KSPAddon.Startup.SpaceCentre, false)]
    internal class ConfigGUI
    {
        private readonly string IconTexture = @"CactEye3/Icons/CactEyeOptics_scaled";
        private static ApplicationLauncherButton Button;
        private Texture2D Icon;
        private bool GuiActive = false;
        private bool AppLauncher = false;

        //Config GUI Window Information
        private int WindowID;
        private readonly string WindowTitle = @"CactEye 3 Configuration";
        private Rect WindowPosition;

        public ConfigGUI()
        {
            WindowID = WindowTitle.GetHashCode() + new System.Random().Next();
            WindowPosition = new Rect(Screen.width * 0.1f, Screen.height * 0.1f, 200, 125);
        }
        
        public void Awake()
        {
            Button = null;
            try
            {
                Icon = GameDatabase.Instance.GetTexture(IconTexture, false);
            }
            catch(Exception ex)
            {
                Log.Instance.LogEntry("Failed to load app launcher icon texture: " + ex.Message, LogLevel.ERROR);
                return;
            }

            Button = ApplicationLauncher.Instance.AddModApplication(
                OnAppLauncherTrue,
                OnAppLauncherFalse,
                null,
                null,
                null,
                null,
                ApplicationLauncher.AppScenes.SPACECENTER,
                Icon);

            if(Button == null)
            {
                Log.Instance.LogEntry("Failed to create app launcher button", LogLevel.ERROR);
            }

            GameEvents.onGUIApplicationLauncherReady.Add(AppLauncherReady);
        }

        private void AppLauncherReady()
        {

        }

        private void OnAppLauncherTrue()
        {

        }

        private void OnAppLauncherFalse()
        {

        }

        public void OnGUI()
        {
            if(GuiActive)
            {
                
                WindowPosition = GUILayout.Window(WindowID, WindowPosition, DrawGUI, WindowTitle);
            }
        }

        private void DrawGUI(int WindowID)
        {

        }
    }
}
