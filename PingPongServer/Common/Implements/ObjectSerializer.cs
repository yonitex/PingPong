using System.Text;
using Newtonsoft.Json;
using Common.Abstracts;

namespace Common.Implements
{
    public class ObjectSerializer<TObject> : ISerializer<TObject>
    {
        public TObject Deserialize(byte[] data)
        {
            string dataAsJson = Encoding.UTF8.GetString(data);
            TObject deserializedObject = JsonConvert.DeserializeObject<TObject>(dataAsJson);
            return deserializedObject;
        }

        public byte[] Serialize(TObject data)
        {
            string dataAsJson = JsonConvert.SerializeObject(data);
            byte[] output = Encoding.UTF8.GetBytes(dataAsJson);
            return output;
        }
    }
}
