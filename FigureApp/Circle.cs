using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
namespace FigureApp
{
    internal class Circle : Figure
    {
        public double radius;

      


        public Circle(List<Point> points) : base(points)
        {


            radius = Math.Sqrt(((points[0].x - points[1].x) * (points[0].x - points[1].x)) +
                ((points[0].y - points[1].y) * (points[0].y - points[1].y)));

        }
        public override void FindArea()
        {
            Area = Math.PI * radius * radius;

        }
        public override void FindPerimeter()
        {
            Perimeter = 2 * Math.PI * radius;

        }
        public override void Scale(double multiplier)
        {
            radius = radius * multiplier;
            this.FindPerimeter();
            this.FindArea();
        }
        public override void MoveFigure(int MoveByX, int MoveByY)
        {
            Points[0].x += MoveByX;
            Points[0].y += MoveByY;
            Points[1].x += MoveByX;
            Points[1].y += MoveByY;
        }
        public override void RotateFigure(double angle)
        {
            Console.WriteLine("Bro.. Why you rotate the circle?!...");
        }
        public override void FindCenter()
        {
            this.Center = Points[0];
        }
        public void OnTheScreen()
        {
            Console.WriteLine(radius + "The coordinates of center are: " + Points[0].x + " and " + Points[0].y);
        }
    }
}
