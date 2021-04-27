using HarmonyLib;
using System;

namespace OculusColorSpaceSetting.Patches
{
    [HarmonyPatch(typeof(OVRPlugin), nameof(OVRPlugin.SetClientColorDesc), new Type[] { typeof(OVRPlugin.ColorSpace) })]
    public class SetClientColorDescPatch
    {
        public static void Prefix(ref OVRPlugin.ColorSpace colorSpace)
        {
            Plugin.Log.Debug($"{colorSpace}");
            colorSpace = OVRPlugin.GetHmdColorDesc();
            Plugin.Log.Debug($"{colorSpace}");
        }
    }
}
