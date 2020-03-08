using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Harmony;
    using UnityEngine;

namespace COLORFABRICATOR
{

    [HarmonyPatch(typeof(BaseUpgradeConsoleGeometry))]
    [HarmonyPatch("Start")]

    internal class Ghost_Color_Patch
    {
        public static bool Prefix(BaseUpgradeConsoleGeometry __instance)
        {


            
            var mats = __instance.fabricator.ghost.GetAllComponentsInChildren<SkinnedMeshRenderer>();


            { 
                foreach (var mat in mats)
                {
                    mat.material.color = new Color32(Convert.ToByte(Config.fabricatorValue), Convert.ToByte(Config.fabricatorgValue), Convert.ToByte(Config.fabricatorbValue), 1);
                }

            }    


                return true;

        }
    }
}

