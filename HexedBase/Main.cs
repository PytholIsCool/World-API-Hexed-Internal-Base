using Il2CppSystem.Net;
using OVR.OpenVR;
using Starborn.API;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Playables;
using UnityEngine.UI;

namespace HexedBase
{
    internal class Main
    {
        public static VRCPage MainPage;
        public static ButtonGroup MainGrp;
        public static VRCSlider TestSlider;
        public static void Init()
        {
            MainPage = new VRCPage("Test Mod");
            new Tab(MainPage, "Starborn/World Button API Test Mod", Resources.Icon());
            MainGrp = new ButtonGroup(MainPage, "Test Mod", false);


            MainGrp.AddToggle("Toggle", (isToggled) =>
            {
                if (isToggled)
                {
                    isToggled = false;
                    LogHandler.Log("This toggle is now on.");
                }
                else
                {
                    isToggled = true;
                    LogHandler.Log("This toggle is now off");
                }
            });

            MainGrp.AddButton("Test", "This is a test button", () =>
            {
                LogHandler.Log(LogHandler.Colors.Green, "Pressed button!");
            });

            MainGrp.AddDuoButtons("DuoButton1", "This is a Duo Button.", DuoButton1Msg, "DuoButton2", "This is also a Duo Button.", DuoButton2Msg);

            //You don't need to pre-define the name of the slider but I like to do it anyways just to make my code more readable
            TestSlider = new VRCSlider(MainPage, "Test Slider", "Just a simple slider", (sliderVal) =>
            {

                LogHandler.Log(LogHandler.Colors.Red, "Slider value adjusted to " + sliderVal + "%");
            }, 25f, 0f, 100f);
        }
        public static void DuoButton1Msg()
        {
            LogHandler.Log("You just pressed Duo Button one!");
        }
        public static void DuoButton2Msg()
        {
            LogHandler.Log("You just pressed Duo Button two!");
        }
    }
}
