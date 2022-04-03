using Godot;
using ld50game.models;
using ld50game.signals;
using System;
using System.Collections.Generic;

public class main : Node2D
{
    [Export]
    public PackedScene IngredientScene;

    [Export]
    public PackedScene TrayScene;


    public Dictionary<int,Recipe> ActiveRecipes = new Dictionary<int,Recipe>();

    public CustomSignals CustomSignals;

    public int Score = 0;

    public Label ScoreLabel;

    public override void _Ready()
    {
        // node cache
        CustomSignals = GetNode<CustomSignals>("/root/CustomSignals");
        ScoreLabel = GetNode<Label>("HUD/ScoreLabel");

        // signals
        CustomSignals.Connect("TrayCompleted", this, "ProcessCompletedTray");
        CustomSignals.Connect("StartGame", this, "StartNewGame");


        CreateRecipe();
        CreateTray();
        DisplayPantry();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }

    public void CreateRecipe()
    {
        var recipe = new Recipe();
        recipe.CreateRecipeStep(new RecipeStep() { Ingredient = Pantry.RoundCrust, StepNumber = 1 });
        recipe.CreateRecipeStep(new RecipeStep() { Ingredient = Pantry.TomtoSauce, StepNumber = 2 });
        recipe.CreateRecipeStep(new RecipeStep() { Ingredient = Pantry.MozCheese, StepNumber = 3 });
        recipe.CreateRecipeStep(new RecipeStep() { Ingredient = Pantry.Pepperoni, StepNumber = 4, IsFlexible = true });
        recipe.CreateRecipeStep(new RecipeStep() { Ingredient = Pantry.Sausage, StepNumber = 4, IsFlexible = true });

        ActiveRecipes.Add(1, recipe);
    }

    public void CreateTray()
    {

        // instance a new tray
        var tray = (Tray)TrayScene.Instance();
     
        // Add a recipe to it
        tray.Recipe = ActiveRecipes[1];
        tray.Position = new Vector2(-65, 600);

        // Connect to the signal
        AddChild(tray);
    }

    public void DisplayPantry()
    {
        // select the distinct ingredients from the current recipes 

        // TODO select the things
        List<Ingredient> ActiveIngredients = new List<Ingredient>();
        ActiveIngredients.Add(Pantry.RoundCrust);
        ActiveIngredients.Add(Pantry.SquareCrust);
        ActiveIngredients.Add(Pantry.MozCheese);
        ActiveIngredients.Add(Pantry.CheddarCheese);
        ActiveIngredients.Add(Pantry.TomtoSauce);
        ActiveIngredients.Add(Pantry.PestoSauce);
        ActiveIngredients.Add(Pantry.Pepperoni);
        ActiveIngredients.Add(Pantry.Sausage);


        // spawn them left to right at consistent intervals we may need ingred groups for this
        var screenSize = GetViewport().GetVisibleRect().Size;
        var offset = (screenSize.x / (ActiveIngredients.Count + 1));

        var cnt = 0;
        // spawn them in
        foreach (var item in ActiveIngredients)
        {
            cnt += 1;
            var itemSpawn = (IngredientScene)IngredientScene.Instance();
            itemSpawn.Ingredient = item;
            itemSpawn.Position = new Vector2((offset * cnt), 100);
            (itemSpawn.GetNode<Sprite>("Dragable/Sprite")).Texture = (Texture)GD.Load(item.Image);
            AddChild(itemSpawn);
        }
    }

    internal void ProcessCompletedTray(int points)
    {
        this.Score += points;
        ScoreLabel.Text = this.Score.ToString();

    }

    internal void StartNewGame()
    {

        this.Score = 0;
        ScoreLabel.Text = this.Score.ToString();

    }
}
