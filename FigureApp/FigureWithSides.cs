using System;
using System.Collections.Generic;

namespace FigureApp
{
    public abstract class FigureWithSides:Figure
    {
        public List<double> Sides { get; set; } = new List<double>();

        public FigureWithSides(List<Point> points):base(points)
        {
            
        }

        public override void RotateFigure(double angle)
        {
            while (angle > 360) angle -= 360;

            foreach (var p in Points)
            {
                p.x = p.x * Math.Cos(angle) - p.y * Math.Sin(angle);
                p.y = p.y * Math.Cos(angle) + p.x * Math.Sin(angle);
            }
        }

        public override void Scale(double multiplier)
        {
            foreach (var p in Points)
            {
                p.x = Center.x - multiplier * (Center.x - p.x);
                p.y = Center.y - multiplier * (Center.y - p.y);
            }

            //ReDefinePoints();
            FindArea();
            FindPerimeter();
        }

        public override void MoveFigure(int moveByX, int moveByY)
        {
            foreach (Point point in Points)
            {
                point.x += moveByX;
                point.y += moveByY;
            }
            FindCenter();
        }

        public override void FindPerimeter()
        {
            foreach (var side in Sides)
            {
                Perimeter += side;
            }
        }
    }
}
