using System;
using System.Threading;
namespace piskvorky
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice; //Hráč si určuje políčko
        // když je flag value 1, někdo vyhrál
        // když je flag -1, je to remíza
        static int flag = 0;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Hráč 1 má X");
                Console.WriteLine("Hráč 2 má O");
                Console.WriteLine("\n");
                if (player % 2 == 0)//šance na výhru
                {
                    Console.WriteLine("Hráč 2 hraje");
                }
                else
                {
                    Console.WriteLine("Hráč 1 hraje");
                }
                Console.WriteLine("\n");
                Board();// Funkce board
                choice = Convert.ToInt32(Console.ReadLine());//Tahy hráčů
                // zjistí jestli je vybrané políčko zabrané nebo ne
                if (arr[choice] != 'X' && arr[choice] != 'O')
                {
                    if (player % 2 == 0) //když hraje hráč 2 napsat O jinak napsat X
                    {
                        arr[choice] = 'O';
                        player++;
                    }
                    else
                    {
                        arr[choice] = 'X';
                        player++;
                    }
                }
                else
                //Když je místo zabrané napíše text a načte znovu
                {
                    Console.WriteLine("Pole {0} je již zabrané s {1}", choice, arr[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Prosím počkej 3 sekundy");
                    Thread.Sleep(3000);
                }
                flag = CheckWin();// zjišťuje jestli někdo vyhrál
            }
            while (flag != 1 && flag != -1);
            // Pojede dokud není pole zaplněné
            Console.Clear();
            Board();// Znovu zobrazí pole
            if (flag == 1)
            // Když je jedna tak poslední na tahu vyhrál
            {
                Console.WriteLine("Hráč {0} vyhrál", (player % 2) + 1);
            }
            else// když je -1 je to remíza
            {
                Console.WriteLine("Remíza");
            }
            Console.ReadLine();
        }
        // Vytváření pole
        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }
        //Zjišťuje jestli někdo vyhrál
        private static int CheckWin()
        {
            #region výhra řádky
            //první řada
            if (arr[1] == arr[2] && arr[2] == arr[3])
            {
                return 1;
            }
            //druhá řada
            else if (arr[4] == arr[5] && arr[5] == arr[6])
            {
                return 1;
            }
            //třetí řada
            else if (arr[6] == arr[7] && arr[7] == arr[8])
            {
                return 1;
            }
            #endregion
            #region výhra sloupci
            //první sloupec
            else if (arr[1] == arr[4] && arr[4] == arr[7])
            {
                return 1;
            }
            //druhý sloupec
            else if (arr[2] == arr[5] && arr[5] == arr[8])
            {
                return 1;
            }
            //třetí sloupec
            else if (arr[3] == arr[6] && arr[6] == arr[9])
            {
                return 1;
            }
            #endregion
            #region Diagonal Winning Condition
            else if (arr[1] == arr[5] && arr[5] == arr[9])
            {
                return 1;
            }
            else if (arr[3] == arr[5] && arr[5] == arr[7])
            {
                return 1;
            }
            #endregion
            #region Zjišťuje remízu
            else if (arr[1] != '1' && arr[2] != '2' && arr[3] != '3' && arr[4] != '4' && arr[5] != '5' && arr[6] != '6' && arr[7] != '7' && arr[8] != '8' && arr[9] != '9')
            {
                return -1;
            }
            #endregion
            else
            {
                return 0;
            }
        }
    }
}
