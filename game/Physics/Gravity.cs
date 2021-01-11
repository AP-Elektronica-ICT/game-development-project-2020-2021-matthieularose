using System;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;

namespace GameDevProject.Physics
{
    public class Gravity : Force
    {
        //Voor simpliciteit geef ik in Direction ook al ineens een velocity
        public override Vector2 Direction { get; set; } = new Vector2(0, 10);
        public override Vector2 Acceleration { get; set; } = new Vector2(0, 9.81f);
    }
}
