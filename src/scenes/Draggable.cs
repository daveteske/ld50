using Godot;
using System;

public class Draggable : Area2D
{
    [Export]
    public string GroupName = "dragable";

    public Vector2 TouchPosition = Vector2.Zero;
    public bool IsDragging = false;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        AddToGroup(GroupName);
    }

    public override void _Input(InputEvent @event)
    {
        if (!IsDragging)
            return;

        if (@event.IsActionReleased("ui_touch"))
            IsDragging = false;

        if (@event is InputEventMouseMotion)
        {
            Position -= TouchPosition - (@event as InputEventMouseMotion).Position;
            TouchPosition = (@event as InputEventMouseMotion).Position;
        }
    }

    // Signals
    public void OnDragableInputEvent(Camera camera, InputEvent @event, int shapeIdx)
    {
        if (@event.IsActionPressed("ui_touch"))
        {
            if (IsOnTop())
            {
                IsDragging = true;
                TouchPosition = (@event as InputEventMouse).Position;
            }
        }
    }

    public void OnDragableMouseEntered()
    {
        AddToGroup(GroupName + "hovered");
    }

    public void OnDragableMouseExited()
    {
        RemoveFromGroup(GroupName + "hovered");
    }

    // Helpers
    public bool IsOnTop()
    {
        foreach (Node dragable in GetTree().GetNodesInGroup(GroupName + "hovered"))
        {
            if (dragable.GetIndex() > GetIndex())
                return false;
        }

        return true;
    }
}
