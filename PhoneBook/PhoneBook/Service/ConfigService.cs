using System.IO;
using Newtonsoft.Json;
using PhoneBook.Configs;
using PhoneBook.Service.Abstractions;

namespace PhoneBook.Service
{
    public class ConfigService : IConfigService
    {
        private const string Path = "english.json";
        private readonly Config _config;
        public ConfigService()
        {
            var text = File.ReadAllText(Path);
            _config = JsonConvert.DeserializeObject<Config>(text);
        }

        public Config Config => _config;
    }
}
