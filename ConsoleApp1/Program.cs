using Raylib;
using rl = Raylib.Raylib;
using System;

namespace ConsoleApp1
{
    static class Program
    {
        public static bool checkCollision(Player pl, Pickup pu)
        {
            bool rtn = false;
            Rectangle PickUpCol = new Rectangle(pu.pos.x, pu.pos.y, 20, 20);
            Rectangle PlayerCol = new Rectangle(pl.pos.x - 5, pl.pos.y + 5, 10, 40);
            //Console.WriteLine(("Collision = " + PlayerCol + PickUpTest).ToString());
            rtn = rl.CheckCollisionRecs(PickUpCol, PlayerCol);
            if (rtn)
            {
                pu.enabled = false;
            }
            return rtn;
           
        }
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            int screenWidth = 800;
            int screenHeight = 450;
            int score = 0;
            Player myPlayer = new Player();
            Pickup[] pickUp = new Pickup[10];
            int idx = 0;
            for(int x = 100; x < 700 && idx < 10; x += 40)
            {
                pickUp[idx] = new Pickup();
                pickUp[idx].pos.x = x;
                pickUp[idx].pos.y = 150;
                idx++;
            }
            int radicalRadius = 0;
            if(radicalRadius > 100)
            {
                radicalRadius--;
            }
            else if (radicalRadius < 1)
            {
                radicalRadius++;
            }

            myPlayer.pos.x = 75;
            myPlayer.pos.y = 75;


            rl.InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");

            rl.SetTargetFPS(60);
            //--------------------------------------------------------------------------------------

            // Main game loop
            while (!rl.WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                // TODO: Update your variables here
                //----------------------------------------------------------------------------------

                // Draw
                //----------------------------------------------------------------------------------
                rl.BeginDrawing();

                rl.ClearBackground(Color.RAYWHITE);
                myPlayer.RunUpdate();
                myPlayer.Draw();
                foreach (Pickup p in pickUp)
                {
                    if (p.enabled)
                    {
                        p.Draw();
                        checkCollision(myPlayer, p);
                        if (checkCollision(myPlayer, p))
                        {
                            score++;
                        }
                    }
                }
                rl.DrawText($"Score: {score}", 50,50, 20, Color.BLACK);
                rl.DrawText("Congrats! You created your first window!", 190, 200, 20, Color.LIGHTGRAY);

                rl.EndDrawing();
                //----------------------------------------------------------------------------------
            }

            // De-Initialization
            //--------------------------------------------------------------------------------------
            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}