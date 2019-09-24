using ParcelDelivery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Linq;
using Xunit;
using ParcelDelivery.Domain.ValueObjects;

namespace ParcelDelivery.Tests.Services
{
    public class DeliveryXmlParserTest
    {

        [Fact]
        public void Should_Parse_Xml_To_Container()
        {
            var textXml = @"<?xml version=""1.0""?>
                            <Container xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
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
            var document = XDocument.Parse(textXml);

            var expectedContainer = new Container(id: 68465468,
                                                  shippingDate: new DateTime(2016, 07, 22));
            var sender = new Person(name: "Klaas",
                                    new Address(street: "Uranusstraat",
                                                houseNumber: "22",
                                                postalCode: "2402AE",
                                                city: "Alphen a/d Rijn"));
            var receipient = new Person(name: "Piet",
                                        new Address(street: "Schenklaan",
                                                    houseNumber: "22",
                                                    postalCode: "2497AV",
                                                    city: "Den Haag"));
            var Parcel = new Parcel(sender: sender,
                                    receipient: receipient,
                                    weight: 0.02d,
                                    value: 0.0);


        }
    }
}
