using Godot;
using ld50game.signals;
using System;

public class DangerZone : Area2D
{
    public CustomSignals CustomSignals;

    public override void _Ready()
    {
        CustomSignals = GetNode<CustomSignals>("/root/CustomSignals");
    }

    public void OnDangerZoneBodyEntered(Node body)
    {
        if (body is AtomKin)
        {
            var allAreasPresent = GetOverlappingBodies();
            if (allAreasPresent.Count > 3)
                CustomSignals.EmitSignal(nameof(CustomSignals.GameOver));
            else
                CustomSignals.EmitSignal(nameof(CustomSignals.SetDangerLevel), allAreasPresent.Count);
        }
    }
}
