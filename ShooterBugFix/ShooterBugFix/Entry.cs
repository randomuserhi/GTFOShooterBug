using API;
using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace ShooterBugFix {
    [BepInPlugin(Module.GUID, Module.Name, Module.Version)]
    internal class Entry : BasePlugin {
        public override void Load() {
            APILogger.Debug($"Loaded {Module.Name} {Module.Version}");
            harmony = new Harmony(Module.GUID);
            harmony.PatchAll();

            APILogger.Debug("Debug is " + (ConfigManager.Debug ? "Enabled" : "Disabled"));
        }

        private Harmony? harmony;
    }
}