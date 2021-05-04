using System;
using Newtonsoft.Json;

using System.Globalization;

namespace PA_PLUGIN
{
    public class StringConverter : JsonConverter
    {
        public override bool CanRead => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(double) || objectType == typeof(double?) || objectType == typeof(int)                  // YEASH, DATS A BIGGIE SMALLS
                || objectType == typeof(int?) || objectType == typeof(byte) || objectType == typeof(byte?)                     // YEASH, DATS A BIGGIE SMALLS
                || objectType == typeof(ControlType) || objectType == typeof(AutoKillType) || objectType == typeof(ShapeType); // YEASH, DATS A BIGGIE SMALLS
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new ApplicationException("HOW IN GODS NAME DID YOU GET HERE?");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string s = value.GetType().Name;
            switch (s)
            {
                case "Double":
                    writer.WriteValue(((double)value).ToString(CultureInfo.InvariantCulture));
                    break;
                case "Int32":
                    writer.WriteValue(((int)value).ToString(CultureInfo.InvariantCulture));
                    break;
                case "Decimal":
                    writer.WriteValue(((decimal)value).ToString(CultureInfo.InvariantCulture));
                    break;
                case "Byte":
                    writer.WriteValue(((byte)value).ToString(CultureInfo.InvariantCulture));
                    break;
                case "ControlType":
                    writer.WriteValue(((ControlType)value));
                    break;
                case "AutoKillType":
                    writer.WriteValue(((int)value).ToString(CultureInfo.InvariantCulture));
                    break;
                case "ShapeType":
                    writer.WriteValue(((int)value).ToString(CultureInfo.InvariantCulture));
                    break;
                default:
                    throw new ApplicationException("Could Not Convert Varible");
            }
            

        }
    }
}
