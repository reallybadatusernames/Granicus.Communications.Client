using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Granicus.Infrastructure.Entities
{
    public class Page
    {
        [XmlElement("url")]
        public string Url { get; set; } = string.Empty;
    }
}
