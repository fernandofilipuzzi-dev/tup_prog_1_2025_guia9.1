using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ejercicio2_1
{
    internal class Program
    {
        static Random azar=new Random();

        static void QuickSort(int[] numeros,int inicio, int fin)
        {
            int referencia = numeros[inicio];
            int izq = inicio+1;
            int der = fin;

            while (izq <= der)
            {
                //busco de izq a derecha para el cual el valor para el cual no se verifica que no sea menor al pivote
                while (izq<=fin && referencia > numeros[izq]) izq++ ;

                //busco de derecha a izq para el cual el valor para el cual no se verifica que no sea mayor al pivote
                while (der > inicio && referencia <= numeros[der]) der--;

                //si se verifica que lo encontro lo intercambio
                if (izq < der)
                    Intercambiar(numeros, izq, der);
            }

            //aca se que el indice de la izquierda quedo a la derecha, y el de la derecha a la izq.
            //por lo tanto el indice derecho esta apuntando a un valor menor - por lo tanto ahí hago el intercambio
            #region inserto pivote - intercambiando el pivote por el valor menor 
            int indicePivotenuevo = der;
            Intercambiar(numeros, inicio, indicePivotenuevo);//der<izq
            #endregion
            //ojo! der termina quedando a la izquierda - y es consecuencia de haber terminado el bucle 

            //nos quedan dos listas, una a la izquierda del pivote y otra la derecha del pivote
            //el pivote quedo en el indice=der
            #region repetimos para la lista izq al pivote
            if (inicio< indicePivotenuevo)
                QuickSort(numeros, inicio, indicePivotenuevo-1);
            #endregion
            
            #region repetimos para la lista derecha
            if (indicePivotenuevo+1 < fin)
                QuickSort(numeros, indicePivotenuevo + 1, fin);
            #endregion
        }

        static void Intercambiar(int[] numeros, int idxL, int idxR)
        {
            int temp = numeros[idxL];
            numeros[idxL] = numeros[idxR];
            numeros[idxR]=temp;
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
            QuickSort(numeros, 0, cantidad - 1);
            for (int n = 0; n < cantidad; ++n)
            {
                Console.Write($"{n}:{numeros[n]} ");
            }
            Console.WriteLine("\n");
            #endregion

        }
    }
}
