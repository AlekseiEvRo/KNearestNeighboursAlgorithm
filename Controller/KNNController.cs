using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN.Controller
{
    internal class KNNController
    {
        List<Model.Object> objects;
        List<Model.Object> nearObjects;

        public KNNController()
        {
            objects = new List<Model.Object>();
            nearObjects = new List<Model.Object>();
        }

        public List<Model.Object> GetObjectsByType(Model.Type type)
        {
            return objects.Where(o => o.Type == type).ToList();
        }
        public int GetNextObjectId()
        {
            return objects.Count + 1;
        }

        public void AddObject(Model.Object obj) {
            objects.Add(obj);
        }

        public void RemoveObjectsByType(Model.Type type) 
        {
            foreach (Model.Object obj in objects.Where(o => o.Type == type).ToList())
            {
                objects.Remove(obj);
            }
        }

        public void CalculateDistances()
        {
            var circleLocation = objects.First(o => o.Type == Model.Type.Circle);
            foreach(Model.Object obj in objects)
            {
                obj.CalculateDistanceToCircle(circleLocation.X, circleLocation.Y);
            }
        }

        public Model.Type CalculatecircleType(int k)
        {
            nearObjects = objects.Where(o => o.Type != Model.Type.Circle).OrderBy(o => o.DistanceToCircle).Take(k).ToList();

            var rectangleCount = nearObjects.Where(o => o.Type == Model.Type.Rectangle).Count();
            var triangleCount = nearObjects.Where(o => o.Type == Model.Type.Triangle).Count();

            if (rectangleCount > triangleCount)
                return Model.Type.Rectangle;

            if (rectangleCount < triangleCount)
                return Model.Type.Triangle;

            return Model.Type.Circle;
        }

        public List<Model.Object> GetNearObjects()
        {
            return nearObjects;
        }
    }
}
