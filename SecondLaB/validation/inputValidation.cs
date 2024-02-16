using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondLab.validation
{
    internal class InputValidation
    {
        public int getInt()
        {
            while (true)
            {
                int userInput = 0;
                if (!int.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine("Попробуйте еще раз!");
                    Console.Write("> ");
                }
                else
                {
                    return userInput;
                }
            }
        }


        public double getDouble()
        {
            while (true)
            {
                double userInput = 0;
                if (!double.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine("Попробуйте еще раз!");
                    Console.Write("> ");
                }
                else
                {
                    return userInput;
                }
            }
        }

        public MENU_ITEMS getMenuItems()
        {
            while (true)
            {
                MENU_ITEMS userInput = 0;
                if (!MENU_ITEMS.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine("Попробуйте еще раз!");
                    Console.Write("> ");
                }
                else
                {
                    return userInput;
                }
            }
        }

        public SUBMENU getSubMenuChoice()
        {
            while (true)
            {
                SUBMENU userInput = 0;
                if (!SUBMENU.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine("Попробуйте еще раз!");
                    Console.Write("> ");
                }
                else
                {
                    return userInput;
                }
            }
        }

        public INPUT_CHOICE getChoice()
        {
            while (true)
            {
                INPUT_CHOICE userInput = 0;
                if (!INPUT_CHOICE.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine("Попробуйте еще раз!");
                    Console.Write("> ");
                }
                else
                {
                    return userInput;
                }
            }
        }
    }
}