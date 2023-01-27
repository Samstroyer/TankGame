using Raylib_cs;

public class Engine
{
    Player[] players;
    bool playerOneActive = true;

    public Engine()
    {
        players = new Player[2] {
            new Player(false),
            new Player(true)
        };
    }

    public void Start()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.GRAY);

            Background();

            foreach (Player p in players)
            {
                p.Run();
            }

            HandleRound();

            Raylib.EndDrawing();
        }

    }

    private void Background()
    {
        Raylib.DrawRectangle(0, 600, Raylib.GetScreenWidth(), 200, Color.GREEN);
    }

    private void HandleRound()
    {
        if (playerOneActive)
        {
            bool ended = players[0].Active();
            if (ended)
            {
                playerOneActive = !playerOneActive;
                players[1].lastPos = players[1].currentPos;
            }
        }
        else
        {
            bool ended = players[1].Active();
            if (ended)
            {
                playerOneActive = !playerOneActive;
                players[0].lastPos = players[0].currentPos;
            }
        }
    }
}
