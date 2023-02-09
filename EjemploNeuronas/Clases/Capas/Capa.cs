using EjemploNeuronas.Clases.FuncActivacion;
using EjemploNeuronas.Clases.Neuronas;
using EjemploNeuronas.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploNeuronas.Clases.Capas
{
    public class Capa
    {
        public List<Neurona> Neuronas { get; set; }
        public int Dimensiones { get; set; }
        public double[] Entrada { get; set; }
        public double[] Salida { get; set; }

        public Capa(int dimensiones, int neuronas) {
            this.Dimensiones = dimensiones;
            this.Neuronas = new List<Neurona>();
            for(int i=0;i<neuronas;i++)
            {
                Neurona a = new Neurona(this.Dimensiones);
                this.Neuronas.Add(a);
            }
        }

        public void CalcularSalida()
        {
            this.Salida = new double[this.Neuronas.Count];
            for(int n=0;n<this.Neuronas.Count;n++)
            {
                this.Neuronas[n].Entradas = this.Entrada;
                this.Neuronas[n].CalcularSalida();
                this.Salida[n] = this.Neuronas[n].Salida;
            }
        }
    
        public void Entrenar(double[] error, double TasaAprendizaje)
        {
            if(error.Length==this.Neuronas.Count)
            {
                for(int i=0;i<error.Length;i++)
                {
                    this.Neuronas[i].Entrenar(error[i], TasaAprendizaje);
                }
            } else
            {
                throw new Exception("Debe declarar un array con cada uno de los errores de la salida de la capa");
            }
        }
    }
}
