﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Api.Core.IServices;
using Calculator.Entities.Base;
using Calculator.Entities.Request;
using Calculator.Entities.Response;
using LiteDB;
using Microsoft.Extensions.Configuration;

namespace Calculator.Api.Core.Services
{
    public class DataAccessService : IDataAccessService
    {
        private readonly IConfiguration _config;
        private readonly string _dbFileName;
        private readonly string _diarioCollectionName;

        public DataAccessService(IConfiguration config)
        {
            _config = config;
            _dbFileName = _config.GetSection("AppSettings").GetSection("DbFileName").Value;
            _diarioCollectionName = _config.GetSection("AppSettings").GetSection("DiarioCollectionName").Value;
        }

        public async Task GuardarRegistroDiario(RegistroDiario r)
        {
            await Task.Run(() => {
                using (var db = new LiteDatabase(_dbFileName))
                {
                    //Obtiene la colección donde se van a guardar los registros
                    var operaciones = db.GetCollection<RegistroDiario>(_diarioCollectionName);

                    //Agrega el registro
                    operaciones.Insert(r);

                    //Crea un indice para todos los elementos de la colección
                    operaciones.EnsureIndex(x => x.IdSeguimiento);
                }
            });
        }

        public async Task<ConsultaDiarioResponse> CosultarDiario(ConsultaDiarioRequest r)
        {
            var data = await Task.Run(() => 
            {
                using (var db = new LiteDatabase(_dbFileName))
                {
                    //Obtiene la colección donde se van a guardar los registros
                    var operaciones = db.GetCollection<RegistroDiario>(_diarioCollectionName);

                    //Busca todos los registros que tengan el id de seguimiento
                    return operaciones.Find(x => x.IdSeguimiento.Equals(r.IdSeguimiento));
                }
            });

            var result = new ConsultaDiarioResponse {Operaciones = data.ToList()};

            return result;
        }
    }
}