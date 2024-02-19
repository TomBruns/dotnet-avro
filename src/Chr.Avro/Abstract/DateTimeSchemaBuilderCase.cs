using System;

// This class represents a
// C#:          System.DateTime
// as a AVRO:   "type": "long",
//              "logicalType": "timestamp-millis"
namespace Chr.Avro.Abstract
{
    public class DateTimeSchemaBuilderCase : SchemaBuilderCase, ISchemaBuilderCase
    {
        public SchemaBuilderCaseResult BuildSchema(Type type, SchemaBuilderContext context)
        {
            if (type == typeof(DateTime))
            {
                var dateTimeSchema = new LongSchema
                {
                    LogicalType = new MillisecondTimestampLogicalType(),
                };

                try
                {
                    context.Schemas.Add(type, dateTimeSchema);
                }
                catch (ArgumentException exception)
                {
                    throw new InvalidOperationException($"A schema for {type} already exists on the schema builder context.", exception);
                }

                return SchemaBuilderCaseResult.FromSchema(dateTimeSchema);
            }
            else
            {
                return SchemaBuilderCaseResult.FromException(new UnsupportedTypeException(type, $"{nameof(DateTimeSchemaBuilderCase)} can only be applied to the {typeof(DateTime)} type."));
            }
        }
    }
}
