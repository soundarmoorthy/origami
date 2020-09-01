using System;
using System.Collections.Generic;
using System.IO;
using Origami.Models;
using Xunit;

namespace Origami.Tests
{
    public class UnitTest1
    {

        [Fact]
        public void Throw_Exception_When_Database_Is_Null()
        {
            Assesment assesment = new Assesment();
            assesment.Name = "Test";
            assesment.SourcePlatform = "OnPrem";
            assesment.Status = "Completed";
            assesment.TargetPlatform = "Azure Managed Instance";
            //assesment.Databases = new List<Database>();
            assesment.ServerInstances = new List<ServerInstance>();
            Assert.Throws<InvalidDataException>
                (() => GeneratorFacade.Generate(assesment));
        }

        [Fact]
        public void Works_Properly_When_Valid_Input_Is_Given()
        {
            Assesment assesment = new Assesment();
            assesment.Name = "Test";
            assesment.SourcePlatform = "OnPrem";
            assesment.Status = "Completed";
            assesment.TargetPlatform = "Azure Managed Instance";
            assesment.Databases = new List<Database>();
            assesment.ServerInstances = new List<ServerInstance>();
            var table = GeneratorFacade.Generate(assesment);
            Assert.NotNull(table);
        }
    }
}
