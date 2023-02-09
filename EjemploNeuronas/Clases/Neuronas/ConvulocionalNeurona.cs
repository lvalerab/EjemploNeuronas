using EjemploNeuronas.Clases.FuncActivacion;
using EjemploNeuronas.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploNeuronas.Clases.Neuronas
{
    public class ConvulocionalNeurona:INeurona<double[,]>
    {
        private double[,] _entrada;
        private double[,] _kernel;
        private double _salida;
        private double? _sesgo;

        public double[,] Entradas
        {
            get
            {
                return this._entrada;
            }
            set
            {
                this._entrada = value;
            }
        }

        public double[,] Kernel
        {
            get
            {
                return this._kernel;
            }
            set
            {
                this._kernel = value;
            }
        }
    
        public double? Sesgo { get { return this._sesgo; } set { this._sesgo = value; } }

        public double Salida { get { return this._salida; } set { this._salida = value; } }

        public FuncionActivacion FuncionActivacion { get; set; }
    

        public ConvulocionalNeurona(int tamanyo)
        {
            this.Kernel = new double[tamanyo, tamanyo];
            Random rnd = new Random();
            for(var i=0;i<this.Kernel.GetLength(0);i++)
            {
                for(int j=0;j<this.Kernel.GetLength(1);j++)
                {
                    this.Kernel[i, j] = rnd.NextDouble();
                }
            }
        }

        public void CalcularSalida()
        {
            double sum = this.Sesgo??0;
            for(int i = 0; i < this.Entradas.GetLength(0); i++)
            {
                for(int j = 0; j < this.Entradas.GetLength(1); j++)
                {
                    sum += this.Entradas[i, j] * this.Kernel[i, j];
                }
            }

            if(this.FuncionActivacion!=null)
            {
                this.Salida = this.FuncionActivacion(sum);
            } else
            {
                this.Salida = FuncionesActivacion.Sigmoide(sum);
            }
        }

        public void Entrenar(double error, double TasaAprendizaje)
        {
            for (int i = 0; i < this.Kernel.GetLength(0); i++)
            {
                for(int j=0;j<this.Kernel.GetLength(1);j++)
                {
                    this.Kernel[i,j] += error * TasaAprendizaje * this.Kernel[i,j];
                }
            }
        }
    }
}
