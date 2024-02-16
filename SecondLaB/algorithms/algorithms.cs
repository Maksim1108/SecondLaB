using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab.algorithms
{
    internal class Algorithms
    {
        public int[] fillArray(int sizeOfArray)
        {
            int[] array = new int[sizeOfArray];

            Console.WriteLine($"Введите {sizeOfArray} целых чисел для заполнения массива:");

            for (int i = 0; i < sizeOfArray; i++)
            {
                Console.Write($"Элемент {i + 1}: ");
                // Парсим введенное пользователем значение в целое число
                if (!int.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                    i--; // Повторяем попытку для того же элемента
                }
            }

            return array;
        }
        public int findMissingValue(int start, int end, int[] array)
        {
            // Создаем массив булевых значений для отметки присутствующих значений
            bool[] present = new bool[end - start + 1];

            // Помечаем присутствующие значения в массиве
            foreach (int num in array)
            {
                if (num >= start && num <= end)
                {
                    present[num - start] = true;
                }
            }

            // Ищем первое отсутствующее значение
            for (int i = 0; i < present.Length; i++)
            {
                if (!present[i])
                {
                    return i + start;
                }
            }

            // Если все значения в интервале присутствуют в массиве, возвращаем -1
            return -1;
        }
    }
}
