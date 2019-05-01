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