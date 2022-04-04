using Godot;
using System;

public class ShieldsV2 : KinematicBody2D
{
    public Vector2 RotationPoint = Vector2.Zero;
    public float RotationSpeed = 10.0f;

    public bool IsActive = false;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        RotationPoint = GetNode<Position2D>("../Level01/ShieldRotationPoint").GlobalPosition;

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (IsActive)
            RotateToPoint(GetGlobalMousePosition(), delta);
    }


    //internal void RotateToTarget(Node2D target, float delta)
    //{
    //    var direction = target.GlobalPosition - GlobalPosition;
    //    var angleTo = this.Transform.x.AngleTo(direction);
    //    this.Rotate(Mathf.Sign(angleTo) * Mathf.Min(delta * RotationSpeed, Mathf.Abs(angleTo)));
    //}

    internal void RotateToPoint(Vector2 thePoint, float delta)
    {
        var direction = thePoint - GlobalPosition;       
        var angleTo = (this.Transform.x.AngleTo(direction)) ;
        this.Rotate(Mathf.Sign(angleTo) * Mathf.Min(delta * RotationSpeed, Mathf.Abs(angleTo)));

    }
}

