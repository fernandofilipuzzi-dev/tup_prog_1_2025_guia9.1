namespace Ejercicio2_2
{
    internal class Program
    {
        static Random azar = new Random();

        static void Burbuja(int[] numeros ,string[] nombres, int cantidad)
        {
            for (int act = 0; act < cantidad - 1; act++)
            {
                for (int sig = act + 1; sig < cantidad ; sig++)
                {
                    if (numeros[sig] < numeros[act])
                    {
                        Intercambiar(numeros, nombres,  act, sig);
                    }
                }
            }
        }

        static void QuickSort(int[] numeros, string[] nombres, int inicio, int fin)
        {
            int pivote = numeros[0];
            int izq = inicio;
            int der = fin;
            int n;

            #region encontrar donde insertar el pivote
            while (izq < der)
            {
                #region voy dejando los terminos menores a la izquierda del pivate y los mayores a la derecha del pivote
                while (izq <= fin && numeros[izq] < pivote) izq++;
                while(der>inicio && numeros[der] > pivote) der--;
                if (izq < der)
                    Intercambiar(numeros, nombres, izq, der);
                #endregion
            }
            #endregion

            //aca se que el indice de la izquierda quedo a la derecha, y el de la derecha a la izq.
            //por lo tanto el indice derecho esta apuntando a un valor menor - por lo tanto ahí hago el intercambio
            #region inserto pivote - intercambiando el pivote por el valor menor 
            int indicePivoteNuevo = der;
            Intercambiar(numeros, nombres, inicio, indicePivoteNuevo);
            #endregion

            //nos quedan dos listas, una a la izquierda del pivote y otra la derecha del pivote
            //el pivote quedo en el indice=der
            #region repetimos para la lista izq al pivote
            if(inicio<indicePivoteNuevo)
                QuickSort(numeros, nombres, inicio, indicePivoteNuevo - 1);
            #endregion
            #region repetimos para la lista derecha
            if(indicePivoteNuevo<fin)
                QuickSort(numeros, nombres, indicePivoteNuevo+1, fin);
            #endregion

        }

        static void Intercambiar(int[] numeros, string[] nombres, int indicea, int indiceb)
        {
            int numeroTmp = numeros[indicea];
            numeros[indicea] = numeros[indiceb];
            numeros[indiceb]=numeroTmp;

            string nombreTmp = nombres[indicea];
            nombres[indicea] = nombres[indiceb];
            nombres[indiceb] = nombreTmp;
        }

        static void Main(string[] args)
        {
            #region declaraciones
            int[] numeros;
            string[] nombres;
            int cantidad;
            string[] nombresEjemplo = new string[] { "Noemí", "Noelía", "Andrés", "Emilio", "Norberto", "Estefanía", "Daniela", "Valeria" };

            #endregion

            #region inicializaciones
            cantidad = azar.Next(10, 101);
            numeros = new int[cantidad];
            nombres = new string[cantidad];
            for (int n = 0; n < cantidad; ++n)
            {
                numeros[n] = azar.Next(1, 201);

                int idx = azar.Next(0, nombresEjemplo.Length);
                nombres[n] = nombresEjemplo[idx];
            }
            #endregion

            #region imprimir listado
            for (int n = 0; n < cantidad; n++)
            {
                Console.WriteLine($"{n,10}; {numeros[n],10}; {nombres[n],10}");
            }
            #endregion

            #region copiando el vector
            int[] numeroscpy= new int[cantidad];
            string[] nombrescpy = new string[cantidad];
            for (int n = 0; n < cantidad; n++)
            { 
                numeroscpy[n] = numeros[n];
                nombrescpy[n] = nombres[n];
            }
            #endregion

            Burbuja(numeroscpy, nombrescpy, cantidad);

            #region imprimir listado
            Console.WriteLine("\n\n\nOrdenamiento Burbuja\n");
            for (int n = 0; n < cantidad; n++)
            {
                Console.WriteLine($"{n,10}; {numeroscpy[n],10}; {nombrescpy[n],10}");
            }
            #endregion

            #region copiando el vector
            numeroscpy = new int[cantidad];
            nombrescpy = new string[cantidad];
            for (int n = 0; n < cantidad; n++)
            {
                numeroscpy[n] = numeros[n];
                nombrescpy[n] = nombres[n];
            }
            #endregion

            QuickSort(numeroscpy, nombrescpy, 0, cantidad-1);

            #region imprimir listado
            Console.WriteLine("\n\n\nOrdenamiento quicksort\n");
            for (int n = 0; n < cantidad; n++)
            {
                Console.WriteLine($"{n,10}; {numeroscpy[n],10}; {nombrescpy[n],10}");
            }
            #endregion

        }
    }
}
