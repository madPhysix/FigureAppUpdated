using System;
using System.Collections.Generic;

namespace FigureApp
{
    [Serializable()]
    public abstract class Figure
    {
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public List<Point> Points { get; set; }

        public Point Center { get; set; }

        public Figure(List<Point> points)
        {
            Points = points;
        }

        public abstract void FindCenter();
        public abstract void FindArea();
        public abstract void FindPerimeter();
        public abstract void MoveFigure(int moveByX, int moveByY);
        public abstract void RotateFigure(double angle);
        public abstract void Scale(double multiplier);
    }
}
