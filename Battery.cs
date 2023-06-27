using System;

namespace EscapeBuilding
{
    public class Battery //타이머...?
    {
        //108,15에 잔량 표시하기 

        public void DrawBattery()
        {
            Console.SetCursorPosition(110, 5);
            Console.WriteLine("Battery");


            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(112, 7);
            Console.WriteLine("⁜⁜⁜");
            Console.SetCursorPosition(112, 8);
            Console.WriteLine("⁜⁜⁜");
            Console.SetCursorPosition(112, 9);
            Console.WriteLine("⁜⁜⁜");
            Console.SetCursorPosition(112, 10);
            Console.WriteLine("⁜⁜⁜");

            Console.ResetColor();

        }
    }
}
