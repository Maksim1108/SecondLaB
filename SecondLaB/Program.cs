using SecondLab.algorithms;
using SecondLab.interfacee;
using SecondLab.validation;
using SecondLab.fileWork;
using SecondLab.tests;
using System;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
        Interfacee interfacee = new Interfacee();
        InputValidation inputValidation = new InputValidation();
        Algorithms algorithms = new Algorithms();
        FileWork fileWork = new FileWork();
        Tests tests = new Tests();
        MENU_ITEMS userMenuChoice;

        int startInterval = 0, endInterval = 0;
        int missingValue;

        int sizeOfArray = 0;
        int[] arr = new int[sizeOfArray] ;

        string filePath;

        interfacee.showInfo();

        do
        {
            interfacee.showMenu();
            Console.Write("> ");
            userMenuChoice = inputValidation.getMenuItems();

            switch (userMenuChoice)
            {
                case MENU_ITEMS.START_PROGRAMM:
                    INPUT_CHOICE choice;
                    SUBMENU subMenuChoice;
                    interfacee.showInputTypeChoice();
                    do
                    {
                        choice = inputValidation.getChoice();

                        switch (choice)
                        {
                            case INPUT_CHOICE.BY_HANDS:
                                Console.Write("Введите размер массива:\n> ");
                                sizeOfArray = inputValidation.getInt();

                                arr = algorithms.fillArray(sizeOfArray);

                                Console.Write("Введите начало интервала:\n> ");
                                startInterval = inputValidation.getInt();
                                Console.Write("Введите конец интервала:\n> ");
                                endInterval = inputValidation.getInt();

                                missingValue = algorithms.findMissingValue(startInterval, endInterval, arr);

                                if (missingValue != -1)
                                {
                                    Console.WriteLine("Первое отсутствующее значение в интервале [{0}, {1}] массива: {2}", startInterval, endInterval, missingValue);
                                }
                                else
                                {
                                    Console.WriteLine("Нет отсутствующих значений в интервале [{0}, {1}] массива.", startInterval, endInterval);
                                }
                                break;
                            case INPUT_CHOICE.LOAD_FROM_FILE:
                                Console.WriteLine("\n[!]Загрузка из файла");
                                Console.Write("\nВведите название файла:\n> ");
                                filePath = Console.ReadLine();
                                bool flag = fileWork.loadFromFile(filePath, out sizeOfArray, out startInterval, out endInterval, out arr);

                                missingValue = algorithms.findMissingValue(startInterval, endInterval, arr);

                                if (missingValue != -1)
                                {
                                    Console.WriteLine("Первое отсутствующее значение в интервале [{0}, {1}] массива: {2}", startInterval, endInterval, missingValue);
                                }
                                else
                                {
                                    Console.WriteLine("Нет отсутствующих значений в интервале [{0}, {1}] массива.", startInterval, endInterval);
                                }

                                if (!flag)
                                {
                                    if (sizeOfArray > 0)
                                    {
                                        Console.WriteLine("Хотите сохранить данные в файл?\n");
                                        interfacee.showChoice();
                                        subMenuChoice = inputValidation.getSubMenuChoice();

                                        switch (subMenuChoice)
                                        {
                                            case SUBMENU.YES:
                                                fileWork.saveOnFile(sizeOfArray, startInterval, endInterval, arr);
                                                Console.WriteLine("\nДанные успешно сохранены !");
                                                break;
                                            case SUBMENU.NO:
                                                Console.WriteLine("\nВы решили не сохранять данные в файл");
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nОтрезок и прямоугольник не пересекаются.\n");
                                }
                                break;

                        }
                    } while (choice != INPUT_CHOICE.BY_HANDS && choice != INPUT_CHOICE.LOAD_FROM_FILE);

                    break;

                case MENU_ITEMS.START_TESTS:
                    tests.runAllTests();
                    break;

                case MENU_ITEMS.QUIT:
                    Console.WriteLine("\nЗавершение работы программы.");
                    break;

                default:
                    Console.WriteLine("Неправильный ввод. Попробуйте снова.\n");
                    break;
            }
        } while (userMenuChoice != MENU_ITEMS.QUIT);
    }
}
