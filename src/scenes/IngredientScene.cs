using Godot;
using ld50game.models;
using System;

public class IngredientScene : Node2D
{
    public Ingredient Ingredient = new Ingredient();
    public Vector2 InitialPositon = new Vector2();

    public override void _Ready()
    {
        GD.Print(Name, " Ready: ", Ingredient.Name, " Position: ", Position);
        InitialPositon = Position;
    }

}
