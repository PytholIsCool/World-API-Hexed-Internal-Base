using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HexedBase
{
    internal class Resources
    {
        public static string Icon1 = "Put in your Base64 string here";

        public static Sprite Icon()
        {
            byte[] imageBytes = Il2CppSystem.Convert.FromBase64String(Icon1);
            Texture2D texture = new Texture2D(4, 4);
            texture.LoadImage(imageBytes);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(1f, 1f));

            return sprite;
        }
    }
}
