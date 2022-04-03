using Godot;
using System;

public class DropTarget : Area2D
{
    public override void _Ready()
    {
        
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionReleased("ui_touch"))
        {
            foreach(Area2D area in GetOverlappingAreas())
            {
                // TODO Move this to send signal to the parent 

                var parent = GetParent(); // aka the tray
                if (parent is Tray)
                {
                    (parent as Tray).TryAddComponent(area);
                }
            }
        }
    }

    // Signals
    public void OnDropTargetAreaEntered(Area2D area)
    {
        // hightlight
        GD.Print("Area Entered by ", area.Name);
        var sprite = area.GetNode<Sprite>("Sprite");
        sprite.Rotation = 45f;
    }

    public void OnDropTargetAreaExited(Area2D area)
    {
        // remove highlight

        var sprite = area.GetNode<Sprite>("Sprite");
        sprite.Rotation = 0f;
    }
}
