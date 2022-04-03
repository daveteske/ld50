using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld50game.models
{
    public static class Pantry
    {
        public static Ingredient RoundCrust = new Ingredient { Name = "Round Crust", Image = "res://assests/round-crust.png" };
        public static Ingredient SquareCrust = new Ingredient { Name = "Square Crust", Image = "res://assests/dirt.png" };

        public static Ingredient TomtoSauce = new Ingredient { Name = "Tomato Sauce", Image = "res://assests/tomato-sauce.png" };
        public static Ingredient PestoSauce = new Ingredient { Name = "Pesto Sauce", Image = "res://assests/pesto-sauce.png" };

        public static Ingredient MozCheese = new Ingredient { Name = "Moz Cheese", Image = "res://assests/moz-cheese.png" };
        public static Ingredient CheddarCheese = new Ingredient { Name = "Cheddar Cheese", Image = "res://assests/cheddar-cheese.png" };

        public static Ingredient Pepperoni = new Ingredient { Name = "Pepperoni", Image = "res://assests/grass.png" };
        public static Ingredient Sausage = new Ingredient { Name = "Sausage", Image = "res://assests/plant.png" };
    }
}
