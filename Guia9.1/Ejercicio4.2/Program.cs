
using System;

namespace Ejercicio4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region declaraciones
            string[] nombres;
            int[] libretas;
            double[] notas;
            int contador = 0;

            double acumulado = 0;
            double promedio = 0;

            int libretaNotaMayor = 0;
            string nombreNotaMayor = "";
            double notaMayor = 0;

            int libretaNotaMenor = 0;
            string nombreNotaMenor = "";
            double notaMenor = 0;
            #endregion

            #region inicializaciones
            nombres = new string[100];
            libretas = new int[100];
            notas = new double[100];
            #endregion

            #region Solicitar conjunto de datos

            #region solicitar la primera libreta
            Console.WriteLine("Ingrese el número de libreta, con (-1) corta ");
            int libreta = Convert.ToInt32(Console.ReadLine());
            #endregion

            #region iterar carga de alumnos
            while (libreta != -1 && contador < 100)
            {
                Console.WriteLine("Ingrese el nombre del alumno:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese la nota:");
                double nota = Convert.ToDouble(Console.ReadLine());

                #region registrar valor
                libretas[contador] = libreta;
                nombres[contador] = nombre;
                notas[contador] = nota;
                contador++;
                #endregion

                #region solicitar la siguiente libreta
                Console.WriteLine("Ingrese el número de libreta, con (-1) corta ");
                libreta = Convert.ToInt32(Console.ReadLine());
                #endregion
            }
            #endregion

            #endregion

            #region verificar si hubo alumnos y procesar
            if (contador > 0)
            {
                acumulado = 0;
                for (int n = 0; n < contador; n++)
                {
                    acumulado += notas[n];

                    #region verificar si notas en índice es mayor
                    if (n == 0 || notas[n] > notaMayor)
                    {
                        libretaNotaMayor = libretas[n];
                        nombreNotaMayor = nombres[n];
                        notaMayor = notas[n];
                    }
                    #endregion

                    #region verificar si número en índice es menor
                    if (n == 0 || notas[n] < notaMenor)
                    {
                        libretaNotaMenor = libretas[n];
                        nombreNotaMenor = nombres[n];
                        notaMenor = notas[n];
                    }
                    #endregion
                }
            }
            #endregion

            #region verificar si se ingresó números / procesar resultados
            promedio = 0;
            if (contador > 0)
            {
                promedio = 1.0 * acumulado / contador;

                Console.WriteLine($"Nota Promedio: {promedio:f2}");
                Console.WriteLine($"El alumno: {nombreNotaMayor}({libretaNotaMayor}) es el primero con la mayor nota: {notaMayor}");
                Console.WriteLine($"El alumno: {nombreNotaMenor}({libretaNotaMenor}) es el primero con la menor nota: {notaMenor}");
            }
            else
            {
                Console.WriteLine($"No se han ingresados valores");
            }
            #endregion
        }
    }
}
