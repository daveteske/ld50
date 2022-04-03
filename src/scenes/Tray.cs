using Godot;
using ld50game.models;
using ld50game.signals;
using System;

public class Tray : Node2D
{

    public bool IsMoving = true;
    public int Speed = 50;

    public string Level1;
    public string Level2;
    public string Level3;

    public Recipe Recipe;

    public CustomSignals CustomSignals;

    public override void _Ready()
    {
        CustomSignals = GetNode<CustomSignals>("/root/CustomSignals");
    }

    public override void _Process(float delta)
    {
        if (IsMoving)
        {
            Position = new Vector2(this.Position.x + (Speed * delta), Position.y);
        }

    }

    public void OnDestroyTimerTimeout()
    {
        this.QueueFree();
    }

    public bool TryAddComponent(Area2D dragableArea)
    {
        //GD.Print("Recipe ", Recipe);
        //foreach (var r in Recipe.RecipeSteps)
        //{
        //    GD.Print(r.Ingredient.Name);
        //}

        var componentNode = dragableArea.GetParent<IngredientScene>();

        var success = Recipe.TryAStep(componentNode.Ingredient);

        if (success)
        {
            AddToTray(componentNode);

            if (Recipe.CheckForCompleted())
            {
                GD.Print("COMPLETED");
                CustomSignals.EmitSignal(nameof(CustomSignals.TrayCompleted), 9);

                // use timer to destroy
                (GetNode<Timer>("DestroyTimer")).Start();
            }
        }

        return success;

    }

    internal void AddToTray(Node2D componentNode)
    {
        var newSprite = new Sprite();
        newSprite.Texture = (componentNode.GetNode<Sprite>("Dragable/Sprite")).Texture;
        newSprite.Scale = new Vector2(4, 4);
        newSprite.Visible = true;
        newSprite.ShowOnTop = true;
        AddChild(newSprite);

        componentNode.QueueFree();
        GD.Print("Added to tray");
    }
}
