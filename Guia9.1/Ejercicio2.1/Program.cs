using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicio2_1
{
    internal class Program
    {
        static Random azar=new Random();

        static void OrdenarQuicSort(int[] numeros,int inicio, int fin)
        {
            int referencia = numeros[inicio];
            int izq = inicio+1;
            int der = fin;
            while (izq < der)
            {
                //busco de izq a derecha para el cual el valor para el cual no se verifica que no sea menor al pivote
                while (izq<=fin && referencia > numeros[izq]) izq++ ;

                //busco de derecha a izq para el cual el valor para el cual no se verifica que no sea mayor al pivote
                while (der > inicio && referencia <= numeros[der]) der--;

                //si se verifica que lo encontro lo intercambio
                if (izq < der)
                    Intercambiar(numeros, izq, der);
            }
            Intercambiar(numeros, inicio, der);//der<izq

            //ojo! der termina quedando a la izquierda - y es consecuencia de haber terminado el bucle 

            if(inicio< der-1)
                OrdenarQuicSort(numeros, inicio, der-1);
            if(der +1 < fin)
                OrdenarQuicSort(numeros, der + 1, fin);
        }

        static void Intercambiar(int[] numeros, int idxL, int idxR)
        {
            int temp = numeros[idxL];
            numeros[idxL] = numeros[idxR];
            numeros[idxR]=temp;
        }

        static int BusquedaBinaria(int [] numeros, int inicio, int fin, int buscado)
        {
            int idx=-1;
            int medio;

            do
            {
                medio = ( inicio+ fin) / 2;

                if (numeros[medio] == buscado)
                {
                    idx = medio;
                }
                else if (buscado < numeros[medio])
                {
                    fin = medio - 1;
                }
                else if (buscado > numeros[medio])
                { 
                    inicio = medio + 1;
                }

            } while (idx == -1 && inicio<fin);
                        
            return idx;            
        }

        static void Main(string[] args)
        {
            #region declaraciones
            int[] numeros;
            int cantidad;
            #endregion

            #region inicializaciones
            cantidad=azar.Next(10,101);
            numeros = new int[cantidad];
            for (int n = 0; n < cantidad; ++n)
            {
                numeros[n] = azar.Next(1, 201);
            }
            #endregion

            #region Imprimiendo listado
            for (int n = 0; n < cantidad; ++n)
            {
                Console.Write(numeros[n] + " ");
            }
            #endregion

            #region ordenamiento - método burbuja
            for (int n = 0; n < cantidad - 1; n++) //recorre el vector hasta una posición anterior al último
            {
                for (int n_sig = n + 1; n_sig < cantidad; n_sig++) //recorre los siguientes - si verifica invierte
                {
                    if (numeros[n_sig] > numeros[n])
                    {
                        #region intercambia los registros
                        int tmp = numeros[n_sig];
                        numeros[n_sig] = numeros[n];
                        numeros[n] = tmp;
                        #endregion
                    }
                }
            }
            Console.WriteLine("\n");

            for (int n = 0; n < cantidad; ++n)
            {
                Console.Write(numeros[n] + " ");
            }
            Console.WriteLine("\n");
            #endregion

            #region Ordenamiento quicksort
            Console.WriteLine("Ordenamiento quicksort");
            OrdenarQuicSort(numeros, 0, cantidad - 1);
            for (int n = 0; n < cantidad; ++n)
            {
                Console.Write($"{n}:{numeros[n]} ");
            }
            Console.WriteLine("\n");
            #endregion

            #region generando valor para busqueda y busqueda
            int busqueda = azar.Next(1, 201);

            Console.WriteLine($"\nValor buscado: {busqueda}");

            int idx = BusquedaBinaria(numeros, 0, cantidad, busqueda);
            if (idx != -1)
            {
                Console.WriteLine($"Posicion encontrada: {idx}");
            }
            else
            {
                Console.WriteLine($"Valor no encontrado");
            }
            #endregion
        }
    }
}
