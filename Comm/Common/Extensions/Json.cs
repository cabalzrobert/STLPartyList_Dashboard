
using System;
using System.Text.Json;
using System.IO;
using System.Text;
namespace Comm.Common.Extensions
{
    public static class JsonExt
    {
        public static T ToObject<T>(this JsonElement element, JsonSerializerOptions options = null)
        {
            var bufferWriter = new MemoryStream();
            using (var writer = new Utf8JsonWriter(bufferWriter))
                element.WriteTo(writer);
            return JsonSerializer.Deserialize<T>(bufferWriter.ToArray(), options);
        }

        public static T ToObject<T>(this JsonDocument document, JsonSerializerOptions options = null)
        {
            if (document == null)
                throw new ArgumentNullException(nameof(document));
            return document.RootElement.ToObject<T>(options);
        }       

        public static object ToObject(this JsonElement element, Type returnType, JsonSerializerOptions options = null)
        {
            var bufferWriter = new MemoryStream();
            using (var writer = new Utf8JsonWriter(bufferWriter))
                element.WriteTo(writer);
            byte[] buffer = bufferWriter.ToArray();
            return JsonSerializer.Deserialize(Encoding.UTF8.GetString(buffer, 0, buffer.Length), returnType, options);
        }

        public static object ToObject(this JsonDocument document, Type returnType, JsonSerializerOptions options = null)
        {
            if (document == null)
                throw new ArgumentNullException(nameof(document));
            return document.RootElement.ToObject(returnType, options);
        }          
    }
}