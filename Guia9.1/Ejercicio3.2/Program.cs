namespace Ejercicio3_2
{
    internal class Program
    {
        static Random azar = new Random();

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


            for (int n = 0; n < cantidad; n++)
            {
                Console.WriteLine($"{numeros[n]}; {nombres[n]}");
            }
        }
    }
}
