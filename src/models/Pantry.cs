using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld50game.models
{
    public static class Pantry
    {


        public static Ingredient RoundCrust = new Ingredient { Name = "Round Crust", Image = "res://assests/round-crust.png", Type = (int)IngredientType.Crust};
        public static Ingredient SquareCrust = new Ingredient { Name = "Square Crust", Image = "res://assests/dirt.png", Type = (int)IngredientType.Crust };

        public static Ingredient TomatoSauce = new Ingredient { Name = "Tomato Sauce", Image = "res://assests/tomato-sauce.png", Type = (int)IngredientType.Sauce };
        public static Ingredient PestoSauce = new Ingredient { Name = "Pesto Sauce", Image = "res://assests/pesto-sauce.png", Type = (int)IngredientType.Sauce };

        public static Ingredient MozCheese = new Ingredient { Name = "Moz Cheese", Image = "res://assests/moz-cheese.png", Type = (int)IngredientType.Cheese };
        public static Ingredient CheddarCheese = new Ingredient { Name = "Cheddar Cheese", Image = "res://assests/cheddar-cheese.png", Type = (int)IngredientType.Cheese };

        public static Ingredient Pepperoni = new Ingredient { Name = "Pepperoni", Image = "res://assests/grass.png", Type = (int)IngredientType.Topping };
        public static Ingredient Sausage = new Ingredient { Name = "Sausage", Image = "res://assests/plant.png", Type = (int)IngredientType.Topping };

        public static List<Ingredient> GetAllIngredients()
        {
            return new List<Ingredient>
            {
                RoundCrust, SquareCrust,
                TomatoSauce, PestoSauce,
                MozCheese, CheddarCheese,
                Pepperoni, Sausage
            };
        }

        public static List<Ingredient> GetIngredientsByType(IngredientType type)
        {
            return GetAllIngredients().Where(x => x.Type == (int)type).ToList();
        }
    }


}
