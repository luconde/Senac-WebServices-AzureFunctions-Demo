using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

using Microsoft.Extensions.Configuration;


namespace SenacBikeStore
{
    public static class CategoriasFuncoes
    {
        [FunctionName("ListarCategorias")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ExecutionContext context,
            ILogger log)
        {
            //
            // Carrega as configurações existentes
            //
            var config = new ConfigurationBuilder().SetBasePath(context.FunctionAppDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            log.LogInformation("Iniciando");

            //
            // Abrindo a consultando no banco
            //
            log.LogInformation("Abrindo a conexao");
            string strConnectionString = config["ConnectionStrings:DefaultConnection"];
            log.LogInformation(strConnectionString);

            var objConnection = new MySqlConnection(strConnectionString);
            objConnection.Open();
            log.LogInformation("Conexao aberta com sucesso");

            //
            // Consultando os dados
            //
            log.LogInformation("Consultando o banco");
            var objCommand = objConnection.CreateCommand();            
            objCommand.CommandText = "SELECT * FROM categorias";
            MySqlDataReader objLinhas = objCommand.ExecuteReader();
            log.LogInformation("Consulta realizada com sucesso");

            //
            // Transferindo os dados
            //
            log.LogInformation("Transferindo os dados para serialização em JSON");
            List<CResponse> objLista = new List<CResponse>();
            while(objLinhas.Read())
            {
                CResponse objResp = new CResponse();
                objResp.id = objLinhas["pkcategoria"].ToString();
                objResp.nome_da_categoria = objLinhas["nomedacategoria"].ToString();
                objLista.Add(objResp);
            }

            var jsonToReturn = JsonConvert.SerializeObject(objLista);
            log.LogInformation("Serialização com sucesso");

            //
            // Retornando os resultados
            //
            log.LogInformation("Finalizando");
            objConnection.Close();
            return new OkObjectResult(jsonToReturn);

        }
    }
}
