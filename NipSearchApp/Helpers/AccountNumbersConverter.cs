using NipSearchApp.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NipSearchApp.Helpers
{
    public class AccountNumbersConverter : JsonConverter<ICollection<AccountNumbers>>
    {
        public override ICollection<AccountNumbers> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var accountNumbers = new List<AccountNumbers>();

                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                {
                    if (reader.TokenType == JsonTokenType.String)
                    {
                        var number = reader.GetString();
                        var accountNumber = new AccountNumbers { number = number };
                        accountNumbers.Add(accountNumber);
                    }
                }

                return accountNumbers;
            }

            return null;
        }

        public override void Write(Utf8JsonWriter writer, ICollection<AccountNumbers> value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();

            foreach (var accountNumber in value)
            {
                writer.WriteStringValue(accountNumber.number);
            }

            writer.WriteEndArray();
        }
    }

}
