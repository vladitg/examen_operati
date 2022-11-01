using System;
using ClassLibrary;
using Microsoft.VisualBasic;

namespace operati_Vladimir
{
    public class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            bool flag = true;
            string strArr = "";

            do
            {
                Console.WriteLine("MENÚ");
                Console.WriteLine("1.- Tree Constructor");
                Console.WriteLine("2.- Blackjack Highest");
                Console.WriteLine("3.- Simple Password");
                Console.WriteLine("4.- Find farthest node");
                Console.WriteLine("5.- Salir");

                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("\nIngrese el valor");
                        strArr = Console.ReadLine();
                        TreeConstructor treeConstructor = new TreeConstructor(strArr);
                        break;
                    case 2:
                        Console.WriteLine("\nIngrese el valor");
                        strArr = Console.ReadLine();
                        BlackjackHighest blackjackHighest = new BlackjackHighest(strArr);
                        break;
                    case 3:
                        Console.WriteLine("\nIngrese el valor");
                        strArr = Console.ReadLine();
                        SimplePassword simplePassword = new SimplePassword(strArr);
                        break;
                    case 4:
                        Console.WriteLine("\nIngrese el valor");
                        strArr = Console.ReadLine();
                        FindFarthestNode findFarthestNode = new FindFarthestNode(strArr);
                        break;
                    default:
                        flag = false;
                        break;
                }
            } while (flag == true);
        }
    }
}