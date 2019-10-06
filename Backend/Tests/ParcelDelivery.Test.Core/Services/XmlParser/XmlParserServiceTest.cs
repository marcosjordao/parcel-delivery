using ParcelDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;
using Xunit;
using ParcelDelivery.Domain.ValueObjects;
using ParcelDelivery.Services.XmlParser;
using Newtonsoft.Json;

namespace ParcelDelivery.Test.Core.Services.XmlParser
{
    public class XmlParserTest
    {

        [Fact]
        public void ParseXml_ShouldParseXml_AndReturnContainer()
        {
            // Create a fake XML to parse
            var textXml = @"<Container>
                                <Id>68465468</Id>
                                <ShippingDate>2016-07-22T00:00:00+02:00</ShippingDate>
                                <parcels>
                                    <Parcel>
                                        <Sender>
                                            <Name>Klaas</Name>
                                            <Address>
                                                <Street>Uranusstraat</Street>
                                                <HouseNumber>22</HouseNumber>
                                                <PostalCode>2402AE</PostalCode>
                                                <City>Alphen a/d Rijn</City>
                                            </Address>
                                        </Sender>
                                        <Receipient>
                                            <Name>Piet</Name>
                                            <Address>
                                                <Street>Schenklaan</Street>
                                                <HouseNumber>22</HouseNumber>
                                                <PostalCode>2497AV</PostalCode>
                                                <City>Den Haag</City>
                                            </Address>
                                        </Receipient>
                                        <Weight>0.02</Weight>
                                        <Value>0.0</Value>
                                    </Parcel>
                            </parcels>
                        </Container>";
            var xmlDocument = XDocument.Parse(textXml);

            // Use the service to Parse the XML to a Container object
            var parserService = new XmlParserService();
            var parsedContainer = parserService.ParseXml(xmlDocument);

            // Create a fake expected Container to compare
            var expectedContainer = new Container(id: 68465468,
                                                  shippingDate: DateTime.Parse("2016-07-22T00:00:00+02:00"));
            var parcel = new Parcel(sender: new Person(name: "Klaas",
                                                       address: new Address(street: "Uranusstraat",
                                                                            houseNumber: "22",
                                                                            postalCode: "2402AE",
                                                                            city: "Alphen a/d Rijn")),
                                    receipient: new Person(name: "Piet",
                                                           address: new Address(street: "Schenklaan",
                                                                                houseNumber: "22",
                                                                                postalCode: "2497AV",
                                                                                city: "Den Haag")),
                                    weight: 0.02m,
                                    value: 0);

            expectedContainer.Parcels.Add(parcel);

            // Serialize both objects to JSON to compare
            var expectedJson = JsonConvert.SerializeObject(expectedContainer);
            var parsedJson = JsonConvert.SerializeObject(parsedContainer);

            // Assertion
            Assert.Equal(expectedJson, parsedJson);

            // TODO: implement a specific comparator
        }
    }
}
