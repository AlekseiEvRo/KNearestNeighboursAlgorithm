using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN.Model
{
    internal class Object
    {
        public int Id { get; set; }
        public Type Type { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public double DistanceToCircle { get; private set; }

        public Object(int id, float x, float y, Type type) 
        {
            Id = id;
            X = x;
            Y = y;
            Type = type;
        }

        public void CalculateDistanceToCircle(float X1, float Y1)
        {
            DistanceToCircle = Math.Sqrt(Math.Pow(this.X - X1, 2) + Math.Pow(this.Y - Y1,2));
        }
    }
}
