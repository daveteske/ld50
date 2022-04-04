using Godot;
using System;

public class Shield : Node2D
{
    public float DamageModifier = 1f;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    private void OnShieldBodyEntered(Node body)
    {
        if (body.IsInGroup("atoms"))
        {
            var shape = (GetNode<CollisionShape2D>("CollisionShape2D")).Shape as CircleShape2D;
            shape.Radius -= DamageModifier;
        }
    }
}
