using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _3dProjectPrototype
{
    class Circle
    {
        public Vector2 middle;
        public float radius;

        public Circle() { }

        public Circle(Vector2 middle, float radius)
        {
            this.middle = middle;
            this.radius = radius;
        }

        public void setPosition(Vector2 middle)
        {
            this.middle = middle;
        }

        public bool intersectsWith(Circle c)
        {
            var distancePow2 = (c.middle.X - this.middle.X) * (c.middle.X - this.middle.X) + (c.middle.Y - this.middle.Y) * (c.middle.Y - this.middle.Y);
            return distancePow2 < (c.radius + radius) * (c.radius + radius);                        /* since distance ^2 is used, the 
                                                                                                       (radius + radius) is squared too*/
        }
    }
    }
