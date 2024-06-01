using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace SerializationLibrary
{
    public class Serializer
    {
        public async Task SerializeAsync<T>(T data, string filePath)
        {
            try
            {
                using (FileStream createStream = File.Create(filePath))
                {
                    await JsonSerializer.SerializeAsync(createStream, data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Serialization error: {ex.Message}");
            }
        }

        public async Task<T> DeserializeAsync<T>(string filePath)
        {
            try
            {
                using (FileStream openStream = File.OpenRead(filePath))
                {
                    return await JsonSerializer.DeserializeAsync<T>(openStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deserialization error: {ex.Message}");
                return default;
            }
        }
    }
}
