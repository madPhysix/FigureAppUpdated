using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FigureApp
{

    [Serializable()]
    internal abstract class Figure
    {
        
        
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public List<Point> Points { get; set; }

        public Point Center { get; set; }

        public Figure(List<Point> Points)
        {
            this.Points = Points;
            this.FindArea();
            this.FindPerimeter();
            this.FindCenter();
           
        }

        public abstract void FindCenter();


        public abstract void FindArea();


        public abstract void FindPerimeter();


        public abstract void MoveFigure(int moveByX, int moveByY);


        public abstract void RotateFigure(double angle);


        public abstract void Scale(double multiplier);
        
    }
}
