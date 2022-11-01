using System;
using System.Collections.Generic;
using System.Linq;

namespace FigureApp
{
    [Serializable()]
    internal class Rectangle : FigureWithSides
    {
        public Rectangle(List<Point> points) : base(points)
        {
            DefineSides();
            FindPerimeter();
            FindCenter();
            FindArea();
            /*ReDefinePoints();*/
        }

        public void DefineSides()
        {
            if(Sides.Any()) Sides.Clear();
            Sides.Add(Math.Abs(Points[0].x - Points[Points.Count - 1].x));
            Sides.Add(Math.Abs(Points[0].y - Points[1].y));
        }



        public override void FindArea()
        {
            Area = Math.Abs(Sides[0] * Sides[1]);
        }

        public override void FindCenter()
        {
            double sumX = 0, sumY = 0;
            foreach (var p in Points)
            {
                sumX += p.x;
                sumY += p.y;
            }
            Center = new Point(sumX / 4, sumY / 4);
        }

        public override void MoveFigure(int moveByX, int moveByY)
        {
            foreach (var p in Points)
            {
                p.x += moveByX;
                p.y += moveByY;
            }
        }
    }
}
