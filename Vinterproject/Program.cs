using System.ComponentModel;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Cryptography;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Breakout");
Raylib.SetTargetFPS(60);


Color lightblue = new Color(0, 191, 255, 255);
Rectangle boardRec = new Rectangle(400 - 75, 350, 150, 20);
Vector2 bollPosition = new Vector2(400, 335);
Vector2 movement = new Vector2(0, 0);
Vector2 bollmovment = new Vector2(2, 2);

List<Rectangle> blocks = new List<Rectangle>();
blocks.Add(new Rectangle(325,100,100,25));
blocks.Add(new Rectangle(325,150,100,25));


string scene = "game";

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    if (scene == "game")
    {
        movement = Vector2.Zero;  //all movement starts at 0 units. 
        Raylib.DrawRectangleRec(boardRec, lightblue);
        Raylib.DrawCircleV(bollPosition, 10, Color.BLACK);
        movement = Movement(movement);

        boardRec.X += movement.X * 5;

        if (boardRec.X < 0 || boardRec.X > 650) // Ensures that the plate cannot go outside the window.
        {
            boardRec.X -= movement.X * 5;
        }


        bollPosition += bollmovment;

        if (bollPosition.Y > 600 || bollPosition.Y < 0) //checking collision
        {
            bollmovment.Y = -bollmovment.Y;
        }
        else if (bollPosition.X > 800 || bollPosition.X < 0) //checking collision
        {
            bollmovment.X = -bollmovment.X; //hastigheten gångras med -1 som gör att man upplever illusionen att den studsar
        }

        if (Raylib.CheckCollisionCircleRec(bollPosition, 10, boardRec))
        {
            bollmovment.Y = -bollmovment.Y;
        }

        if (bollPosition.Y > 600)
        {
            scene = "Game over";
        }


        foreach (Rectangle block in blocks)
        {
            Raylib.DrawRectangleRec(blocks[0], Color.DARKBLUE);
            Raylib.DrawRectangleRec(blocks[1], Color.DARKBLUE); 
        }


    }
    else if (scene == "Game over")
    {
        Raylib.DrawText("GAME OVER", 250, 280, 50, Color.RED);
    }

    Raylib.EndDrawing();

}
//Koden under är ett tips från micke hur jag borde göra
static Vector2 Movement(Vector2 movement)
{
    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
    {
        movement.X = -1;                    //Gör så att plattan kan åka åt vänster eftersom det blir mindre o mindre siffror åt vänster håll
    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
    {
        movement.X = 1;                             //motsattsen till left key
    }

    return movement;
}

// Rectangle plattan = new Rectangle (10, 10 , 50, 20);
// Raylib.DrawRectangleRec(plattan, Color.SKYBLUE);


// eller 30, 144, 255, 1 

// Rectangle plattanRec = new Rectangle(760, 20, 32, 32);


//Raylib.DrawCirle(100, 100, 100, Color.White);

//List<Rectangle> rects = new List<Rectangle>();



// Console.ReadLine();