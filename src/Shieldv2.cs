using Godot;
using System;

public class Shieldv2 : Node2D
{
    public float DamageModifier = 0f;
    public float HealingModifier = .1f;
    public int hits = 0;
    public int maxHits = 5;
    public CollisionShape2D staticColliderNode;
    public CollisionShape2D areaColliderNode;
    public override void _Ready()
    {
        staticColliderNode = (GetNode<CollisionShape2D>($"StaticBody2D/CollisionShape2D"));
        areaColliderNode = (GetNode<CollisionShape2D>($"Area2D/CollisionShape2D"));

        DamageModifier = 1.0f / maxHits;
    }

    public override void _Process(float delta)
    {
        if (hits > 0)
        {
            // regrow
        }
    }

    private void OnShieldBodyEntered(Node body)
    {
        if (body.IsInGroup("atoms"))
        {
            this.hits++;

            staticColliderNode.Scale -= new Vector2(0f, DamageModifier); 
            
            areaColliderNode.Scale -= new Vector2(0f, DamageModifier); 

            (GetNode<Sprite>("Sprite")).Scale -= new Vector2(0f, DamageModifier*2);

            // var sfxNode = (GetNode<AudioStreamPlayer>("ShieldHitSfx"));
            // sfxNode.Play();
            (GetNode<AudioStreamPlayer>("ShieldHitSfx")).Play();
            if (hits >= maxHits)
            {
                QueueFree();
            }
        }
    }
}
