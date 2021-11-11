using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace WinForms
{
    [DataContract]
    class Questions
    {
        [DataMember]
        public string TestName { get; set; }
        [DataMember]
        public string Question { get; set; }
        [DataMember]
        public Dictionary<string, string> Answers { get; set; }
        [DataMember]
        public uint TrueAnswer { get; set; }

        public List<Questions> QuestionsDeserialization(string path)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Questions>));
            FileStream buffer = File.OpenRead($"{path}");
            var item = jsonSerializer.ReadObject(buffer) as List<Questions>;
            buffer.Close();
            return item;
        }
    }
}
