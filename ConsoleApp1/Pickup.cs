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
        public void Draw()
        {
            rl.DrawCircle(pos.x, pos.y, 3f, myColor);
            rl.DrawCircle(pos.x, pos.y, 5f, myColor);
            
        }
    }
}
