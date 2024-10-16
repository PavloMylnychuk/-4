using System;

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}

public class Rectangle
{
    public Point TopLeft { get; set; }
    public Point BottomRight { get; set; }

    public Rectangle(Point topLeft, Point bottomRight)
    {
        TopLeft = topLeft;
        BottomRight = bottomRight;
    }

    public bool Contains(Point point)
    {
        return point.X >= TopLeft.X && point.X <= BottomRight.X &&
               point.Y >= TopLeft.Y && point.Y <= BottomRight.Y;
    }
}

class Program
{
    static void Main(string[] args)
    {
        string[] rectangleInput = Console.ReadLine().Split();
        Point topLeft = new Point(int.Parse(rectangleInput[0]), int.Parse(rectangleInput[1]));
        Point bottomRight = new Point(int.Parse(rectangleInput[2]), int.Parse(rectangleInput[3]));

        Rectangle rectangle = new Rectangle(topLeft, bottomRight);

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] pointInput = Console.ReadLine().Split();
            Point point = new Point(int.Parse(pointInput[0]), int.Parse(pointInput[1]));

            Console.WriteLine(rectangle.Contains(point));
        }
    }
}
