using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld50game.models
{
    public class RecipeStep
    {
        public Ingredient Ingredient { get; set; }
        public int StepNumber { get; set; }
        public int MinStep { get; set; }
        public bool IsFlexible { get; set; }
        public bool Completed { get; set; }
    }
}
