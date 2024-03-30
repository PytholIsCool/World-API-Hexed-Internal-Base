using CoreRuntime.Interfaces;
using CoreRuntime.Manager;
using Cysharp.Threading.Tasks.Linq;
using System;
using System.Collections;
using UnityEngine;

namespace HexedBase
{
    public class Entry : HexedCheat // Define the Main Class for the Loader
    {
        private static IEnumerator waitForQM()
        {
            while (GameObject.Find("Canvas_QuickMenu(Clone)") == null) yield return null;
            yield return null;

            while (GameObject.Find("Canvas_MainMenu(Clone)") == null) yield return null;
            yield return null;

            Main.Init();

            yield break;
        }
        public override void OnLoad()
        {
            // Specify our main function hooks to let the loader know about the games base functions, it takes any method that matches the original unity function struct
            MonoManager.PatchUpdate(typeof(VRCApplication).GetMethod(nameof(VRCApplication.Update))); // Update is needed to work with IEnumerators, hooking it will enable the CoroutineManager
            // Apply our custom Hooked function
            CoroutineManager.RunCoroutine(waitForQM());
        }

        public override void OnApplicationQuit()
        {
            Console.WriteLine("Game Closed! Bye!");
        }

        public override void OnUpdate()
        {
            // Methods that need to run every frame, added a simple hotkey zoom module
            KeybindManager.Update();
        }

        public override void OnFixedUpdate()
        {
            // Function is not hooked, won't get called
        }

        public override void OnLateUpdate()
        {
            // Function is not hooked, won't get called
        }

        public override void OnGUI()
        {
            // Function is not hooked, won't get called
        }

        private static IEnumerator PrintLateHello()
        {
            // Example on calling a simple print after a 5 second delay
            yield return new WaitForSeconds(5);

            Console.WriteLine("Hello from a delayed function!");
        }
    }
}
