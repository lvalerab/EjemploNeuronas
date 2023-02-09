using EjemploNeuronas.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploNeuronas.Clases
{
    public class Entrenador<T>
    {
        public INeurona<T> Neurona { get; set; }
        public double TasaAprendizaje { get; set; }

        public Entrenador(INeurona<T> neurona,double Tasa)
        {
            this.Neurona = neurona;
            this.TasaAprendizaje = Tasa;
        }

        public void Entrenar(T entradas, double SalidaDeseada)
        {
            this.Neurona.Entradas = entradas;
            this.Neurona.CalcularSalida();

            //Calculamos el error
            double error = SalidaDeseada - this.Neurona.Salida;
            if(!Double.IsNaN(error) && !Double.IsNaN(this.Neurona.Salida)) { 
                this.Neurona.Entrenar(error, TasaAprendizaje);
            } else
            {
                Console.WriteLine("Error en el calculo, Salida deseada {0}, Salida de la neurona {1}", SalidaDeseada, this.Neurona.Salida);
            }

        }
    }
}
