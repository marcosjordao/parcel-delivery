using ParcelDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ParcelDelivery.Services.Parser
{
    public class DeliveryXmlParser
    {
        public Container ParseXml(XDocument document)
        {
            var serializer = new XmlSerializer(typeof(Container));

            using (var reader = document.CreateReader())
            {
                return (Container)serializer.Deserialize(reader);
            };

        }
    }
}
