namespace Ejercicio3_1
{
    internal class Program
    {
        static Random azar = new Random();

        #region resolución del problema 2.1
        static void QuickSort(int[] numeros, int inicio, int fin)
        {
            int referencia = numeros[inicio];
            int izq = inicio + 1;
            int der = fin;

            while (izq > der ==false )
            {
                //busco de izq a derecha para el cual el valor para el cual no se verifica que no sea menor al pivote
                while (izq <= fin && referencia > numeros[izq]) izq++;

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
            if (inicio < indicePivotenuevo)
                QuickSort(numeros, inicio, indicePivotenuevo - 1);
            #endregion

            #region repetimos para la lista derecha
            if (indicePivotenuevo + 1 < fin)
                QuickSort(numeros, indicePivotenuevo + 1, fin);
            #endregion
        }

        static void Intercambiar(int[] numeros, int indicea, int indiceb)
        {
            int numeroTmp = numeros[indicea];
            numeros[indicea] = numeros[indiceb];
            numeros[indiceb] = numeroTmp;
        }

        #endregion

        static int BusquedaBinaria(int[] numeros, int inicio, int fin, int buscado)
        {
            int idx = -1;
            int medio;

            do
            {
                medio = (inicio + fin) / 2;

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

            } while (idx == -1 && inicio < fin);

            return idx;
        }

        static int BusquedaSecuencial(int[] numeros, int inicio, int fin, int buscado)
        { 
            int idx = -1;

            //OJO! - fin no es cantidad - fin es el ultimo indice=cantidad-1
            int n = inicio;
            while(idx==-1 && n<=fin)
            {
                if (numeros[n] == buscado)
                    idx = n;
                n++;
            }

            return idx;
        }

        static void Main(string[] args)
        {
            //ejercicio 2.1.a.y b

            #region declaraciones
            int[] numeros;
            int cantidad;
            #endregion

            #region inicializaciones
            cantidad = azar.Next(10, 101);
            numeros = new int[cantidad];
            for (int n = 0; n < cantidad; ++n)
            {
                numeros[n] = azar.Next(1, 201);
            }
            #endregion

            #region Imprimiendo listado
            Console.WriteLine($"Listado original\n");
            for (int n = 0; n < cantidad; ++n)
            {
                Console.Write($"{n}:{numeros[n]} ");
            }
            #endregion

            //ejercicio 3.1

            //3.1.a
            #region generando valor para busqueda y busqueda
            int busquedaIdx = azar.Next(0, cantidad);
            int busqueda = numeros[busquedaIdx];
            Console.WriteLine($"\n\n\nValor generado para la busqueda: {busqueda}");
            #endregion

            //3.1.b
            #region busqueda secuencial
            Console.WriteLine($"\n\nBusqueda secuencial\n");
            int idx = BusquedaSecuencial(numeros, 0, cantidad-1, busqueda);            
            if (idx != -1)
            {
                Console.WriteLine($"Posicion encontrada: {idx}");
            }
            else
            {
                Console.WriteLine($"Valor no encontrado");
            }
            #endregion

            //3.1.c
            #region busqueda binaria
            //hay que ordenar primero
            #region ordenando previo a la busqueda
            Console.WriteLine($"\n\nLista ordenada\n");
            QuickSort(numeros, 0, cantidad - 1);
            for (int n = 0; n < cantidad; ++n)
            {
                Console.Write($"{n}:{numeros[n]} ");
            }
            #endregion

            Console.WriteLine($"\n\nBusqueda binaria\n");
            //ojo! paso la posición inicial  y final no la cantidad
            idx = BusquedaBinaria(numeros, 0, cantidad-1, busqueda);
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
