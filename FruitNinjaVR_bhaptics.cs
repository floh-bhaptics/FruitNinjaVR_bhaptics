using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MelonLoader;
using HarmonyLib;
using MyBhapticsTactsuit;

namespace FruitNinjaVR_bhaptics
{
    public class FruitNinjaVR_bhaptics : MelonMod
    {
        public static TactsuitVR tactsuitVr;

        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            tactsuitVr = new TactsuitVR();
            tactsuitVr.PlaybackHaptics("HeartBeat");
        }

        [HarmonyPatch(typeof(Blade), "Slice", new Type[] { typeof(SliceObject) })]
        public class bhaptics_SliceBlade
        {
            [HarmonyPostfix]
            public static void Postfix(Blade __instance)
            {
                tactsuitVr.Recoil(__instance.IsRightBlade);
            }
        }

        [HarmonyPatch(typeof(Bomb), "Explode", new Type[] { typeof(ObjectPooler) })]
        public class bhaptics_BombExplode
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                tactsuitVr.PlaybackHaptics("ExplosionBelly");
            }
        }

    }
}
