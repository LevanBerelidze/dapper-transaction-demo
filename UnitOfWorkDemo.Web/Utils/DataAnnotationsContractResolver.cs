using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace UnitOfWorkDemo.Web.Utils
{
    public class DataAnnotationsContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            bool hasRequiredAttribute = Attribute.IsDefined(member, typeof(RequiredAttribute));
            if (hasRequiredAttribute)
            {
                property.Required = Required.Always;
            }

            return property;
        }
    }
}
