using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using PolymorphicDataBinding.Models;

namespace PolymorphicDataBinding.Serialization
{
    public class ProductRequestConverter : JsonConverter<ProductRequest>
    {
        public override ProductRequest? Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            var dict = GetProperties(ref reader, options);

            if (dict["Product"].ToString().Equals("Property Owners"))
            {
                if (Convert.ToInt32(dict["Version"].ToString()) == 1)
                {
                    return CreateTypeFromDictionary<PropertyOwnersV1>(dict);
                }

                return CreateTypeFromDictionary<PropertyOwnersV2>(dict);
            }

            return CreateTypeFromDictionary<TradesAndProfessionsV1>(dict);
        }

        private static T CreateTypeFromDictionary<T>(IDictionary<string, string> properties)
        {
            T obj = Activator.CreateInstance<T>();

            foreach (var property in typeof(T).GetProperties())
            {   
                property.SetValue(obj, Convert.ChangeType(properties[property.Name], property.PropertyType));
            }

            return obj;
        }

        private static IDictionary<string, string> GetProperties(ref Utf8JsonReader reader,
            JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var dictionary = new Dictionary<string, string>();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return dictionary;
                }

                // Get the key.
                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }

                string propertyName = reader.GetString();


                var value = JsonSerializer.Deserialize<object>(ref reader, options);

                // Add to dictionary.
                dictionary.Add(propertyName, value.ToString());
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, ProductRequest value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}