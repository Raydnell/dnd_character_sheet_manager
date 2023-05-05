using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace dnd_character_sheet
{
    public class RaceSpecifiedConcreteClassConverter : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (typeof(SheetRaceBase).IsAssignableFrom(objectType) && !objectType.IsAbstract)
            {
                return null;
            }

            return base.ResolveContractConverter(objectType);
        }
    }
    
    public class RaceConvertorJson : JsonConverter
    {
        static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings() { ContractResolver = new RaceSpecifiedConcreteClassConverter() };

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(SheetRaceBase));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            switch (jo["Name"].Value<int>())
            {
                case 1:
                    return JsonConvert.DeserializeObject<GnomeRaceDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 2:
                    return JsonConvert.DeserializeObject<DwarfRaceDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 3:
                    return JsonConvert.DeserializeObject<DragonbornRaceDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 4:
                    return JsonConvert.DeserializeObject<HalforcRaceDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 5:
                    return JsonConvert.DeserializeObject<HalflingRaceDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 6:
                    return JsonConvert.DeserializeObject<HalfelfRaceDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 7:
                    return JsonConvert.DeserializeObject<TieflingRaceDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 8:
                    return JsonConvert.DeserializeObject<HumanRaceDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 9:
                    return JsonConvert.DeserializeObject<ElfRaceDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                default:
                    throw new Exception();
            }
            throw new NotImplementedException();
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}