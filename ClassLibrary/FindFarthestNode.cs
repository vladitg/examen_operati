using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class FindFarthestNode
    {
        public FindFarthestNode(string strArr)
        {
            char[] separators = new char[] { '[', ']', '"', ',', ' ' };
            string[] caminos = strArr.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            List<string> caminosLargos = new List<string>();
            int caminosMax = 0;
            string camino;
            foreach (var aux in caminos)
            {
                string[] puntos = aux.Split('-');
                string inicio = puntos[0];
                string final = puntos[1];
                string puente = puntos[0];
                camino = inicio + "-" + final;
                int caminosCount = 1;

                List<string> nodosRecorridos = new List<string>();
                nodosRecorridos.Add(inicio);
                nodosRecorridos.Add(final);
                List<string> nodosCerrados = new List<string>();
                int iNodo = 2;

                bool flagRestart = true;
                while (flagRestart == true)
                {
                    foreach (var res in caminos)
                    {
                        string[] puntosChild = res.Split('-');
                        string inicioChild = puntosChild[0];
                        string finalChild = puntosChild[1];
                        if (inicioChild == final)
                        {
                            if (!nodosCerrados.Contains(finalChild))
                            {
                                flagRestart = true;
                                puente = final;
                                caminosCount++;
                                camino += "-" + finalChild;
                                final = finalChild;
                                nodosRecorridos.Add(final);
                                iNodo++;
                                break;
                            }
                        }
                        else
                        {
                            flagRestart = false;
                        }
                    }
                    if (flagRestart == false)
                    {
                        if ((iNodo - 2) != -1)
                        {
                            nodosCerrados.Add(nodosRecorridos[iNodo - 1]);
                            nodosRecorridos.RemoveAt(iNodo - 1);
                            iNodo--;
                            final = puente;
                            if (iNodo - 2 != -1)
                                puente = nodosRecorridos[iNodo - 2];
                            if (caminosCount > caminosMax)
                            {
                                caminosMax = caminosCount;
                                caminosLargos = new List<string>();
                                caminosLargos.Add(camino);
                            }
                            else if (caminosCount == caminosMax)
                            {
                                caminosLargos.Add(camino);
                            }
                            caminosCount--;
                            camino = "";
                            for (var i = 0; i < iNodo; i++)
                            {
                                if (i == 0)
                                    camino += nodosRecorridos[i];
                                else
                                    camino += "-" + nodosRecorridos[i];
                            }
                            flagRestart = true;
                        }
                    }
                }
            }

            foreach (var aux in caminos)
            {
                string[] puntos = aux.Split('-');
                string inicio = puntos[1];
                string final = puntos[0];
                string puente = puntos[1];
                camino = inicio + "-" + final;
                int caminosCount = 1;

                List<string> nodosRecorridos = new List<string>();
                nodosRecorridos.Add(inicio);
                nodosRecorridos.Add(final);
                List<string> nodosCerrados = new List<string>();
                int iNodo = 2;

                bool flagRestart = true;
                while (flagRestart == true)
                {
                    foreach (var res in caminos)
                    {
                        string[] puntosChild = res.Split('-');
                        string inicioChild = puntosChild[1];
                        string finalChild = puntosChild[0];
                        if (inicioChild == final)
                        {
                            if (!nodosCerrados.Contains(finalChild))
                            {
                                flagRestart = true;
                                puente = final;
                                caminosCount++;
                                camino += "-" + finalChild;
                                final = finalChild;
                                nodosRecorridos.Add(final);
                                iNodo++;
                                break;
                            }
                        }
                        else
                        {
                            flagRestart = false;
                        }
                    }
                    if (flagRestart == false)
                    {
                        if ((iNodo - 2) != -1)
                        {
                            nodosCerrados.Add(nodosRecorridos[iNodo - 1]);
                            nodosRecorridos.RemoveAt(iNodo - 1);
                            iNodo--;
                            final = puente;
                            if (iNodo - 2 != -1)
                                puente = nodosRecorridos[iNodo - 2];
                            if (caminosCount > caminosMax)
                            {
                                caminosMax = caminosCount;
                                caminosLargos = new List<string>();
                                caminosLargos.Add(camino);
                            }
                            else if (caminosCount == caminosMax)
                            {
                                caminosLargos.Add(camino);
                            }
                            caminosCount--;
                            camino = "";
                            for (var i = 0; i < iNodo; i++)
                            {
                                if (i == 0)
                                    camino += nodosRecorridos[i];
                                else
                                    camino += "-" + nodosRecorridos[i];
                            }
                            flagRestart = true;
                        }
                    }
                }
            }

            Console.WriteLine("\nSe han encontrado los siguientes caminos");
            foreach (var aux in caminosLargos)
            {
                Console.WriteLine(aux);
            }
            Console.WriteLine("\n");
        }
    }
}

