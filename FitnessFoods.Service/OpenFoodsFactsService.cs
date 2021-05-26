using FitnessFoods.Domain.Entities;
using FitnessFoods.Domain.Enums;
using FitnessFoods.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FitnessFoods.Application.CronSystem
{

    public class OpenFoodsFactsService : IOpenFoodsFactsService
    {

        private readonly IProductService _productService;
        private readonly IImportHistoryService _importHistoryService;
        private List<Product> _products = new List<Product>();
        private string _downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads\\");
        private HttpClient _httpClient = new HttpClient();
        private HttpResponseMessage _response = new HttpResponseMessage();
        private bool _downloadFailure = false;

        private JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
            Converters = {new StatusJsonConverter(), new DateTimeJsonConverter(),
                             new DoubleJsonConverter(), new IntJsonConverter()}
        };

        public OpenFoodsFactsService(IProductService productService, IImportHistoryService importHistoryService)
        {
            _productService = productService;
            _importHistoryService = importHistoryService;
        }

        public async Task ImportData()
        {
            
            for (int i = 1; i <= 9; i++)
            {
                
                Task retryTask = Task.Run(async () => { _response = await _httpClient.GetAsync($"https://challenges.coode.sh/food/data/json/products_0{i}.json.gz"); });

                // Tenta fazer o download pela 1º vez
                await retryTask;

                int retryMilliseconds = 30000;
                int retryTimes = 0;

                // Caso o download falhe, tenta até 3x 
                while (!_response.IsSuccessStatusCode && retryTimes <= 3)
                {
                    await Task.Delay(retryMilliseconds);
                    await retryTask;
                    retryMilliseconds *= 2;
                    retryTimes++;
                }


                // Caso um dos downloads falhe, insere no banco a data/hora do evento 
                if (!_response.IsSuccessStatusCode)
                {
                    await _importHistoryService.InserHistory(new ImportHistory { Time = DateTime.Now, Failure = true, File = $"products_0{i}.json.gz" });
                    _downloadFailure = true;
                    continue; // Pula para a próxima iteração 
                }


                // Grava os aquivos na pasta Downloads do sistema
                using (FileStream fileStream = new FileStream(Path.Combine(_downloadsPath, $"products_0{i}.json.gz"), FileMode.Create, FileAccess.Write))
                {
                    await _response.Content.CopyToAsync(fileStream);
                }


                // Leitura dos arquivos
                using (FileStream fileStream = new FileStream(Path.Combine(_downloadsPath, $"products_0{i}.json.gz"), FileMode.Open, FileAccess.Read))
                using (GZipStream gZipStream = new GZipStream(fileStream, CompressionMode.Decompress))
                using (StreamReader streamReader = new StreamReader(gZipStream))
                {
                    // Faz a leitura das 100 primeiras linhas de cada arquivo
                    for (int j = 1; j <= 100; j++)
                    {
                            string line = await streamReader.ReadLineAsync();
                            Product product = JsonSerializer.Deserialize<Product>(line, _options);
                            _products.Add(product);
                    }
                }

            }

            // Insere os produtos no banco
            await _productService.InsertProducts(_products);

            // Se não houver falha no download dos aquivos, grava no banco a data/hora do evento
            if (!_downloadFailure)
                await _importHistoryService.InserHistory(new ImportHistory { Time = DateTime.Now });
   
        }

       

    }

    #region Conversores Personalizados
    // Para Enum Status
    internal class StatusJsonConverter : JsonConverter<Status?>
    {
        public override Status? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string status = reader.GetString().ToLower();

            if (string.IsNullOrEmpty(status) || string.IsNullOrWhiteSpace(status))
                return null;

            if(status.Equals("draft"))
                return Status.Draft;
            else if(status.Equals("trash"))
                return Status.Trash;
            else
                return Status.Published;

        }

        public override void Write(Utf8JsonWriter writer, Status? value, JsonSerializerOptions options)
        {

            if (value == null)
                writer.WriteStringValue("");
            else
            {
                switch (value)
                {
                    case Status.Draft: writer.WriteStringValue("draft"); break;
                    case Status.Trash: writer.WriteStringValue("trash"); break;
                    default: writer.WriteStringValue("published"); break;

                }
            }
        }
    }

    // Para Datetime
    internal class DateTimeJsonConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            var value = reader.GetString();

            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return null;

            DateTime imported_t = DateTime.Parse(reader.GetString());
            return imported_t;

        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("pt-BR");

            if (value != null)
                writer.WriteStringValue(DateTime.Parse(value.Value.ToString(), culture).ToString());
            else
                writer.WriteStringValue("");
        }
    }

    // Para double
    internal class DoubleJsonConverter : JsonConverter<double?>
    {
        // TODO: Verificar porque alguns valores estão sendo gravados como negativos
        public override double? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return null;
            else
                return double.Parse(value);


        }

        public override void Write(Utf8JsonWriter writer, double? value, JsonSerializerOptions options)
        {
            if (value == null)
                writer.WriteStringValue("");
            else
                writer.WriteNumberValue(value.Value);
        }
    }

    // Para int
    internal class IntJsonConverter : JsonConverter<int?>
    {
        public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();

            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return null;
            else
                return int.Parse(value);

        }

        public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
        {
            if (value == null)
                writer.WriteStringValue("");
            else
                writer.WriteNumberValue(value.Value);
        }
    }
    #endregion


}
