
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace WinForms
{

    [DataContract]
    class ConnectionString
    {
        [DataMember]
        public string _Server { get; set; }
        [DataMember]
        public string _Db { get; set; }
        [DataMember]
        public string _User { get; set; }
        [DataMember]
        public string _Password { get; set; }

        public static string Init(string path)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(ConnectionString));
            FileStream buffer = File.OpenRead($"{path}");
            var obj = jsonSerializer.ReadObject(buffer) as ConnectionString;
            buffer.Close();
            return $"Server={obj._Server};Database={obj._Db};Uid={obj._User};Pwd={obj._Password};";
        }
    }
}
