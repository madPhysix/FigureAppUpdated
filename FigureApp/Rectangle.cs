using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization.Advanced;

namespace FigureApp
{
    [Serializable()]
    internal class Rectangle: Figure
    {
        public double sideA { get; private set; }
        public double sideB { get; private set; } 
        
        public Rectangle( List<Point> points): base(points)
        {
            
            ReDefinePoints();
        }

        public void ReDefinePoints()
        {
            sideA = Math.Abs(Points[0].x - Points[3].x);
            sideB = Math.Abs(Points[0].y - Points[1].y);
        }

      

        public override void FindArea()
        {

            Area = Math.Abs(sideA * sideB);
           
        }

        public override void FindPerimeter()
        {
            Perimeter = 2 * (sideA + sideB);
        }

        public override void FindCenter()
        {
            double sumX = 0, sumY = 0;
            foreach (var p in Points)
            { sumX += p.x;
                sumY += p.y;
            }
            this.Center = new Point(sumX/4, sumY/4);
        }

        public override void RotateFigure(double angle)
        {
              while (angle > 360) angle -= 360;
           
              foreach(var p in Points)
              {
                  p.x = p.x * Math.Cos(angle) - p.y * Math.Sin(angle);
                  p.y = p.y * Math.Cos(angle) + p.x * Math.Sin(angle);
              }
            
        }

        public override void MoveFigure(int moveByX, int moveByY)
        {
           foreach(var p in Points)
            {
                p.x += moveByX;
                p.y += moveByY;
            }
        }

        public override void Scale(double multiplier)
        {
            Points[0].x = Center.x - multiplier * (Center.x - Points[0].x);
            Points[0].y = Center.y - multiplier * (Center.y - Points[0].y);

            Points[1].x = Center.x - multiplier * (Center.x - Points[1].x);
            Points[1].y = Center.y - multiplier * (Center.y - Points[1].y);

            Points[2].x = Center.x - multiplier * (Center.x - Points[2].x);
            Points[2].y = Center.y - multiplier * (Center.y - Points[2].y);

            Points[3].x = Center.x - multiplier * (Center.x - Points[3].x);
            Points[3].y = Center.y - multiplier * (Center.y - Points[3].y);

            ReDefinePoints();
            FindArea();
            FindPerimeter();
        }

        
    }
}
