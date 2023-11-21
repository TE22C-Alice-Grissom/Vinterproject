using System.Net.Sockets;
using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Breakout");
Raylib.SetTargetFPS(60);

Color ljusBlå = new Color(0, 191, 255, 1); 




while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.WHITE);

    Rectangle plattaRec = new Rectangle(10, 10, 50, 20);

    Raylib.EndDrawing();
    Raylib.WindowSwapBuffers();

}

// Rectangle plattan = new Rectangle (10, 10 , 50, 20);
// Raylib.DrawRectangleRec(plattan, Color.SKYBLUE);


// eller 30, 144, 255, 1 

// Rectangle plattanRec = new Rectangle(760, 20, 32, 32);






//Raylib.DrawCirle(100, 100, 100, Color.White);





//List<Rectangle> rects = new List<Rectangle>();






// Console.ReadLine();