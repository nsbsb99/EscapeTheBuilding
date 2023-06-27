using System;

namespace EscapeBuilding
{
    public class Battery
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
