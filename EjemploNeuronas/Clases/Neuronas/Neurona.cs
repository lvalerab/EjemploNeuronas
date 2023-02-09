using EjemploNeuronas.Clases.FuncActivacion;
using EjemploNeuronas.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploNeuronas.Clases.Neuronas
{
    public delegate void EventOnCambiaValores(double[] anterior, double[] nueva);

    public class Neurona:INeurona<double[]>
    {
        private double[] _entradas;
        private double[] _kernel;
        private double _salida;
        public double[] Entradas
        {
            get
            {
                return this._entradas;
            }
            set
            {
                double[] ant = this._entradas;
                this._entradas = value;
                if(this.OnCambiaEntrada!=null)
                {
                    this.OnCambiaEntrada(ant, this.Entradas);
                }
            }
        }
        public double[] Kernel {
            get
            {
                return this._kernel;
            }
            set
            {
                double[] ant = this._kernel;
                this._kernel = value;
                if(this.OnCambiaPesos!=null)
                {
                    this.OnCambiaPesos(ant, this._kernel);
                }
            }
        }
        public double Salida { get { return this._salida; } set { this._salida = value; } }
        public double? Sesgo { get; set; }
        public FuncionActivacion FuncionActivacion { get; set; }

        public EventOnCambiaValores OnCambiaEntrada
        {
            get;
            set;
        }

        public EventOnCambiaValores OnCambiaPesos
        {
            get;
            set;
        }
        

        public Neurona(int entradas) {
            this.Entradas = new double[entradas];
            this.Kernel = new double[entradas];

            //Inicializamos los pesos
            Random rdn = new Random();
            for(int i=0;i<this.Kernel.Length;i++)
            {
                this.Kernel[i] = rdn.NextDouble();
            }
        }

        public void CalcularSalida()
        {
            double sum = this.Sesgo??0;
            for(var i=0;i<Entradas.Length;i++)
            {
                sum += this.Entradas[i] * this.Kernel[i];
            }
            if(this.FuncionActivacion!=null)
            {
                this.Salida = this.FuncionActivacion(sum);
            } else { 
                this.Salida = FuncionesActivacion.Sigmoide(sum);
            }
        }

        public void Entrenar(double error, double TasaAprendizaje)
        {
            Console.WriteLine("Error: {0}, Tasa: {1}", error, TasaAprendizaje);
            for(int i=0;i<this.Kernel.Length;i++)
            {
                this.Kernel[i] += error * TasaAprendizaje * this.Kernel[i];
            }
        }
    }
}
