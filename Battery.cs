using System;

namespace EscapeBuilding
{
    public class Battery //타이머...?
    {
        //108,15에 잔량 표시하기 

        public void DrawBattery()
        {
            Console.SetCursorPosition(110, 15);
            Console.WriteLine("Battery");


            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(112, 17);
            Console.WriteLine("⁜⁜⁜");
            Console.SetCursorPosition(112, 18);
            Console.WriteLine("⁜⁜⁜");
            Console.SetCursorPosition(112, 19);
            Console.WriteLine("⁜⁜⁜");
            Console.SetCursorPosition(112, 20);
            Console.WriteLine("⁜⁜⁜");

            Console.ResetColor();

        }
    }
}
