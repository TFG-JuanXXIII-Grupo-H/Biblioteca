using System;

namespace TrabajoSGE1
{
    public class Socio
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string CuentBanc { get; set; }
        public string Dir { get; set; }
        public int Cuota { get; set; }
        public DateTime FechAlt { get; set; }
        public DateTime FechCad { get; set; }

        public Socio() { }

        public Socio(int id, string dni, string nombre, string cuentbanc, string dir, int cuota, DateTime fechalt, DateTime fechcad)
        {
            Id = id;
            Dni = dni;
            Nombre = nombre;
            CuentBanc = cuentbanc;
            Dir = dir; 
            Cuota = cuota;
            FechAlt = fechalt;
            FechCad = fechcad;
        }
    }
}