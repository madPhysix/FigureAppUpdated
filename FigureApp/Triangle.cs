using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureApp
{
    internal class Triangle: Figure
    {
        double sideAB, sideBC, sideCA;
  

        public Triangle(List<Point> points):base(points)
        {

        }

        public void DefineSides(List<Point> points)
        {

            sideAB = Math.Sqrt((points[0].x - points[1].x) * (points[0].x - points[1].x) +
               (points[0].y - points[1].y) * (points[0].y - points[1].y));

            sideBC = Math.Sqrt((points[1].x - points[2].x) * (points[1].x - points[2].x) +
               (points[1].y - points[2].y) * (points[1].y - points[2].y));

            sideCA = Math.Sqrt((points[2].x - points[0].x) * (points[2].x - points[0].x) +
               (points[2].y - points[0].y) * (points[2].y - points[0].y));

        }

        public override void FindArea()
        {
            double peri = Perimeter / 2;
            Area = Math.Sqrt(peri * (peri - sideAB) * (peri - sideBC) * (peri - sideCA));
        }

        public override void FindCenter()
        {
            Center.x = (Points[0].x + Points[1].x + Points[2].x)/3;
            Center.y = (Points[0].y + Points[1].y + Points[2].y)/3;
        }

        public override void FindPerimeter()
        {
            Perimeter = sideAB + sideBC + sideCA;
        }

        public override void MoveFigure(int moveByX, int moveByY)
        {
            foreach(Point point in Points)
            {
                point.x += moveByX;
                point.y += moveByY;
            }
            Center.x += moveByX;
            Center.y += moveByY;
        }

        public override void RotateFigure(double angle)
        {
            
        }

        public override void Scale(double multiplier)
        {
            foreach(var point in Points)
            {
                point.x =  Center.x - multiplier * (Center.x -point.x);
                point.y = Center.y - multiplier * (Center.y - point.y);
            }
        }

        
    }
}
