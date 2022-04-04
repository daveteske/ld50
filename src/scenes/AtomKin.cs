using Godot;
using System;

public class AtomKin : KinematicBody2D
{
    public Vector2 Direction = Vector2.Down;

    public Vector2 Velocity = new Vector2(200, 200);

    public bool IsActive = true;

    public override void _Ready()
    {
        AddToGroup("atoms");
    }

    public override void _PhysicsProcess(float delta)
    {
        if (IsActive)
        {
            var collisionInfo = MoveAndCollide(Velocity * delta);
            if (collisionInfo != null)
            {
                Velocity = Velocity.Bounce(collisionInfo.Normal);
            }
        }
    }

    public void Stop()
    {
        IsActive = false;
    }

    public void Start()
    {
        IsActive = true;
    }
}
