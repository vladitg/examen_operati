using System;

namespace ClassLibrary
{
    public class BlackjackHighest
    {
        public BlackjackHighest(string strArr)
        {
            strArr = strArr.Replace("[", "").Replace("]", "");
            string[] arrayCartas = strArr.Split(',');
            string[] cartasDisponibles = { "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king", "ace" };
            int puntosTotal = 0;
            int puntosTop = 0;
            string cartaTop = "";
            bool flagAce = false;
            bool flagError = false;
            foreach (var aux in arrayCartas)
            {
                string carta = aux.Replace("\"", "").ToLower();
                var result = Array.FindLast(cartasDisponibles, element => element.Contains(carta));
                if (result == null)
                {
                    Console.WriteLine("Ingresaste un valor no válido\n");
                    flagError = true;
                    break;
                }
                int index;
                switch (result)
                {
                    case "ace":
                        flagAce = true;
                        break;
                    case "jack":
                    case "queen":
                    case "king":
                        index = Array.IndexOf(cartasDisponibles, result);
                        if(index > puntosTop)
                        {
                            cartaTop = result;
                            puntosTop = index;
                        }
                        puntosTotal += 10;
                        break;
                    default:
                        index = Array.IndexOf(cartasDisponibles, result);
                        if (index > puntosTop)
                        {
                            cartaTop = result;
                            puntosTop = index;
                        }
                        puntosTotal += index+2;
                        break;
                }
            }

            if(flagError == false)
            {
                if (flagAce == true)
                {
                    if (arrayCartas.Length == 2)
                    {
                        puntosTotal += 11;
                        cartaTop = "Ace";
                    }
                    else
                    {
                        puntosTotal += 11;

                        if (puntosTotal > 21)
                            puntosTotal -= 10;
                        else
                            cartaTop = "Ace";
                    }
                }

                if (puntosTotal < 21)
                {
                    Console.WriteLine("Estas por Debajo");
                    Console.WriteLine("Tu carta más alta es: " + cartaTop);
                    Console.WriteLine("Tus puntos son: " + puntosTotal + "\n");
                }
                else if (puntosTotal > 21)
                {
                    Console.WriteLine("Estas por Encima");
                    Console.WriteLine("Tu carta más alta es: " + cartaTop);
                    Console.WriteLine("Tus puntos son: " + puntosTotal + "\n");
                }
                else
                {
                    if (flagAce == false || arrayCartas.Length != 2)
                        Console.WriteLine("Tienes 21 puntos");
                    else
                        Console.WriteLine("Tienes BLACKJACK");
                    Console.WriteLine("Tu carta más alta es: " + cartaTop);
                    Console.WriteLine("Tus puntos son: " + puntosTotal + "\n");
                }
            }
        }
    }
}

        