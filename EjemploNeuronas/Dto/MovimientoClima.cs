using System;
using System.Collections.Generic;
using System.Text;

namespace EjemploNeuronas.Dto
{
    public class MovimientoClima
    {
        /*
         * "fecha" : "2019-01-20",
  "indicativo" : "7247X",
  "nombre" : "EL PINÓS/PINOSO",
  "provincia" : "ALICANTE",
  "altitud" : "575",
  "tmed" : "6,0",
  "prec" : "0,0",
  "tmin" : "2,7",
  "horatmin" : "23:59",
  "tmax" : "9,2",
  "horatmax" : "10:40",
  "dir" : "04",
  "velmedia" : "1,9",
  "racha" : "7,5",
  "horaracha" : "21:30"*/
        private string _fecha;
        private DateTime? _cfecha;
        public DateTime? CFecha { get { return this._cfecha; } }
        public string fecha { get { return this._fecha; } set { this._fecha = value; try { this._cfecha = DateTime.Parse(value); } catch (Exception e) { this._cfecha = null; } } }
        public string indicativo { get; set; }
        public string nombre { get; set; }
        public string provincia { get; set; }
        public string altitud { get; set; }
        private string _tmed;
        public string tmed { get { return this._tmed; } set { this._tmed = value; try { this._tmedia = Double.Parse(value); } catch { this._tmedia = null; } } }
        public string prec { get; set; }
        private string _tmin;
        public string tmin { get { return this._tmin; } set { this._tmin = value; try { this._tminima = Double.Parse(value); } catch { this._tminima = null; } } }
        public string horatmin { get; set; }
        private string _tmax;
        public string tmax { get { return this._tmax; } set { this._tmax = value; try { this._tmaxima = Double.Parse(value); } catch { this._tmaxima = null; } } }
        public string horatmax { get; set; }
        public string dir { get; set; }
        public string velmedia { get; set; }
        public string horaracha { get; set; }

        private double? _tmedia;
        private double? _tminima;
        private double? _tmaxima;

        public double? tmedia { get { return this._tmedia; } }
        public double? tminima { get { return this._tminima; } }
        public double? tmaxima { get { return this._tmaxima; } }
    }
}
