using System;

namespace EscapeBuilding
{
    public class Battery : PlayerChoice
    {
        //108,15에 잔량 표시하기 

        public void DrawBattery()
        {
            Console.SetCursorPosition(110, 15);
            Console.WriteLine("Battery");


            if (batteryPercent <= 100 && batteryPercent >= 70)
            {
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

                Console.SetCursorPosition(112, 22);
                Console.WriteLine($"{batteryPercent}");
            }

            else if(batteryPercent<70 && batteryPercent>=30)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.SetCursorPosition(112, 19);
                Console.WriteLine("⁜⁜⁜");
                Console.SetCursorPosition(112, 20);
                Console.WriteLine("⁜⁜⁜");

                Console.ResetColor();

                Console.SetCursorPosition(112, 22);
                Console.WriteLine($"{batteryPercent}");

            }

            else if(batteryPercent <30 && batteryPercent>0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Red;

          
                Console.SetCursorPosition(112, 20);
                Console.WriteLine("⁜⁜⁜");

                Console.ResetColor();

                Console.SetCursorPosition(112, 22);
                Console.WriteLine($"{batteryPercent}");

            }

            else if (batteryPercent <=0)
            {
                //배터리 소진으로 인한 게임오버 추가. 

            }


        }
    }
}
