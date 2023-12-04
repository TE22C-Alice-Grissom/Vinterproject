using System.Net.Sockets;
using System.Numerics;
using System.Security.Cryptography;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Breakout");
Raylib.SetTargetFPS(60);




Color ljusBlå = new Color(0, 191, 255, 255);
Rectangle plattaRec = new Rectangle(400 - 75, 350, 150, 20);
Vector2 bollPosition = new Vector2(400, 335);
Vector2 movement = new Vector2(0, 0);
Vector2 bollmovment = new Vector2(2,2);


List<Rectangle> block = new();


float speed = 5;

string scene = "game";

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    Raylib.DrawRectangleRec(plattaRec, ljusBlå);
    Raylib.DrawCircleV(bollPosition, 10, Color.BLACK);

    Raylib.EndDrawing();

    if (scene == "game")
    {
        movement = Vector2.Zero;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        {
            movement.X = -1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        {
            movement.X = 1;
        }
        
        plattaRec.X += movement.X * 5;
        bollPosition += bollmovment;

        if(bollPosition.Y > 600 || bollPosition.Y < 0)
        {
            bollmovment.Y = -bollmovment.Y;
        }
        else if(bollPosition.X > 800 || bollPosition.X < 0)
        {
            bollmovment.X = -bollmovment.X;
        }

        if(Raylib.CheckCollisionCircleRec(bollPosition, 2, plattaRec))
        {
            Console.WriteLine();
        }
    


        // bollmovment.Y = -bollmovment.Y;

        

    }


}

// Rectangle plattan = new Rectangle (10, 10 , 50, 20);
// Raylib.DrawRectangleRec(plattan, Color.SKYBLUE);


// eller 30, 144, 255, 1 

// Rectangle plattanRec = new Rectangle(760, 20, 32, 32);






//Raylib.DrawCirle(100, 100, 100, Color.White);





//List<Rectangle> rects = new List<Rectangle>();






// Console.ReadLine();