using System;
using Microsoft.Xna.Framework;

namespace GameDevProject.Physics
{
    //Abstracte klasse voor alle krachten die op een GameObject kunnen toegepast worden
    public abstract class Force
    {
        public abstract Vector2 Direction { get; set; }
        public abstract Vector2 Acceleration { get; set; }
    }
}
