using System.ComponentModel;
using System.Net.Sockets;
using System.Numerics;
using System.Security.Cryptography;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Breakout");
Raylib.SetTargetFPS(60);


Color lightblue = new Color(0, 191, 255, 255);
Rectangle boardRec = new Rectangle(325, 350, 150, 20);
Vector2 bollPosition = new Vector2(400, 335);
Vector2 movement = new Vector2(0, 0);
Vector2 bollmovment = new Vector2(2, 2);

List<Rectangle> blocks = new List<Rectangle>(); //skapaar en lista som innehåller rektanglar och döper den listan till blocks

string scene = "game";
int life = 3;

blocks = skapaRektanglar(blocks);

static List<Rectangle> skapaRektanglar(List<Rectangle>blocks)
{
    for (int i = 0; i <= 1; i++)
    {
        for (int j = 0; j < 7; j++)
        {
            blocks.Add(new Rectangle(10+j*110,30*i+10,100,25));
        }
    }
    return blocks;
}

static void lifeDisplay(int l) //  Display för liv är i vänster hörna och start värdet 'r 3
{                      
    string display = "Life: "+l.ToString();
    Raylib.DrawText(display, 20, 20, 20, Color.RED);
}   

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    if (life == 0)
    {
        Raylib.DrawText("GAME OVER", 250, 280, 50, Color.RED);
    }
    else if (scene == "game")
    {
        Raylib.DrawText("Press Left to move platform left", (int)250.0, 280, 20, Color.RED); //type conversion den gör om 250.0 till ett heltal 
        Raylib.DrawText("Press Right to move plstform right", 250, 300, 20, Color.RED);
        movement = Vector2.Zero;  //all movement börjar på 0 . 
        Raylib.DrawRectangleRec(boardRec, lightblue);
        Raylib.DrawCircleV(bollPosition, 10, Color.BLACK);
        movement = Movement(movement);

        boardRec.X += movement.X * 5;

        if (boardRec.X < 0 || boardRec.X > 650) //Gör så att plattan inte kan gå utanfört rutan.
        {
            boardRec.X -= movement.X * 5;
        }


        bollPosition += bollmovment;

        if (bollPosition.Y > 600 || bollPosition.Y < 0) //kollar collision
        {
            bollmovment.Y = -bollmovment.Y;
        }
        else if (bollPosition.X > 800 || bollPosition.X < 0) //kollar collision
        {
            bollmovment.X = -bollmovment.X; //hastigheten gångras med -1 som gör att man upplever illusionen att den studsar
        }

        if (Raylib.CheckCollisionCircleRec(bollPosition, 10, boardRec)) //kollar kollision med kanten.heck
        {
            bollmovment.Y = -bollmovment.Y;
        }

        foreach (var item in blocks)//kollar kollision med "item" aka rectanglarna, om det sker så försvinner just den rektegneln den stutsade på
        {
            if (Raylib.CheckCollisionCircleRec(bollPosition, 10, item))
            {
                bollmovment.Y = -bollmovment.Y;
                blocks.Remove(item);
                break;
            }
        }

        if (blocks.Count == 0)  //om alla block försvinner så går det över till "Win" scenen
        {
            scene = "Win";
        }
        

        if (bollPosition.Y > 600)  //tappar ett liv om pollen över stigern y=600
        {
            life -= 1;
        }



        foreach (Rectangle block in blocks)//render rectangles
        {
            Raylib.DrawRectangleRec(block, Color.DARKBLUE); 
        }
        lifeDisplay(life);


    }

    else if (scene == "Win")
    {
        Raylib.DrawText("YOU WON!", 250, 280, 50, Color.RED);   
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
        movement.X = 1;                     //motsattsen till left key
    }

    return movement;
}