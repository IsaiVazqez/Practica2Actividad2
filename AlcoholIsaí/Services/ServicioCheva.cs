using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.Serialization;
using AlcoholIsaí.Dominio;
using AlcoholIsaí.Controllers;



namespace AlcoholIsaí.Services
{
    public class ServicioCheva
    {

        public double CalcularTotalChevaConsumido(string bebida, int cantidad)
        {
            int totalBebidaConsumido;
            double totalChevaPorBebidaConsumido;
            switch (bebida) //Seleccionamos que tiop de bebida se ingirió conforma a la tabla y esta se multipica por la cantidad y los mililitros además de su grado de alcohol
            {
   
                case "vino":
                    totalBebidaConsumido = cantidad * 100;
                    totalChevaPorBebidaConsumido = totalBebidaConsumido * 0.12;
                    break;
                case "cerveza":
                    totalBebidaConsumido = cantidad * 330;
                    totalChevaPorBebidaConsumido = totalBebidaConsumido * 0.05;
                    break;
   
                case "licor":
                    totalBebidaConsumido = cantidad * 45;
                    totalChevaPorBebidaConsumido = totalBebidaConsumido * 0.23;
                    break;
                case "vermu":
                    totalBebidaConsumido = cantidad * 70;
                    totalChevaPorBebidaConsumido = totalBebidaConsumido * 0.17;
                    break;
                case "brandy":
                    totalBebidaConsumido = cantidad * 45;
                    totalChevaPorBebidaConsumido = totalBebidaConsumido * 0.38;
                    break;
                case "combinado":
                    totalBebidaConsumido = cantidad * 50;
                    totalChevaPorBebidaConsumido = totalBebidaConsumido * 0.38;
                    break;
                default:
                    return totalChevaPorBebidaConsumido = 0;
                    break;
            }
            return totalChevaPorBebidaConsumido;
        }

        //Realiazmos las conversiones de sangre conforme al PDF de la tarea
        public double CalcularCantidadChevaSangre(double totalChevaPorBebidaConsumido)
        {
            double cantidadChevaSangre = (totalChevaPorBebidaConsumido * 15) / 100;
            return cantidadChevaSangre;
        }

        //Calcular la masa del etanol en sangre
        public double CalcularMasa(double cantidadChevaSangre)
        {
            double masa = 0.789 * cantidadChevaSangre;
            return masa;
        }

        //Calcular el volumen de la sangre de la persona considerando su peso
        public double CalcularVolumenSangre(double peso)
        {
            double volumenSangre = (8 * peso / 100);
            return volumenSangre;
        }


        //Calcular el volumen de alcohol en la sangre (Alcoholemia)
        public double CalcularVolumenCheva(double masa, double volumenSangre)
        {
            double volumenCheva = masa / volumenSangre;
            return volumenCheva;
        }

        //Validar si es apto para conducir
        public string Validar(double volumenCheva)
        {
            string resultado;

            if (volumenCheva > 0.8)
            {
                resultado = $"Usted esta borracho, cuenta con: {volumenCheva}. Ni se atreva a conducir por favor.";
                return resultado;
            }
            resultado = $"Su voluman dealcohol en su cuerpo es menor a loe stablecido: {volumenCheva} Tenga un buen viaje";
            return resultado;
        }


    }
}
