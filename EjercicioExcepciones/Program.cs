using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioExcepciones
{
    /*
    Vamos a crear una aplicación de consola que generé un numero aleatorio. La aplicación solicitará al usuario un número, en el caso de que el número introducido sea:

    -    Mayor mostrará un mensaje: El número es más pequeño.
    -    Menor mostrará un mensaje: El número es más grande.
    -    El usuario dispondrá de 10 intentos para adivinar el número.

    1 – Controla las excepciones posibles que se pueden producir en la aplicación.

    2 – Crea una excepción personalizada para lanzarla cuando el número es mayor o menor.
     */

    // Exception personalizadas
    public class NumeroException : Exception
    {
        public NumeroException(String mensaje) : base(mensaje)
        {
            Console.WriteLine(mensaje);
        }
    }



    class Program
    {

        // Variables
        static Random rand = new Random();
        static int rnd = rand.Next(0, 51);
        static int cont = 0;
        static int nUsuario = 0;
        public static void CheckNum(int num) // Metodo que comprueba el numero
        {
            if (num == rnd)
            {
                Console.WriteLine("Has acertado y has ganado!");
            }
            else if (num > rnd)
            {
                throw new NumeroException("El numero es mas pequeño");
            }
            else
            {
                throw new NumeroException("El numero es mas grande");
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Adivina el numero aleatorio entre 0 y 50. Tienes 10 intentos\n");
            do
            {
                try
                {
                    Console.Write("Introduce un numero: ");
                    nUsuario = Convert.ToInt32(Console.ReadLine());
                    CheckNum(nUsuario);
                }
                catch (NumeroException)
                {
                    cont++;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Tipo de dato incorrecto.");
                }
            } while (nUsuario != rnd && cont != 10); // Mientras el numero no sea el numero aleatorio y el contador no sea 10
            if (cont == 10)
            {
                Console.WriteLine("Has llegado a 10 intentos. Has perdido!");
            }
            Console.ReadLine();
        }



    }
}

