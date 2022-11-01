using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class FindFarthestNode
    {
        public FindFarthestNode(string strArr)
        {
            char[] separators = new char[] { '[', ']', '"', ',' };
            string[] caminos = strArr.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            List<string> caminosLargos = new List<string>();
            int caminosMax = 0;
            string camino;
            foreach(var aux in caminos)
            {
                string[] puntos = aux.Split('-');
                string inicio = puntos[0];
                string final = puntos[1];
                string puente = puntos[1];
                camino = inicio + "-" + final;
                int caminosCount = 1;
                bool flag = true;
                List<string> caminosLargosChild = new List<string>();
                while (flag == true)
                {
                    string caminoChild = camino;
                    int caminosCountChild = 1;
                    foreach (var res in caminos)
                    {
                        string[] puntosChild = res.Split('-');
                        string inicioChild = puntosChild[0];
                        string finalChild = puntosChild[1];
                        if (inicioChild == final)
                        {
                            caminosCountChild++;
                            caminoChild += "-" + finalChild;
                            final = finalChild;
                        }
                    }
                    if(puente != final)
                    {
                        puente = final;
                    }
                    else
                    {
                        flag = false;
                    }
                    if (caminosCountChild > caminosCount)
                    {
                        caminosCount = caminosCountChild;
                        caminosLargosChild = new List<string>();
                        caminosLargosChild.Add(caminoChild);
                    }
                    else if (caminosCountChild == caminosCount)
                    {
                        caminosLargosChild.Add(caminoChild);
                    }
                }
                if(caminosCount > caminosMax)
                {
                    caminosMax = caminosCount;
                    caminosLargos = new List<string>();
                    foreach(var child in caminosLargosChild)
                    {
                        caminosLargos.Add(child);
                    }
                    
                }
                else if (caminosCount == caminosMax)
                {
                    foreach (var child in caminosLargosChild)
                    {
                        caminosLargos.Add(child);
                    }
                }
            }

            foreach (var aux in caminos)
            {
                string[] puntos = aux.Split('-');
                string inicio = puntos[1];
                string final = puntos[0];
                string puente = puntos[0];
                camino = inicio + "-" + final;
                int caminosCount = 1;
                bool flag = true;
                List<string> caminosLargosChild = new List<string>();
                while (flag == true)
                {
                    string caminoChild = camino;
                    int caminosCountChild = 1;
                    foreach (var res in caminos)
                    {
                        string[] puntosChild = res.Split('-');
                        string inicioChild = puntosChild[1];
                        string finalChild = puntosChild[0];
                        if (inicioChild == final)
                        {
                            caminosCountChild++;
                            caminoChild += "-" + finalChild;
                            if (puente == final)
                            {
                                caminosCountChild++;
                                caminoChild += "-" + finalChild;
                                final = finalChild;
                            }
                            final = finalChild;
                        }
                    }
                    if (caminosCountChild > caminosCount)
                    {
                        caminosCount = caminosCountChild;
                        caminosLargosChild = new List<string>();
                        caminosLargosChild.Add(caminoChild);
                    }
                    else if (caminosCountChild == caminosCount)
                    {
                        caminosLargosChild.Add(caminoChild);
                    }
                }
                if (caminosCount > caminosMax)
                {
                    caminosMax = caminosCount;
                    caminosLargos = new List<string>();
                    foreach (var child in caminosLargosChild)
                    {
                        caminosLargos.Add(child);
                    }

                }
                else if (caminosCount == caminosMax)
                {
                    foreach (var child in caminosLargosChild)
                    {
                        caminosLargos.Add(child);
                    }
                }
            }

            Console.WriteLine("Se han encontrado los siguientes caminos");
            foreach(var aux in caminosLargos)
            {
                Console.WriteLine(aux);   
            }
        }
    }
}

