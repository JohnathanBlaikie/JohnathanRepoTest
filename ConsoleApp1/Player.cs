using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;
namespace ConsoleApp1
{
    struct Vector2Int
    {
        public int x;
        public int y;
    }
    class Player
    {
        public Vector2Int pos = new Vector2Int();
        public Color myColor = Color.PURPLE;
        public int speed;
        bool borders = false;
        public void RunUpdate()
        {
            if (rl.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT))
            {
                speed = 3;
            }
            else
            {
                speed = 1;
            }
            if (rl.IsKeyDown(KeyboardKey.KEY_W))
            {
                Console.WriteLine("W is being pressed!");
                pos.y-= speed;
            }
            if (rl.IsKeyDown(KeyboardKey.KEY_S))
            {
                Console.WriteLine("S is being pressed!");
                pos.y+= speed;
            }
            if (rl.IsKeyDown(KeyboardKey.KEY_A))
            {
                Console.WriteLine("A is being pressed!");
                pos.x -= speed;
            }
            if (rl.IsKeyDown(KeyboardKey.KEY_D))
            {
                Console.WriteLine("D is being pressed!");
                pos.x += speed;
            }
            
            if (rl.IsKeyPressed(KeyboardKey.KEY_B))
                borders = !borders;

            if (!borders)
            {
                if (pos.x > 795)
                {
                    pos.x = 5;
                }
                if (pos.y > 415)
                {
                    pos.y = 5;
                }
                if (pos.x < 5)
                {
                    pos.x = 795;
                }
                if (pos.y < 5)
                {
                    pos.y = 415;
                }
            }
            else if (borders)
            {
                if (pos.x > 795)
                {
                    pos.x = 795;
                }
                if (pos.y > 415)
                {
                    pos.y = 415;
                }
                if (pos.x < 5)
                {
                    pos.x = 5;
                }
                if (pos.y < 5)
                {
                    pos.y = 5;
                }
            }
        }
        public void Draw()
        {
            rl.DrawCircle(pos.x, pos.y, 5f, myColor);
            rl.DrawRectangle(pos.x-5, pos.y+5, 10, 30, myColor);
        }
    }
}
