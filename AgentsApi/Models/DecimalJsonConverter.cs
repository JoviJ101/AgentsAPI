using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class DecimalConverter : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String && decimal.TryParse(reader.GetString(), out var value))
        {
            return value;
        }
        if (reader.TokenType == JsonTokenType.Number && reader.TryGetDecimal(out var decimalValue))
        {
            return decimalValue;
        }
        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value);
    }
}