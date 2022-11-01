using System;
using System.Collections.Generic;

namespace FigureApp
{
    [Serializable()]
    internal class Triangle : FigureWithSides
    {
        public Triangle(List<Point> points) : base(points)
        {
            DefineSides();
            FindPerimeter();
            FindCenter();
            FindArea();
        }

        public void DefineSides()
        {
            for (int i = 0; i < Points.Count; i++)
            {
                if (i == Points.Count - 1)
                {
                    CalculateAndAddSide(i, 0);
                }
                else
                {
                    CalculateAndAddSide(i, i + 1);
                }
            }
        }

        private void CalculateAndAddSide(int index1, int index2)
        {
            Sides.Add(Math.Sqrt((Points[index1].x - Points[index2].x) * (Points[index1].x - Points[index2].x) +
                     (Points[index1].y - Points[index2].y) * (Points[index1].y - Points[index2].y)));
        }

        public override void FindArea()
        {
            double peri = Perimeter / 2;
            Area = Math.Sqrt(peri * (peri - Sides[0]) * (peri - Sides[1]) * (peri - Sides[2]));
        }

        public override void FindCenter()
        {
            double sumX = 0, sumY = 0;
            foreach (var p in Points)
            {
                sumX += p.x;
                sumY += p.y;
            }
            Center = new Point(sumX / 3, sumY / 3);
        }
    }
}
