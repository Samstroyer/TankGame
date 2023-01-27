using Raylib_cs;

Engine e = new Engine();

Setup();
Draw();

void Setup()
{
    Raylib.InitWindow(1000, 800, "Tank Game");
    Raylib.SetTargetFPS(144);
}

void Draw()
{
    e.Start();
}