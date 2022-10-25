using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FigureApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            while (true)
            {
                Console.WriteLine("\n1)show all figures\n2)create a figure\n3)change figure\n4)save to file\n0)exit");
                bool parsed = int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
            {
               
                case 1:
                    {
                            StreamReader reader = new StreamReader("wassup.txt");
                            string line = null;
                            
                            

                                line += reader.ReadToEnd();
                                
                            
                            Console.WriteLine(line);
                        break;
                    }
                case 2:
                    {
                            Console.WriteLine("Please, choose the figure you want to create:\n" +
                                "1)Circle\n" +
                                "2)Rectangle(square)\n" +
                                "3)Triangle\n");
                            int underChoice = Convert.ToInt32(Console.ReadLine());
                            bool flag = false;
                            while (flag == false)
                            {
                                switch (underChoice)
                                {
                                    case 1:
                                        Console.WriteLine("Please, enter the coordinates of the center, and any other point of your circle: ");

                                        Point point1 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        Point point2 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        List<Point> pointsOfCircle = new List<Point> { point1, point2 };

                                        Circle circle = new Circle(pointsOfCircle);
                                        circle.FindCenter();
                                        circle.FindArea();
                                        circle.FindPerimeter();
                                        Console.WriteLine("The area of circle is: " + circle.Area + " and radius of circle is: " + circle.radius + " and the perimeter of circle is:  " + circle.Perimeter);
                                        flag = true;
                                        break;

                                    case 2:
                                        Console.WriteLine("Please, enter the coordinates of your rectangle point by point: ");

                                        Point point11 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        Point point12 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        Point point13 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        Point point14 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        List<Point> pointsOfRectangle = new List<Point> { point11, point12, point13, point14 };

                                        Rectangle rectangle = new Rectangle(pointsOfRectangle);
                                        rectangle.FindCenter();
                                        rectangle.FindArea();
                                        rectangle.FindPerimeter();
                                        Console.WriteLine("The area of rectangle is: "+ rectangle.Area + " and Perimeter of rectangle is: " + rectangle.Perimeter);
                                        flag = true;
                                        break;
                                        

                                    case 3:
                                        Point point21 = new Point(Console.Read(), Console.Read());
                                        Point point22 = new Point(Console.Read(), Console.Read());
                                        Point point23 = new Point(Console.Read(), Console.Read());
                                        List<Point> pointsOfTriangle = new List<Point> { point21, point22, point23 };

                                        Triangle triangle = new Triangle(pointsOfTriangle);
                                        flag = true;
                                        break;
                                    default:
                                        Console.WriteLine("There are no such thing as this -_-");
                                        break;
                                }
                            }
                        break;
                    }
                case 3:
                    {
                        //change figure
                        break;
                    }
                case 4:
                    {
                        //save to file
                        break;
                    }
                default:
                    {
                        if(parsed)
                        {
                            if(choice == 0)
                                {
                                    Console.WriteLine("Ended!");
                                    Environment.Exit(0);
                                    return;
                                }
                                Console.WriteLine("Enter numbers according to menu!");
                        }
                        else
                        {
                            Console.WriteLine("duz emelli bir wey yaz gijd");
                        }
                            break;
                    }
            }
        }
        }
    }
}
