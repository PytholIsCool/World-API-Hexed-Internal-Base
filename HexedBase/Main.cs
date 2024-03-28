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
            //Making a new page to host all our buttons
            MainPage = new VRCPage("Test Mod");
            //Making a new tab so we can access our new page in-game
            new Tab(MainPage, "Starborn/World Button API Test Mod", Resources.Icon());
            //Making a new button group to put our buttons under
            MainGrp = new ButtonGroup(MainPage, "Test Mod", false);

            //You don't need to pre-define the boolean variable (like "isToggled" for example)
            
            MainGrp.AddToggle("Toggle", (isToggled) =>
            {
                if (isToggled)
                {
                    LogHandler.Log("This toggle is now on.");
                }
                else
                {
                    LogHandler.Log("This toggle is now off");
                }
            });

            /*
            For regular buttons, you define everything in this order:
            The text on the button, the button's tooltip, an action, whether or not the button will be a half button, whether or not theres a submenu icon/indicator (the arrow at the top left of buttons that lead to a submenu), and lastly, your button's icon.
            I don't define everything because it's unnecessary but you can if you wanna or if it is necessary for you. 
            */
            
            MainGrp.AddButton("Test", "This is a test button", () =>
            {
                LogHandler.Log(LogHandler.Colors.Green, "Pressed button!");
            });

            /*
            Here's what a button with all things defined would look like:

            MainGrp.AddButton("Test", "This is a test button", () => {
                Process.Start("https://github.com/PytholIsCool/World-API-Hexed-Internal-Base");
                LogHandler.Log(LogHandler.Colors.Green, "Pressed button!");
            }, true, false, Resources.Icon());
            */

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
