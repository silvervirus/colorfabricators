using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace COLORFABRICATOR
{
    [HarmonyPatch(typeof(Fabricator))]
    [HarmonyPatch("LateUpdate")]

    internal class Fabricator_Color_Patch
    {
        public static bool Prefix(Fabricator __instance)
        {

            var fbColor = __instance.GetAllComponentsInChildren<SkinnedMeshRenderer>();
            var mats = __instance.ghost.GetAllComponentsInChildren<SkinnedMeshRenderer>();


            foreach (var fabricatorColor in fbColor)
            {
                if (fabricatorColor.name.Contains("fabricator_01"))
                {
                    fabricatorColor.material.color = new Color32(Convert.ToByte(Config.fabricatorValue), Convert.ToByte(Config.fabricatorgValue), Convert.ToByte(Config.fabricatorbValue), 1);
                }
                foreach (var mat in mats)
                {
                    mat.material.color = new Color32(Convert.ToByte(Config.fabricatorValue), Convert.ToByte(Config.fabricatorgValue), Convert.ToByte(Config.fabricatorbValue), 1);
                }


            }
        
            
                
            
            return true;

        }
    }
}

