using System;
using System.Collections.Generic;


namespace Practice.Tasks
{
    public class T1
    {
        // На стандартный вход подается логическое выражение и его булевы значения, необходимо вернуть результат самого логического выражения.
        // Список возможных логических операторов:
        // & - логическое И
        // | - логическое ИЛИ
        // ! - отрицание
        // = - эквивалентность
        // Приоритет операторов соответствует стандартным приоритетам алгебры логики.
        //
        // Входные данные: a&b|c=d&!a a True b False c True d True
        // Выходные данные: False
        
        // Тестовые данные:
        // a&b|c=d&!a a True b False c True d True -> False
        // a&!b&a&a|!c=d&!a|!a|!b a True b False c True d True -> True
        // a&!b&c|a|a|c=c&b a True b False c True -> False
        // a&b&c&b&c&!a|!a&b=b|c|a a True b False c True -> False
        // a&b&c=!a|!k&d a True b False c True d True k True -> True
        // a&!b&a&a|!c=d a True b False c True d True -> True
        
        public static bool Task(string input)
        {
            string expression = GetBooleanExpressionFromString(input);
            string[] expressions = expression.Split('=');
            bool result = SolveBooleanExpression(expressions[0]) == SolveBooleanExpression(expressions[1]);
            return result;
        }
        private static string GetBooleanExpressionFromString(string input)
        {
            string[] elements = input.Split(' ');
            Dictionary<string, int> members = new Dictionary<string, int>();
            
            for (int i = 1; i < elements.Length; i += 2)
            {
                members[elements[i]] = bool.Parse(elements[i + 1]) ? 1 : 0;
            }

            foreach (var pair in members)
            {
                elements[0] = elements[0].Replace(pair.Key.ToString(), pair.Value.ToString());
            }
            
            return elements[0];
        }
        private static bool SolveBooleanExpression(string expression)
        {
            for (var i = 0; i < expression.Length; i++)
            {
                if (expression[i] != '!') continue;
                expression = expression.Remove(i, 1);
                expression = expression.Insert(i, expression[i] == '0' ? "1" : "0");
                expression = expression.Remove(i + 1, 1);
            }
            
            var multiplicationOperations = expression.Split('|');

            for (var j = 0; j < multiplicationOperations.Length; j++)
            {
                for (var i = 0; i < multiplicationOperations[j].Length; i++)
                {
                    if (multiplicationOperations[j][i] != '&') continue;

                    if (multiplicationOperations[j][i - 1] == '0' || multiplicationOperations[j][i + 1] == '0')
                    {
                        multiplicationOperations[j] = multiplicationOperations[j].Insert(i + 2, "0");
                        multiplicationOperations[j] = multiplicationOperations[j].Remove(i - 1, 3);
                        i--;
                    }
                    else
                    {
                        multiplicationOperations[j] = multiplicationOperations[j].Insert(i + 2, "1");
                        multiplicationOperations[j] = multiplicationOperations[j].Remove(i - 1, 3);
                        i--;
                    }
                }
            }

            string additionOperations = multiplicationOperations[0];
            for (int i = 1; i < multiplicationOperations.Length; i++)
            {
                additionOperations += "|" + multiplicationOperations[i];
            }

            for (int i = 0; i < additionOperations.Length; i++)
            {
                if (additionOperations[i] != '|') continue;

                if (additionOperations[i - 1] == '0' && additionOperations[i + 1] == '0')
                {
                    additionOperations = additionOperations.Insert(i + 2, "0");
                    additionOperations = additionOperations.Remove(i - 1, 3);
                    i--;
                }
                else
                {
                    additionOperations = additionOperations.Insert(i + 2, "1");
                    additionOperations = additionOperations.Remove(i - 1, 3);
                    i--;
                }
            }
            return additionOperations == "1";
        }
    }
}