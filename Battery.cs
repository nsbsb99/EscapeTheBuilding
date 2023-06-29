using System;
using System.Threading;

namespace EscapeBuilding
{
    public class Battery : PlayerChoice
    {
        private int batteryPercent = 100;
       
        public void StartBatteryTimer()
        {
            // 타이머 콜백 메서드 설정
            TimerCallback callback = new TimerCallback(DecreaseBatteryPercent);

            // 타이머 생성 및 시작
            timer = new Timer(callback, null, TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(15));
        }

        public void StopBatteryTimer()
        {
            // 타이머 중지
            timer?.Dispose();
        }

        private void DecreaseBatteryPercent(object state)
        {
            // 배터리 잔량 감소
            batteryPercent--;

            // 배터리 표시 업데이트
            DrawBattery();
        }


        public void DrawBattery()
        {

            Console.SetCursorPosition(110, 12);
            Console.WriteLine("Battery");

            if(batteryPercent == 100)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Green;

                Console.SetCursorPosition(112, 14);
                Console.WriteLine("⁜⁜⁜");
                Console.SetCursorPosition(112, 15);
                Console.WriteLine("⁜⁜⁜");
                Console.SetCursorPosition(112, 16);
                Console.WriteLine("⁜⁜⁜");
                Console.SetCursorPosition(112, 17);
                Console.WriteLine("⁜⁜⁜");

                Console.ResetColor();

                Console.SetCursorPosition(112, 19);
                Console.WriteLine($"{batteryPercent}");


            }


            if (batteryPercent <= 99 && batteryPercent >= 70)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Green;

                Console.SetCursorPosition(112, 14);
                Console.WriteLine("⁜⁜⁜");
                Console.SetCursorPosition(112, 15);
                Console.WriteLine("⁜⁜⁜");
                Console.SetCursorPosition(112, 16);
                Console.WriteLine("⁜⁜⁜");
                Console.SetCursorPosition(112, 17);
                Console.WriteLine("⁜⁜⁜");

                Console.ResetColor();

                Console.SetCursorPosition(112, 19);
                Console.WriteLine($" {batteryPercent}");
            }

            else if(batteryPercent<70 && batteryPercent>=30)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.SetCursorPosition(112, 16);
                Console.WriteLine("⁜⁜⁜");
                Console.SetCursorPosition(112, 17);
                Console.WriteLine("⁜⁜⁜");

                Console.ResetColor();

                Console.SetCursorPosition(112, 19);
                Console.WriteLine($"{batteryPercent}");

            }

            else if(batteryPercent <30 && batteryPercent>0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Red;

          
                Console.SetCursorPosition(112, 17);
                Console.WriteLine("⁜⁜⁜");

                Console.ResetColor();

                Console.SetCursorPosition(112, 19);
                Console.WriteLine($"{batteryPercent}");

            }

            else if (batteryPercent <=0)
            {
                StopBatteryTimer();

                Thread.Sleep(1500);
                Console.Clear();

                Console.SetCursorPosition(45, 15);
                Console.WriteLine("꺼진 손전등을 붙잡고 한참을 헤메다 떨어지고 말았다...");
                Thread.Sleep(3000);
                Console.Clear();
                Console.SetCursorPosition(42, 15);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("              Bad Ending 3: 꺼진 희망");
                Console.ResetColor();
                Thread.Sleep(3000);

                MainConsole mainConsole = new MainConsole();
                mainConsole.GameOver();
            }
        }
    }
}
