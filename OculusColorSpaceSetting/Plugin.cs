using HarmonyLib;
using IPA;
using System.Reflection;
using IPALogger = IPA.Logging.Logger;

namespace OculusColorSpaceSetting
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }
        public const string HARMONY_ID = "OculusColorSpaceSetting.denpadokei.com.github";
        private Harmony harmony;
        [Init]
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        public void Init(IPALogger logger)
        {
            Instance = this;
            Log = logger;
            Log.Info("OculusColorSpaceSetting initialized.");
            this.harmony = new Harmony(HARMONY_ID);
        }

        #region BSIPA Config
        //Uncomment to use BSIPA's config
        /*
        [Init]
        public void InitWithConfig(Config conf)
        {
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Log.Debug("Config loaded");
        }
        */
        #endregion

        [OnStart]
        public void OnApplicationStart() => Log.Debug("OnApplicationStart");

        [OnExit]
        public void OnApplicationQuit() => Log.Debug("OnApplicationQuit");
        [OnEnable]
        public void OnEnable() => this.harmony.PatchAll(Assembly.GetExecutingAssembly());
        [OnDisable]
        public void OnDisable() => this.harmony.UnpatchAll(HARMONY_ID);
    }
}
