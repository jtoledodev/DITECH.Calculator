using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Calculator.Api.Consumer.IServices;
using Calculator.Api.Consumer.Services;
using Calculator.Entities.Request;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.CConsole
{
    class Program
    {
        private const string ApiUrl = "http://localhost:28810/api/";
        private static IServiceProvider _serviceProvider;

        static async Task Main(string[] args)
        {
            RegisterServices();

            var apiConsumerService = _serviceProvider.GetService<IApiConsumerService>();

            //Valores estaticos
            const string idSeguimiento = "operaciones123";

            //Llamado al API para realizar una SUMA
            var sumaRequest = new SumaRequest
            {
                Sumandos = new List<double>() {4, 5, 6, 10},
                IdSeguimiento = idSeguimiento
            };

            var sumaResponse = await apiConsumerService.Sumar(sumaRequest);
            Console.WriteLine(sumaResponse);

            //Llamado al API para realizar una resta
            var restaRequest = new RestaRequest
            {
                Minuendo = 10,
                Sustraendo = 6,
                IdSeguimiento = "operaciones123"
            };

            var restaResponse = await apiConsumerService.Restar(restaRequest);
            Console.WriteLine(restaResponse);

            //Llamado al API para realizar una multiplicacion
            var multiRequest = new MultiplicacionRequest
            {
                Factores = new List<double>() { 4, 5},
                IdSeguimiento = "operaciones123"
            };
            
            var multiResponse = await apiConsumerService.Multiplicar(multiRequest);
            Console.WriteLine(multiResponse);

            //Llamado al API para realizar una division
            var divRequest = new DivisionRequest
            {
                Dividendo = 4,
                Divisor = 20,
                IdSeguimiento = "operaciones123"
            };
            
            var divResponse = await apiConsumerService.Dividir(divRequest);
            Console.WriteLine(divResponse);

            //Llamado al API para realizar una raiz cuadrada
            var raizRequest = new RaizCuadradaRequest
            {
                Numero = 9,
                IdSeguimiento = "operaciones123"
            };

            var raizResponse = await apiConsumerService.CalcularRaizCuadrada(raizRequest);
            Console.WriteLine(raizResponse);

            //Llamado al API para consultar el diario
            var consultaDiarioRequest = new ConsultaDiarioRequest
            {
                IdSeguimiento = idSeguimiento
            };

            var consultaDiarioResponse = await apiConsumerService.CosultarDiario(consultaDiarioRequest);
            Console.WriteLine(consultaDiarioResponse);

            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Aplicación Finalizada");
            Console.ReadKey();
        }

        private static void RegisterServices()
        {
            var collection = new ServiceCollection();

            collection.AddSingleton<IApiConsumerService>(new ApiConsumerService(ApiUrl));

            _serviceProvider = collection.BuildServiceProvider();
        }
    }
}