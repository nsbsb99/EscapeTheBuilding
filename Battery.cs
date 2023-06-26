﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeBuilding
{
    public class Battery : MainConsole
    {
        public void DrawBattery()
        {
            Console.SetCursorPosition(108, 8);
            Console.WriteLine("Battery");

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Green;
         
            Console.SetCursorPosition(110, 10);
            Console.WriteLine("⁜⁜⁜");
            Console.SetCursorPosition(110, 11);
            Console.WriteLine("⁜⁜⁜");
            Console.SetCursorPosition(110, 12);
            Console.WriteLine("⁜⁜⁜");
            Console.SetCursorPosition(110, 13);
            Console.WriteLine("⁜⁜⁜");
            Console.ResetColor();
        }
    }
}
