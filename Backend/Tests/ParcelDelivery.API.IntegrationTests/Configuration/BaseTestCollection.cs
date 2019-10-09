using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ParcelDelivery.API.IntegrationTests.Configuration
{
    [CollectionDefinition("Base collection")]
    public abstract class BaseTestCollection : ICollectionFixture<BaseTestFixture>
    {
    }
}
