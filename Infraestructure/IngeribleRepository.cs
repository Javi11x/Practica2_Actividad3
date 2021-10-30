using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using NivelAcohol.Domain;


namespace NivelAcohol.Infraestructure
{
    public class IngeribleRepository
    {
        List<Ingerible> _Ingerible;
        public IngeribleRepository()
        {
            var fileName = "Ingerible.json";
            if(File.Exists(fileName))
            {
                var json = File.ReadAllText(fileName);
                _Ingerible = JsonSerializer.Deserialize<IEnumerable<Ingerible>>(json).ToList();
            }
        }

        public IEnumerable<Ingerible> GetAll()
        {
            var query = _Ingerible.Select(Ingerible => Ingerible);
            return query;
        }

        /*public IEnumerable<Ingerible> Multiplicar(string Nombre, int Cantidad)
        {
            var query = _Ingerible.Where(Ingerible => Ingerible.Nombre == Nombre);
            var query2 = _Ingerible.Where(Ingerible => Ingerible.Nombre == Nombre)
                                   .Select(Ingerible => Ingerible.Mililitro * Cantidad);

            return query2;
        }*/

    }
}