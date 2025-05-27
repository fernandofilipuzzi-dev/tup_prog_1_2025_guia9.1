namespace Ejercicio2_2
{
    internal class Program
    {
        static Random azar = new Random();

        static void Burbuja(int[] numeros ,string[] nombres, int cantidad)
        {
            for (int act = 0; act < cantidad - 1; act++)
            {
                for (int sig = act + 1; sig < cantidad - 1; sig++)
                {
                    if (numeros[sig] < numeros[act])
                    {
                        Intercambiar(numeros, nombres,  act, sig);
                    }
                }
            }
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

            Burbuja(numeros, nombres, cantidad);

            #region imprimir listado
            for (int n = 0; n < cantidad; n++)
            {
                Console.WriteLine($"{n,10}; {numeros[n],10}; {nombres[n],10}");
            }
            #endregion
        }
    }
}
