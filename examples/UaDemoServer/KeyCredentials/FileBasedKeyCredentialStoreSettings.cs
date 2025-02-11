using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UnifiedAutomation.DemoServer
{
    // [Settings]
    [Serializable]
    [XmlType(Namespace = "http://unifiedAutomation.com/configuration/DemoServer")]
    [XmlRoot(Namespace = "http://unifiedAutomation.com/configuration/DemoServer", IsNullable = false)]
    public class FileBasedKeyCredentialStoreSettings
    {
        public string FileName { get; set; }
    }
    // [Settings]
}
