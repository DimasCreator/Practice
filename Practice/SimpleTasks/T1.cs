using System;

namespace Practice.SimpleTasks
{
    public class T1
    {
        // CodeBlog #Task 910.
        // Создать класс с двумя переменными.
        // Добавить функцию вывода на экран и функцию изменения этих переменных.
        // Добавить функцию, которая находит сумму значений этих переменных,
        // и функцию которая находит наибольшее значение из этих двух переменных.

        private int _var1 = default;
        
        public void GetVar1()
        {
            Console.WriteLine(_var1);
        }

        public void SetVar1(int value)
        {
            _var1 = value;
        }
        
        private int _var2 = default;
        
        public void GetVar2()
        {
            Console.WriteLine(_var2);
        }

        public void SetVar2(int value)
        {
            _var2 = value;
        }

        public int Sum()
        {
            return _var1 + _var2;
        }

        public int MoreVariable()
        {
            return _var1 > _var2 ? _var1 : _var2;
        }
    }
}