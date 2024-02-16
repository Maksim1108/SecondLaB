using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab.fileWork
{
    internal class FileWork
    {
        public void saveOnFile(int sizeOfArray, int startInterval, int endInterval, int[] arr)
        {
            Console.Write("Введите имя файла для сохранения:\n> ");
            string filename = Console.ReadLine();

            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.Write($"{sizeOfArray} {startInterval} {endInterval} ");
                    foreach (int item in arr) {
                        writer.Write($"{item} ");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при сохранении данных: " + ex.Message);
            }
        }

        public bool loadFromFile(string filePath, out int sizeOfArray, out int startInterval, out int endInterval, out int[] arr)
        {

            sizeOfArray = startInterval = endInterval = 0;

            arr = new int[0];

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line = reader.ReadLine();
                    if (line != null)
                    {
                        string[] coordinates = line.Split(' ');
                        if (coordinates.Length > 0)
                        {
                            sizeOfArray = int.Parse(coordinates[0]);
                            arr = new int[sizeOfArray];
                            startInterval = int.Parse(coordinates[1]);
                            endInterval = int.Parse(coordinates[2]);

                            for (int i = 3; i < coordinates.Length; i++)
                            {
                                arr[i - 3] = int.Parse(coordinates[i]);
                            }
                        }
                        Console.WriteLine("\nДанные успешно загружены!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при чтении файла: " + ex.Message);
            }

            return false;
        }
    }
}
