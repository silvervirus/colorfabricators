using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SMLHelper.V2.Options;
using SMLHelper.V2.Utility;
using UnityEngine;

namespace COLORFABRICATOR
{
    public static class Config
    {
        public static SerializableColor FabricatorColor = new Color(0.016f, 1.0f, 1.0f);
        public static float rValue;
        public static float gValue;
        public static float bValue;
        public static float fabricatorValue;
        public static float fabricatorgValue;
        public static float fabricatorbValue;
       
       
        public static bool fabricatorColor;

        public static void Load()
        {

            rValue = PlayerPrefs.GetFloat("R", 0.016f);
            gValue = PlayerPrefs.GetFloat("G", 1.000f);
            bValue = PlayerPrefs.GetFloat("B", 1.000f);
            fabricatorValue = PlayerPrefs.GetFloat("FabricatorR", 0.016f);
            fabricatorgValue = PlayerPrefs.GetFloat("FabricatorG", 1.000f);
            fabricatorbValue = PlayerPrefs.GetFloat("FabricatorB", 1.000f);
            
            
            fabricatorColor = PlayerPrefsExtra.GetBool("FabricatorColor", true);
        }
    }

    public class Options : ModOptions
    {
        public Options() : base("Color Fabricator Settings")
        {
            SliderChanged += Options_SliderChanged;
            
        }
        public void Options_ToggleChanged(object sender, ToggleChangedEventArgs e)
        {
            
            
            if (e.Id == "fabricatorcolor")
            {
                Config.fabricatorColor = e.Value;
                PlayerPrefsExtra.SetBool("fabricatorColor", e.Value);
            }
        }

        public void Options_SliderChanged(object sender, SliderChangedEventArgs e)
        {
            if (e.Id == "r")
            {
                Config.rValue = e.Value;
                PlayerPrefs.SetFloat("R", e.Value);
            }
            else if (e.Id == "g")
            {
                Config.gValue = e.Value;
                PlayerPrefs.SetFloat("G", e.Value);
            }
            else if (e.Id == "b")
            {
                Config.bValue = e.Value;
                PlayerPrefs.SetFloat("B", e.Value);
            }
           
            if (e.Id == "fabricatorr")
            {
                Config.fabricatorValue = e.Value;
                PlayerPrefs.SetFloat("FabricatorR", e.Value);
            }
            else if (e.Id == "fabricatorg")
            {
                Config.fabricatorgValue = e.Value;
                PlayerPrefs.SetFloat("FabricatorG", e.Value);
            }
            else if (e.Id == "fabricatorb")
            {
                Config.fabricatorbValue = e.Value;
                PlayerPrefs.SetFloat("FabricatorB", e.Value);
            }
        }

        public override void BuildModOptions()
        {

            if ( Config.fabricatorColor == true)
            {
                AddToggleOption("fabricatorcolor", "Color Fabicator Color Enabled", Config.fabricatorColor);
                AddSliderOption("fabricatorr", "fabricator Red", 0, 255, Config.fabricatorValue);
                AddSliderOption("fabricatorg", "fabricator Green", 0, 255, Config.fabricatorgValue);
                AddSliderOption("fabricatorb", "fabricator Blue", 0, 255, Config.fabricatorbValue);

                Config.Load();
            }
            else if (Config.fabricatorColor)
            {
                
                AddToggleOption("fabricatorcolor", "Color Fabricator Color Enabled", Config.fabricatorColor);
                
                AddSliderOption("fabricatorr", "fabricator Red", 0, 255, Config.fabricatorValue);
                AddSliderOption("fabricatorg", "fabricator Green", 0, 255, Config.fabricatorgValue);
                AddSliderOption("fabricatorb", "fabricator Blue", 0, 255, Config.fabricatorbValue);
                Config.Load();
            }
            else if ( Config.fabricatorColor)
            {
                
                AddToggleOption("fabricatorcolor", "Color Fabricator Color Enabled", Config.fabricatorColor);
               
               
                AddSliderOption("fabricatorr", "FabricatorRed", 0, 255, Config.fabricatorValue);
                AddSliderOption("fabricatorg", "Fabricator Green", 0, 255, Config.fabricatorgValue);
                AddSliderOption("fabricatorb", "Fabricator Blue", 0, 255, Config.fabricatorbValue);
            }
            else
            {
                
                AddToggleOption("fabricatorcolor", "Color Fabricator Color Enabled", Config.fabricatorColor);
                
                Config.Load();
            }
        }
    }
}



