namespace Chr.Avro.Representation
{
    using System.Text.Json;
    using Chr.Avro.Abstract;

    public class JsonDateTimeSchemaWriterCase : DateTimeSchemaWriterCase, IJsonSchemaWriterCase
    {
        public virtual JsonSchemaWriterCaseResult Write(Schema schema, Utf8JsonWriter json, bool canonical, JsonSchemaWriterContext context)
        {
            if (schema.LogicalType is MillisecondTimestampLogicalType millisecondTimeStampLogicalType)
            {
                if (schema is LongSchema longSchema)
                {
                    //if (context.Names.TryGetValue(fixedSchema.FullName, out var existing))
                    //{
                    //    if (!schema.Equals(existing))
                    //    {
                    //        throw new InvalidSchemaException($"A conflicting schema with the name {fixedSchema.FullName} has already been written.");
                    //    }

                    //    json.WriteStringValue(fixedSchema.FullName);
                    //}
                    //else
                    {
                        //context.Names.Add(fixedSchema.FullName, fixedSchema);

                        json.WriteStartObject();
                        //json.WriteString(JsonAttributeToken.Name, longSchema.FullName);

                        //if (!canonical)
                        //{
                        //    if (fixedSchema.Aliases.Count > 0)
                        //    {
                        //        json.WritePropertyName(JsonAttributeToken.Aliases);
                        //        json.WriteStartArray();

                        //        foreach (var alias in fixedSchema.Aliases)
                        //        {
                        //            json.WriteStringValue(alias);
                        //        }

                        //        json.WriteEndArray();
                        //    }
                        //}

                        json.WriteString(JsonAttributeToken.Type, JsonSchemaToken.Long);

                        if (!canonical)
                        {
                            json.WriteString(JsonAttributeToken.LogicalType, JsonSchemaToken.TimestampMilliseconds);
                        }

                        json.WriteEndObject();
                    }
                }
                else
                {
                    throw new UnsupportedSchemaException(schema, $"A {nameof(MillisecondTimestampLogicalType)} can only be written for a {nameof(LongSchema)} or {nameof(FixedSchema)}.");
                }

                return new JsonSchemaWriterCaseResult();
            }
            else
            {
                return JsonSchemaWriterCaseResult.FromException(new UnsupportedSchemaException(schema, $"{nameof(JsonDateTimeSchemaWriterCase)} can only be applied to {nameof(LongSchema)}s with {nameof(DateTimeLogicalType)}."));
            }
        }

    }
}
