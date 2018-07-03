using LegoAbp.Reflection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LegoAbp.Tests.EFCore
{
    public class AppDomainAllAssembly
    {
        [Fact]
        public void Find()
        {
          var ass=  new AppDomainAllAssemblyFinder().FindAll();
        }
    }
}
