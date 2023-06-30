using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeBuilding
{
    public class StrongFlash : RandomBattle
    {
        public void HolyFlash() //플래시 강출력 잔량 표시
        {
            if (flashNumber == 3)
            {
                Console.SetCursorPosition(104, 21);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("▣ ▣ ▣");
                Console.ResetColor();
            }

            else if (flashNumber == 2)
            {
                Console.SetCursorPosition(104, 21);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("▣ ▣     ");
                Console.ResetColor();
            }

            else if (flashNumber == 1)
            {
                Console.SetCursorPosition(104, 21);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("▣        ");
                Console.ResetColor();
            }

            else
            {
                Console.SetCursorPosition(113, 21);            
                Console.Write("          ");
            }
        }
    }
}
