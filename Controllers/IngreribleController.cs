using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NivelAcohol.Infraestructure;
using NivelAcohol.Domain;

namespace NivelAcohol.Controllers
{
    /*Escuela: Universidad Tecnologica Metropolitana
    Materia: Aplicaciones Web Orientadas a Servicios
    Maestro: Chuc Uc Joel Ivan
    Actividad: Actividad 3: Alcoholemia
    Alumno: Javier Alexander Sulub Flores
    Cuatrimestre: 4
    Grupo: B
    Parcial: 2*/
    [ApiController]
    [Route("api/[controller]")]
    public class IngreribleController : ControllerBase
    {
        [HttpGet]
        [Route("TraerTodos")]
        public IActionResult Operacion(string Ingerible, int Tercio, int Kilogramos)
        {
            var Respuesta = "";
            Ingerible ingerible = new Ingerible();
            ingerible.Nombre = Ingerible.ToUpper();
            double Bebido = 0;
            double AlcoholBebida = 0;
            double AlcoholSangre = 0;
            double Ethol = 0;
            double VolSangre = 0;
            double VolumenAlcohol = 0;

            switch(ingerible.Nombre)
            {
                case "CERVEZA":
                    ingerible.Mililitros = 330;
                    ingerible.Grados = 0.05;
                break;
                case "VINO":
                    ingerible.Mililitros = 100;
                    ingerible.Grados = 0.12;
                break;
                case "VERMÚ":
                    ingerible.Mililitros = 70;
                    ingerible.Grados = 0.17;
                break;
                case "LICOR":
                    ingerible.Mililitros = 45;
                    ingerible.Grados = 0.23;
                break;
                case "BRANDY":
                    ingerible.Mililitros = 45;
                    ingerible.Grados = 0.38;
                break;
                case "COMBINADO":
                    ingerible.Mililitros = 50;
                    ingerible.Grados = 38;
                break;
                default:
                    Respuesta = ($"El nombre de la bebida {Ingerible} ingresada no existe");
                    return Ok(Respuesta);

            }

            Bebido = ingerible.Mililitros * Tercio;
            AlcoholBebida = ingerible.Grados * Bebido;
            AlcoholSangre = 0.15 * AlcoholBebida;
            Ethol = 0.789 * AlcoholSangre;
            VolSangre = 0.08 * Kilogramos;
            VolumenAlcohol = Ethol/VolSangre;

            if (VolumenAlcohol > 0.8)
            {
                Respuesta = ($"La cantidad de alcohol que tiene en la sangre es {VolumenAlcohol.ToString("##,##0.0")}, por lo tanto se debe solicitar ayuda para el conductor");
            }
            else
            {
                Respuesta = ($"Le deseo un Buen Viaje...");
            }
            return Ok(Respuesta);

        } 

    }
}