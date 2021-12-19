using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TP06_A
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] puntos = new double[][]
            {
                new double[]{ 1, 0, 1 },
                new double[]{ 1, 1, 0 }
            };
            
            double FACTOR_DE_APRENDIZAJE = 0.5;
            double SALIDA_ESPERADA = 0;
            
            double[] pesosActuales = new double[] { 1.5, 1, 1 };

            Neurona neurona = new Neurona(pesosActuales);

            double error = neurona.Activar(puntos[0]) - SALIDA_ESPERADA;
            double cantidadDePasos;

            

            foreach (double[] punto in puntos)
            {
                cantidadDePasos = 0;
                while (Math.Round(error,2) > 0)
                {
                    cantidadDePasos++;
                    pesosActuales = new double[] {
                        pesosActuales[0] - FACTOR_DE_APRENDIZAJE * (error/pesosActuales[0]),
                        pesosActuales[1] - FACTOR_DE_APRENDIZAJE * (error/pesosActuales[1]),
                        pesosActuales[2] - FACTOR_DE_APRENDIZAJE * (error/pesosActuales[2])
                    };
                    neurona = new Neurona(pesosActuales);
                    error = neurona.Activar(punto) - SALIDA_ESPERADA;
                }
                Console.WriteLine("Pesos encontrados en " + cantidadDePasos + " pasos:");
                Escribir(pesosActuales);
            }
            Console.ReadLine();
        }

        static void Escribir(double[] array)
        {
            foreach (double numero in array)
            {
                Console.Write(numero + " ");
            }
        }
    }
}
