using ParcelDelivery.Domain.Entities;
using ParcelDelivery.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ParcelDelivery.Services.XmlParser
{
    public class DeliveryXmlParserService
    {
        public Container ParseXml(XDocument document)
        {
            XElement containerElement = document.Element("Container");

            return ParseContainerFromXml(containerElement);
        }

        private Container ParseContainerFromXml(XElement containerElement)
        {
            // Container
            int id = int.Parse(containerElement.Element("Id").Value);
            DateTime shippingDate = DateTime.Parse(containerElement.Element("ShippingDate").Value);

            Container container = new Container(id,
                                                shippingDate);

            // Parcels
            IEnumerable<XElement> parcelsElements = containerElement.Element("parcels")
                                                                    .Elements("Parcel");
            foreach (XElement parcelElement in parcelsElements)
            {
                container.Parcels.Add(ParseParcelFromXml(parcelElement));
            }

            return container;
        }

        private Parcel ParseParcelFromXml(XElement parcelElement)
        {
            Person sender = ParsePersonFromXml(parcelElement.Element("Sender"));
            Person receipient = ParsePersonFromXml(parcelElement.Element("Receipient"));

            decimal weight = decimal.Parse(parcelElement.Element("Weight").Value);
            decimal value = decimal.Parse(parcelElement.Element("Value").Value);

            return new Parcel(sender,
                              receipient,
                              weight,
                              value);
        }

        private Person ParsePersonFromXml(XElement personElement)
        {
            string name = personElement.Element("Name").Value;

            XElement addressElement = personElement.Element("Address");
            string street = addressElement.Element("Street").Value;
            string houseNumber = addressElement.Element("HouseNumber").Value;
            string postalCode = addressElement.Element("PostalCode").Value;
            string city = addressElement.Element("City").Value;

            return new Person(name,
                              new Address(street,
                                          houseNumber,
                                          postalCode,
                                          city));
        }

        public T DeserializeToObject<T>(XDocument document)
        {
            using (var reader = document.CreateReader())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(reader);
            };

        }
    }
}
