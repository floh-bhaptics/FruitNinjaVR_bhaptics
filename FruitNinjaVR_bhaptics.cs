using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MelonLoader;
using HarmonyLib;
using MyBhapticsTactsuit;

[assembly: MelonInfo(typeof(FruitNinjaVR_bhaptics.FruitNinjaVR_bhaptics), "FruitNinjaVR_bhaptics", "2.0.0", "Florian Fahrenberger")]
[assembly: MelonGame("Halfbrick", "FruitNinja")]

namespace FruitNinjaVR_bhaptics
{
    public class FruitNinjaVR_bhaptics : MelonMod
    {
        public static TactsuitVR tactsuitVr;

        public override void OnInitializeMelon()
        {
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
