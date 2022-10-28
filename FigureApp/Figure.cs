using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FigureApp 
{
    
    internal abstract class Figure
    {
        
        public string name { get; private set; }
        public double Area { get; protected set; }
        public double Perimeter { get; protected set; }
        public List<Point> Points { get; protected set; }

        public Point Center { get; protected set; }

        public Figure(List<Point> Points)
        {
            this.Points = Points;
            this.FindArea();
            this.FindPerimeter();
            this.FindCenter();
            this.name = name;
        }

        public abstract void FindCenter();


        public abstract void FindArea();


        public abstract void FindPerimeter();


        public abstract void MoveFigure(int moveByX, int moveByY);


        public abstract void RotateFigure(double angle);


        public abstract void Scale(double multiplier);
        
    }
}
