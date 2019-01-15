
using System;
using UnityEngine;

namespace CactEye3
{
    internal class Config 
    {
        private readonly string ConfigFilePath = @"GameData/CactEye3/Plugin/settings.cfg";
        
        public bool DebugMode = false;

        public bool SunDamage = true;

        public bool GyroDecay = true;

        public void LoadSettings()
        {
            string FullConfigPath = KSPUtil.ApplicationRootPath + ConfigFilePath;

            ConfigNode Settings = ConfigNode.Load(FullConfigPath);
            if(Settings == null)
            {
                Log.Instance.LogEntry("Failed to open settings file", LogLevel.WARNING);
            }

            if (Settings.HasNode("CactEye3"))
            {
                ConfigNode Data = Settings.GetNode("CactEye3");

                DebugMode = Data.HasValue("DebugMode") ? bool.Parse(Data.GetValue("DebugMode")) : true;

                SunDamage = Data.HasValue("SunDamage") ? bool.Parse(Data.GetValue("SunDamage")) : true;

                GyroDecay = Data.HasValue("GyroDecay") ? bool.Parse(Data.GetValue("GyroDecay")) : true;
            }
            else
            {
                Log.Instance.LogEntry("CactEye3: ERROR: Failed to read config file.  Default settings used", LogLevel.WARNING);
            }
        }

        public void UpdateSettings()
        {
            ConfigNode Settings = new ConfigNode();

            ConfigNode Data = Settings.AddNode("CactEye3");

            Data.AddValue("DebugMode", DebugMode);
            Data.AddValue("SunDamage", SunDamage);
            Data.AddValue("GyroDecay", GyroDecay);

            try
            {
                Settings.Save(KSPUtil.ApplicationRootPath + ConfigFilePath);
                Log.Instance.LogEntry("Saved updated config file", LogLevel.INFO);
            }
            catch(Exception ex)
            {
                Log.Instance.LogEntry("Error saving settings file: " + ex.Message, LogLevel.ERROR);
            }

        }

    }
}
