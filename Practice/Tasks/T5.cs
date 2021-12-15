using System;

namespace Practice.Tasks
{
    /// <summary> // TODO: Доделать
    /// Три попарно непараллельные прямые заданы коэффициентами ai, bi, ci соответствующего уравнения aix + biy = ci.
    /// Коэффициенты ai и bi не могут быть одновременно равны нулю.
    /// Требуется написать программу, определяющую площадь треугольника, образованного этими прямыми.
    /// </summary>
    public static class T5
    {
        private static EquationLine l1 = new (2, 3, 4);
        private static EquationLine l2 = new (3, 3, 4);
        private static EquationLine l3 = new (4, 3, 4);

        public static void Task()
        {
            if (l1.IsParallelToLine(l2) || l1.IsParallelToLine(l3) || l3.IsParallelToLine(l2))
            {
                throw new Exception();
            }
            l1.Display();
            l2.Display();
            l3.Display();
            
            
            
        }
    }

    internal class EquationLine
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }

        public EquationLine(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
            Validation();
        }

        public void Display()
        {
            Console.WriteLine($"{A}x + {B}y = {C}");
        }
        private void Validation()
        {
            if (A == 0 && B == 0) throw new Exception();
        }

        public bool IsParallelToLine(EquationLine line)
        {
            return Math.Abs(A) - Math.Abs(line.A) == 0;
        }
    }
    
}