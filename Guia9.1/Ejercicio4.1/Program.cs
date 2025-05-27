namespace Ejercicio4_1
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
            double promedio=0;
            int maximo = 0;
            int minimo = 0;

            int[] superioresAlPromedio;
            int contadorSuperior;
            #endregion

            #region inicializaciones
            numeros = new int[100];
            contador = 0;

            superioresAlPromedio = new int[100];
            contadorSuperior = 0;
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

            #region calcula el promedio
            acumulado = 0;
            for (int n = 0; n < contador; n++)
            {
                acumulado += numeros[n];
            }
            if (contador > 0)
            {
                promedio = 1.0 * acumulado / contador;
            }
            #endregion

            #region verificar si se ingresó números / procesar resultados
            if (contador > 0)
            {
            
                for (int n = 0; n < contador; n++)
                {
                    if (numeros[n] > promedio)
                    {
                        superioresAlPromedio[contadorSuperior] = numeros[n];
                        contadorSuperior++;
                    }
                }

                Console.WriteLine($"Promedio: {promedio:f2}");

                Console.WriteLine("Listado de numeros superiores al promedio: ");
                for (int n = 0; n < contadorSuperior; n++)
                {
                    Console.Write(superioresAlPromedio[n] + " ");
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
