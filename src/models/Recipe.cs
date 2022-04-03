using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld50game.models
{
    public class Recipe
    {

        public List<RecipeStep> RecipeSteps = new List<RecipeStep>();


        internal void CreateRecipeStep(RecipeStep recipeStep)
        {
            recipeStep.Completed = false; // just in case 
            RecipeSteps.Add(recipeStep);
        }

        public bool TryAStep(Ingredient ingredient)
        {
            // check for completed
            var next = GetNextIngredients();
            if (next.Any(i => i.Name == ingredient.Name))
            {
                // mark completed 
                RecipeSteps.SingleOrDefault(r => r.Ingredient.Name == ingredient.Name).Completed = true;
                GD.Print("TryAStep Success: ", ingredient.Name);
                return true;
            }

            GD.Print("TryAStep Failed: ", ingredient.Name);
            foreach (var item in next)
            {
                GD.Print("Next Item: ", item.Name);
            }
            return false;
        }

        internal bool CheckForCompleted()
        {
           return RecipeSteps.All(r => r.Completed);
        }

        internal List<Ingredient> GetNextIngredients()
        {
            var stepsRemaining = RecipeSteps.Where(r => r.Completed == false).OrderBy(r => r.StepNumber);
            var onlyFlexible = stepsRemaining.All(s => s.IsFlexible);

            if (onlyFlexible)
                return stepsRemaining.Select(r => r.Ingredient).ToList();
            else
                return new List<Ingredient>() { stepsRemaining.Select(r => r.Ingredient).First() };
        }
    }
}
