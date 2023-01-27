using Raylib_cs;
using System.Numerics;

public class Canon
{
    //Temp characteristics of a bullet:
    Vector2 pos, power = new(10, 40);
    int powerLoss = 4;

    public Canon(Vector2 playerPos)
    {
        pos = playerPos + new Vector2(10, 10);
    }

    public void ShowTrajectory()
    {
        Vector2 trajectoryPoints = pos;
        Vector2 powerChange = power;

        for (int i = 0; i < 160; i += 20)
        {
            Raylib.DrawCircle((int)trajectoryPoints.X, (int)trajectoryPoints.Y, 5, Color.RED);
            trajectoryPoints = Vector2.Add(trajectoryPoints, new(powerChange.X, -powerChange.Y));
            powerChange.Y -= powerLoss;
        }
    }

    public void Shoot()
    {

    }

    public void Move(sbyte dist)
    {
        power = Vector2.Transform(power, Matrix3x2.CreateRotation((float)(dist / 57.2957795)));
    }

    public void Update(Vector2 playerPos)
    {
        pos = playerPos + new Vector2(10, 10);
    }
}
