using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            List<Figure> ListOfFigures = new List<Figure>();
            string saver = "";
            int choice;
            while (true)
            {
                Console.WriteLine("\n1)show all figures\n2)create a figure\n3)change figure\n4)save to file\n0)exit");
                bool parsed = int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
            {
               
                case 1:
                    {
                            StreamReader reader = new StreamReader("figure.txt");
                            string line = "";
                            
                            
                                line += reader.ReadToEnd();
                                reader.Close();
                            
                            Console.Write(line);
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
                                        saver += $"The area of this circle is {circle.Area} and the perimeter is {circle.Perimeter}\n";
                                        flag = true;
                                        ListOfFigures.Add(circle);
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
                                        saver = saver + ("The area of rectangle is: "+ rectangle.Area + " and Perimeter of rectangle is: " + rectangle.Perimeter + "\n");
                                        flag = true;
                                        ListOfFigures.Add(rectangle);
                                        break;
                                        

                                    case 3:
                                        Point point21 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        Point point22 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        Point point23 = new Point(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                        List<Point> pointsOfTriangle = new List<Point> { point21, point22, point23 };

                                        Triangle triangle = new Triangle(pointsOfTriangle);
                                        triangle.FindCenter();
                                        triangle.FindArea();
                                        triangle.FindPerimeter();
                                        saver += "The area of triangle is: "+ triangle.Area + " and Perimeter of triangle is: " + triangle.Perimeter + "\n"; 
                                        ListOfFigures.Add(triangle);
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
                            Console.WriteLine("Choose what you want to change: \n 1)Move the figure \n 2)Rotate the figure \n 3)Scale the figure \n 4) Delete the Figure");
                            int whatToDo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Choose the index of element you want to change(begins from zero): 1");
                            int index = Convert.ToInt32(Console.ReadLine());
                            switch (whatToDo)
                            {
                                case 1:
                                    Console.WriteLine("Now define how much you want to move by X and Y");
                                    ListOfFigures[index].MoveFigure(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case 2:
                                    Console.WriteLine("Define how many degrees you want to rotate it");
                                    ListOfFigures[index].RotateFigure(Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case 3:
                                    Console.WriteLine("Define how many times you want to scale your figure");
                                    ListOfFigures[index].Scale(Convert.ToInt32(Console.ReadLine()));
                                    break;
                                case 4:
                                    Console.WriteLine("I'm deleting this figure");
                                    ListOfFigures.RemoveAt(index);
                                    saver = "";
                                    foreach(Figure p in ListOfFigures)
                                    {
                                        saver = $"The area of {p.ToString()} is {p.Area} and Perimeter of {p.ToString()} is {p.Perimeter}\n";
                                    }
                                    break;
                            }


                        break;
                    }
                case 4:
                    {
                            StreamWriter writer = new StreamWriter("figure.txt",true);
                            writer.WriteLine(saver);
                            saver = "";
                            writer.Close();
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
                            Console.WriteLine("duz emelli bir wey yaz!");
                        }
                            break;
                    }
            }
        }
        }
    }
}
