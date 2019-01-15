using KSP;

namespace CactEye3
{
    [KSPAddon(KSPAddon.Startup.AllGameScenes, false)]
    internal class Control : Singleton<Control>
    {
        public Config Config;
        
        public void Start()
        {
            Config.LoadSettings();
        }


    }
}
