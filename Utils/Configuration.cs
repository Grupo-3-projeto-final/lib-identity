using System.Text.Json;

namespace IdentityGama.Utils
{
    public static class Configuration
    {
        public static string ValueAppSettings(string key)
        {
            string pathToJsonFile = "AppSettings.json";

            // Lê todo o conteúdo do arquivo JSON em uma string
            string jsonString = File.ReadAllText(pathToJsonFile);

            // Desserializa o JSON para um objeto do tipo dynamic (ou você pode criar uma classe com a mesma estrutura do JSON e desserializar para essa classe)
            string value = JsonSerializer.Deserialize<JsonElement>(jsonString).GetProperty(key).ToString();

            return value;

        }
    }
}
