using Raylib;
using rl = Raylib.Raylib;
using System;
using System.IO;
namespace ConsoleApp1
{
    static class Program
    {
        public static bool checkCollision(Player pl, Pickup pu)
        {
            bool rtn = false;
            Random r = new Random();
            Rectangle PickUpCol = new Rectangle(pu.pos.x, pu.pos.y, 10, 20);
            float w = Pickup.pickUpTex.width * .25f;
            float h = Pickup.pickUpTex.height * .25f;
            Rectangle PlayerCol = new Rectangle(pl.pos.x-5, pl.pos.y, 10, 35);
            //Console.WriteLine(("Collision = " + PlayerCol + PickUpTest).ToString());
            rtn = rl.CheckCollisionRecs(PickUpCol, PlayerCol);

            if (rtn)
            {
                //pu.enabled = false;
                pu.pos.x = r.Next(10, 750);
                pu.pos.y = r.Next(10, 400);
            }
            return rtn;
           
        }

      


        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            rl.InitAudioDevice();
            Console.WriteLine($"INFO: Audio Device Status = {rl.IsAudioDeviceReady()}");
            Sound pickUpS = rl.LoadSound("resources/AmmoPickup.ogg");
            StreamWriter writer;
            writer = new StreamWriter("test.txt");
            int screenWidth = 800;
            int screenHeight = 450;
            int score = 0, highScore = 0;
            int timer = 30*60;
            bool restartBool = false;
            bool firstInc = true, secondInc = true, gameRunning = true;
            Random r = new Random();
            Player myPlayer = new Player();
            Pickup[] pickUp = new Pickup[10];
            int idx = 0;
            rl.InitWindow(screenWidth, screenHeight, "raylib [core] example - basic window");
            Pickup.SetTex("kenney_aie/items/platformPack_item002.png");

            writer.WriteLine("Hello World!");
            writer.Close();

            for (int x = 100; x < 700 && idx < 10; x += 40)
            {
                pickUp[idx] = new Pickup();
                pickUp[idx].pos.x = r.Next(10,750);
                pickUp[idx].pos.y = r.Next(10,400);
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

                if (score == 10 && firstInc)
                {
                    timer += 10 * 60;
                    firstInc = false;
                }
                else if (score == 20 && secondInc)
                {
                    timer += 10 * 60;
                    secondInc = false;
                }
                else if(score >= 30)
                {
                    rl.DrawText("Congrats! You Win!", 190, 200, 20, Color.LIGHTGRAY);
                    gameRunning = false;
                }               
                timer--;
                int temptime = timer / 60;
                myPlayer.RunUpdate();
                myPlayer.Draw();
                if (temptime <= 0 && score <30)
                {
                    rl.DrawText("Time is Up!\nPress R to Restart", 50, 60, 20, Color.LIGHTGRAY);
                    restartBool = rl.IsKeyPressed(KeyboardKey.KEY_R);
                    gameRunning = false;
                }
                else if (temptime > 0 & gameRunning)
                {
                    rl.DrawText($"Time: {temptime}", 50, 60, 20, Color.LIGHTGRAY);
                    foreach (Pickup p in pickUp)
                    {
                        p.Draw();
                        if (checkCollision(myPlayer, p))
                        {
                            score++;
                            rl.PlaySound(pickUpS);
                        }

                    }
                }
               
                if (restartBool)
                {
                    score = 0;
                    timer = 30 * 60;
                    for (int x = 100; x < 700 && idx < 10; x += 40)
                    {
                        pickUp[idx] = new Pickup();
                        pickUp[idx].pos.x = r.Next(10, 750);
                        pickUp[idx].pos.y = r.Next(10, 400);
                        idx++;
                    }
                    gameRunning = true;
                    restartBool = false;
                }
                if (highScore <= score)
                    highScore = score;
                
                rl.DrawText($"Score: {score}", 50, 20, 20, Color.LIGHTGRAY);
                rl.DrawText($"High Score: {highScore}", 50, 40, 20, Color.LIGHTGRAY);
                //rl.DrawText("Congrats! You created your first window!", 190, 200, 20, Color.LIGHTGRAY);




                rl.EndDrawing();
                //----------------------------------------------------------------------------------
            }
            //System.IO.File.WriteAllText(@"C:\Users\s199009")
            // De-Initialization
            //--------------------------------------------------------------------------------------
            rl.CloseWindow();        // Close window and OpenGL context
                                     //--------------------------------------------------------------------------------------

            return 0;
        }
    }
}