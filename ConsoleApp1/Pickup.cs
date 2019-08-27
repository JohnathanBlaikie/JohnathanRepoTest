using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;

namespace ConsoleApp1
{
    class Pickup
    {
        public Vector2Int pos;
        public bool enabled = true;
        Color myColor = Color.GOLD;
        Color myColor2 = Color.LIGHTGRAY;
        public static Texture2D pickUpTex;
        //public Texture2D pickUpPng = rl.LoadTexture("kenney_aie/items/platformPack_item002.png");
        public static void SetTex(string fileName)
        {
            pickUpTex = rl.LoadTexture(fileName);
        }
        public void Draw()
        {
            rl.DrawTextureEx(pickUpTex, new Vector2(pos.x,pos.y), 0f ,.25f,Color.GOLD);
            //rl.DrawCircle(pos.x, pos.y, 3f, myColor);
            //rl.DrawCircle(pos.x, pos.y, 5f, myColor);
            
        }
    }
}
