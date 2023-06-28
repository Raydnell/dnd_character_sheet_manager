using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace dnd_character_sheet
{
    public class ClassSpecifiedConcreteClassConverter : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (typeof(SheetClassBase).IsAssignableFrom(objectType) && !objectType.IsAbstract)
            {
                return null;
            }

            return base.ResolveContractConverter(objectType);
        }
    }
    
    public class ClassConvertorJson : JsonConverter
    {
        static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings() { ContractResolver = new ClassSpecifiedConcreteClassConverter() };

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(SheetClassBase));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            switch (jo["Name"].Value<int>())
            {
                case 0:
                    return JsonConvert.DeserializeObject<BardClassDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 1:
                    return JsonConvert.DeserializeObject<BarbarianClassDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 2:
                    return JsonConvert.DeserializeObject<FighterClassDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 3:
                    return JsonConvert.DeserializeObject<WizardClassDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 4:
                    return JsonConvert.DeserializeObject<DruidClassDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 5:
                    return JsonConvert.DeserializeObject<ClericClassDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 6:
                    return JsonConvert.DeserializeObject<WarlockClassDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 7:
                    return JsonConvert.DeserializeObject<MonkClassDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 8:
                    return JsonConvert.DeserializeObject<PaladinClassDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 9:
                    return JsonConvert.DeserializeObject<RogueClassDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 10:
                    return JsonConvert.DeserializeObject<RangerClassDND5e>(jo.ToString(), SpecifiedSubclassConversion);

                case 11:
                    return JsonConvert.DeserializeObject<SorcererClassDND5e>(jo.ToString(), SpecifiedSubclassConversion);

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