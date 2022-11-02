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
            List<string> arrFinal = new List<string>();
            foreach (var aux in caminos)
            {
                string[] puntos = aux.Split('-');
                int comparison = String.Compare(puntos[0], puntos[1], comparisonType: StringComparison.OrdinalIgnoreCase);
                string valorNew = "";
                if (comparison < 0)
                {
                    arrFinal.Add(puntos[0] + "-" + puntos[1]);
                }
                else
                {
                    arrFinal.Add(puntos[1] + "-" + puntos[0]);
                }
            }

            List<string> caminosLargos = new List<string>();
            int caminosMax = 0;
            string camino;
            foreach (var aux in arrFinal)
            {
                string[] puntos = aux.Split('-');
                int comparison = String.Compare(puntos[0], puntos[1], comparisonType: StringComparison.OrdinalIgnoreCase);
                string inicio = "", final = "", puente = "";
                if (comparison < 0)
                {
                    inicio = puntos[0];
                    final = puntos[1];
                    puente = puntos[0];
                } else
                {
                    inicio = puntos[1];
                    final = puntos[0];
                    puente = puntos[1];
                }

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
                    foreach (var res in arrFinal)
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
                            caminosLargos.Add(camino);
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

            caminosLargos.Sort((x, y) => x.Length.CompareTo(y.Length));
            int index = caminosLargos.Count;
            List<string> caminoMasLargo = new List<string>(caminosLargos[index - 1].Split('-'));
            List<string> primerCamino = new List<string>(caminosLargos[index - 1].Split('-'));
            List<string> segundoCamino = new List<string>(caminosLargos[index - 2].Split('-'));
            foreach (var aux in caminoMasLargo)
            {
                if (segundoCamino.Remove(aux))
                    primerCamino.Remove(aux);
            }
            int caminoUnido = primerCamino.Count + segundoCamino.Count + 1;
            int response = 0;
            if (caminoMasLargo.Count >= caminoUnido)
                response = caminoMasLargo.Count - 1;
            else
                response = caminoUnido - 1;

            Console.WriteLine("\nEl largo del camino es de: " + response + "\n");
        }
    }
}

