using BepInEx;
using BepInEx.Logging;
using COTL_API.Localization;
using HarmonyLib;
using System.Collections.Generic;
using System.IO;

namespace FurrySpeakMod
{
    [BepInPlugin(PluginGuid, PluginName, PluginVer)]
    [BepInDependency("io.github.xhayper.COTL_API")]
    [HarmonyPatch]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "IngoH.cotl.FurrySpeakMod";
        public const string PluginName = "FurrySpeakMod";
        public const string PluginVer = "1.0.0";

        internal static ManualLogSource Log;
        internal readonly static Harmony Harmony = new(PluginGuid);

        internal static string PluginPath;

        private void Awake()
        {
            Logger.LogInfo($"Loaded {PluginName}!");
            Plugin.Log = base.Logger;

            PluginPath = Path.GetDirectoryName(Info.Location);
            
            string localizationPath = Path.Combine(Plugin.PluginPath, "Assets", "Furry.language");
            
            Localization.LoadLocalization("Furry Speak", localizationPath);
        }

        private void OnEnable()
        {
            Harmony.PatchAll();
            Logger.LogInfo($"Loaded {PluginName}!");
        }

        private void OnDisable()
        {
            Harmony.UnpatchSelf();
            Logger.LogInfo($"Unloaded {PluginName}!");
        }
    }
}