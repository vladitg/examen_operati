using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class Node
    {
        public int Padre { get; set; }
        public int Izquierdo { get; set; }
        public int Derecho { get; set; }
        public Node(int parent, int izq, int der)
        {
            Padre = parent;
            Izquierdo = izq;
            Derecho = der;
        }
    }

    public class TreeConstructor
    {
        List<Node> nodos = new List<Node>();
        public TreeConstructor(string strArr)
        {
            char[] separators = new char[] { ' ', ';', ',', '\r', '\t', '\n', '"', '”', ']', '[', '“', '(', ')' };
            string[] temps = strArr.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int i = 1;
            int child = 0;
            bool output = true;
            foreach (var temp in temps)
            {
                if(i == 1)
                {
                    child = Convert.ToInt32(temp);
                    i++;
                }
                else
                {
                    output = CrearNodo(child, Convert.ToInt32(temp));
                    i=1;
                }
                if (!output)
                {
                    break;
                }
            }
            Console.WriteLine(output+"\n");
        }

        public bool CrearNodo(int child, int parent)
        {
            bool aux = true;
            if(child == parent)
            {
                return false;
            }
            foreach(var nodo in nodos)
            {
                if(child != nodo.Derecho && child != nodo.Derecho)
                {
                    if (nodo.Padre == parent)
                    {
                        if (nodo.Derecho != 0)
                        {
                            return false;
                        }
                        nodo.Derecho = child;
                        aux = false;
                        break;
                    }
                }
                else
                {
                    return false;
                }
            }
            if(aux == true)
            {
                nodos.Add(new Node(parent, child, 0));
            }
            return true;
        }
    }
}