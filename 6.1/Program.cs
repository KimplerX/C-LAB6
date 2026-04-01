using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== 1. Перевірка конструкторів ===");
        TPTriangle t1 = new TPTriangle(); // Без параметрів
        TPTriangle t2 = new TPTriangle(3, 4); // З параметрами
        TPTriangle t3 = new TPTriangle(t2); // Копіювання (t3 буде копією t2)

        t1.Print();
        t2.Print();
        
        Console.WriteLine($"\nПлоща t2: {t2.GetArea()}");
        Console.WriteLine($"Периметр t2: {t2.GetPerimeter()}");

        Console.WriteLine("\n=== 2. Перевантаження операторів ===");
        TPTriangle t4 = new TPTriangle(5, 12);
        
        TPTriangle sumTriangle = t2 + t4; 
        Console.Write("Сума t2 + t4: ");
        sumTriangle.Print();

        TPTriangle multiplied = t2 * 2;
        Console.Write("Множення t2 на 2: ");
        multiplied.Print();

        Console.WriteLine("\n=== 3. Порівняння ===");
        int comparison = t2.CompareTo(t4);
        if (comparison > 0) Console.WriteLine("Трикутник t2 більший за t4");
        else if (comparison < 0) Console.WriteLine("Трикутник t2 менший за t4");
        else Console.WriteLine("Трикутники рівні");
    }
}

public class TPTriangle
{
    private double _a;
    private double _b;


    public TPTriangle()
    {
        _a = 1;
        _b = 1;
    }

    public TPTriangle(double a, double b)
    {
        _a = a;
        _b = b;
    }

    public TPTriangle(TPTriangle other)
    {
        _a = other._a;
        _b = other._b;
    }


    public void Input()
    {
        Console.Write("Введіть перший катет: ");
        _a = double.Parse(Console.ReadLine()!);
        Console.Write("Введіть другий катет: ");
        _b = double.Parse(Console.ReadLine()!);
    }

    public void Print()
    {
        Console.WriteLine($"Прямокутний трикутник (катети: a={_a}, b={_b})");
    }

    public double GetArea()
    {
        return 0.5 * _a * _b;
    }

    public double GetPerimeter()
    {
        double hypotenuse = Math.Sqrt(_a * _a + _b * _b); 
        return _a + _b + hypotenuse;
    }

    public int CompareTo(TPTriangle other)
    {
        double area1 = this.GetArea();
        double area2 = other.GetArea();

        if (area1 > area2) return 1;
        if (area1 < area2) return -1;
        return 0;
    }


    public static TPTriangle operator +(TPTriangle t1, TPTriangle t2)
    {
        return new TPTriangle(t1._a + t2._a, t1._b + t2._b);
    }

    public static TPTriangle operator -(TPTriangle t1, TPTriangle t2)
    {
        return new TPTriangle(Math.Abs(t1._a - t2._a), Math.Abs(t1._b - t2._b));
    }

    public static TPTriangle operator *(TPTriangle t, double number)
    {
        return new TPTriangle(t._a * number, t._b * number);
    }
}