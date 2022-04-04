using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ld50game.signals
{
    public class CustomSignals : Node
    {
        [Signal]
        public delegate void GameOver();
        [Signal]
        public delegate void SetDangerLevel(int level);
    }
}
