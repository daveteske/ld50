using Godot;
using System;

public class Shieldold : StaticBody2D
{
    public Position2D PositionPoint;
    public float RotationAngle = 0;
    public bool IsActive;
    public Vector2 RotationPoint = Vector2.Zero;
    public float DistanceFromPoint = 2f;
    public float RotationAroundPoint = 0;
    public float RotationSpeed = 10.0f;

    public int PowerRemaining = 10;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // on mouse down?
        IsActive = true;
        RotationPoint = GetNode<Position2D>("../../Level01/ShieldRotationPoint").GlobalPosition;
        GD.Print("Rot", RotationPoint);
    }

    public override void _Process(float delta)
    {
        if (IsActive)
            DoTheMove(delta);

    }

    private void DoTheMove(float delta)
    {
        var mousePos = GetGlobalMousePosition();
        var angle_from_point_to_node = RotationPoint.DirectionTo(mousePos);

        RotationAroundPoint = Mathf.Atan2(angle_from_point_to_node.y, angle_from_point_to_node.x);

        GlobalPosition = RotationPoint;

        GlobalPosition += new Vector2(Mathf.Cos(RotationAroundPoint), Mathf.Sin(RotationAroundPoint)) * DistanceFromPoint;

        this.RotateToPoint(this.RotationPoint, delta);
        
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
