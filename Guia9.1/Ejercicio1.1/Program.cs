using System;

namespace Ejercicio1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region declaraciones
            int[] numeros;
            int contador;

            int valor;
            int acumulado = 0;
            double promedio = 0;
            int maximo = 0;
            int maximoIndice = 0; //posición en la que se encontró el máximo
            int minimo = 0;
            int minimoIndice = 0; //posición en la que se encontró el mínimo

            int[] superioresAlPromedio;
            #endregion

            #region inicializaciones
            numeros = new int[100];
            contador = 0;

            superioresAlPromedio=new int[100];
            #endregion

            #region Solicitar conjunto de datos

            #region solicitar primer número
            Console.WriteLine("Ingrese un valor, con (-1) corta ");
            valor = Convert.ToInt32(Console.ReadLine());
            #endregion

            #region iterar carga de números
            while (valor != -1 && contador < 100)
            {
                #region registrar número en el arreglo
                numeros[contador] += valor;
                contador++;
                #endregion

                #region solicitar siguiente número
                Console.WriteLine("Ingrese un valor, con (-1) corta ");
                valor = Convert.ToInt32(Console.ReadLine());
                #endregion
            }
            #endregion
            #endregion

            #region iterar vector
            acumulado = 0;
            for (int n = 0; n < contador; n++)
            {
                #region actualizar contador
                acumulado += numeros[n];
                #endregion

                #region verificar si número en índice es mayor
                if (n == 0 || numeros[n] > maximo)
                {
                    maximo = numeros[n];
                    maximoIndice = n;
                }
                #endregion

                #region verificar si número en índice es menor
                if (n == 0 || numeros[n] < minimo)
                {
                    minimo = numeros[n];
                    minimoIndice = n;
                }
                #endregion
            }
            #endregion

            #region verificar si se ingresó números / procesar resultados
            if (contador > 0)
            {
                promedio = acumulado / contador;

                Console.WriteLine($"Promedio: {promedio}");
                Console.WriteLine($"Máximo: {maximo}, Índice: {maximoIndice}");
                Console.WriteLine($"Mínimo: {minimo}, Índice: {minimoIndice}");
            }
            else
            {
                Console.WriteLine($"No se han ingresados valores");
            }
            #endregion
        }
    }
}
