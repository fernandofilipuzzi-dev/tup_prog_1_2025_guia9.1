
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

            string[] nombresSuperior;
            int[] libretasSuperior;
            double[] notasSuperior;
            int contadorSuperior=0;
            #endregion

            #region inicializaciones
            nombres = new string[100];
            libretas = new int[100];
            notas = new double[100];

            nombresSuperior = new string[100];
            libretasSuperior = new int[100];
            notasSuperior = new double[100];

            //precargando ejemplos de prueba
            nombres[contador] = "Julio";
            libretas[contador] = 52;
            notas[contador] = 99;
            contador++;
            nombres[contador] = "Maria";
            libretas[contador] = 2;
            notas[contador] = 9;
            contador++;
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

                }
            }
            #endregion

            #region verificar si se ingresó números / procesar resultados
            if (contador > 0)
            {
                promedio = acumulado / contador;
                Console.WriteLine($"Promedio: {promedio:f2}");

                contadorSuperior = 0;
                for (int n = 0; n < contador; n++)
                {
                    if (notas[n] > promedio)
                    {
                        nombresSuperior[contadorSuperior] = nombres[n];
                        libretasSuperior[contadorSuperior] = libretas[n];
                        notasSuperior[contadorSuperior] = notas[n];

                        contadorSuperior++;
                    }
                }

                Console.WriteLine("Listado de numeros superiores al promedio: ");
                for (int n = 0; n < contadorSuperior; n++)
                {
                    Console.WriteLine($"{libretasSuperior[n],10}{nombresSuperior[n],10};{notasSuperior[n],10}");
                }
            }
            else
            {
                Console.WriteLine($"No se han ingresados valores");
            }
            #endregion
        }
    }
}
