using System.Numerics;
using Raylib_cs;

public class Player
{
    static readonly KeyboardKey // Sets the keys for up and down for the barrel
    canonLeft = KeyboardKey.KEY_U,
    canonRight = KeyboardKey.KEY_P;

    public Canon canon;

    KeyboardKey leftControl, rightControl;

    public Vector2 currentPos, lastPos, size;
    bool canShoot = true;

    public Player(bool useArrowsForControl)
    {
        size = new(20, 20);
        if (useArrowsForControl)
        {
            leftControl = KeyboardKey.KEY_LEFT;
            rightControl = KeyboardKey.KEY_RIGHT;
            currentPos = new(800, 580);
            lastPos = currentPos;
        }
        else
        {
            currentPos = new(200, 580);
            lastPos = currentPos;
            leftControl = KeyboardKey.KEY_A;
            rightControl = KeyboardKey.KEY_D;
        }
        canon = new(currentPos);
    }

    public void Run()
    {
        Render();
    }

    private void Render()
    {
        Raylib.DrawRectangle((int)currentPos.X, (int)currentPos.Y, (int)size.X, (int)size.Y, Color.RED);
    }

    public bool Active()
    {
        bool ended = false;

        KeyboardKey pressed = (KeyboardKey)Raylib.GetKeyPressed();

        Move();
        CanonControls();

        if (pressed == KeyboardKey.KEY_ENTER) ended = true;

        if (ended) canShoot = true;
        return ended;
    }

    private void CanonControls()
    {
        canon.Update(currentPos);
        canon.ShowTrajectory();

        if (Raylib.IsKeyDown(canonLeft)) canon.Move(-1);
        if (Raylib.IsKeyDown(canonRight)) canon.Move(1);

        if ((KeyboardKey)Raylib.GetKeyPressed() == KeyboardKey.KEY_SPACE)
        {
            canShoot = false;
            canon.Shoot();
        }
    }

    private void Move()
    {
        //Fuel is the max amount that you can move per turn
        sbyte fuelDelta = (sbyte)(currentPos.X - lastPos.X);

        //Draw shadow of last position
        Raylib.DrawRectangle((int)lastPos.X, (int)lastPos.Y, (int)size.X, (int)size.Y, new(255, 0, 0, 150));

        if (fuelDelta < -100 || fuelDelta > 100) WarnFuelLow();


        if (fuelDelta > -126)
        {
            if (Raylib.IsKeyDown(leftControl))
            {
                currentPos.X--;
            }
        }

        if (fuelDelta < 126)
        {
            if (Raylib.IsKeyDown(rightControl))
            {
                currentPos.X++;
            }
        }
    }

    private void WarnFuelLow()
    {
        Raylib.DrawText("Fuel is low!", 100, 100, 24, Color.BLACK);
    }
}
