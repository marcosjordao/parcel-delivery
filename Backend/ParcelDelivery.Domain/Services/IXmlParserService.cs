using ParcelDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ParcelDelivery.Domain.Services
{
    public interface IXmlParserService
    {
        Container ParseXml(XDocument document);
    }
}
