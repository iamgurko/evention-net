// <auto-generated />

using System.CodeDom.Compiler;
using System.Data.Entity.Migrations.Infrastructure;
using System.Resources;

namespace Evention.Migrations
{
    [GeneratedCode("EntityFramework.Migrations", "6.1.1-30610")]
    public sealed partial class AddIsCanceledToEvent : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddIsCanceledToEvent));
        
        string IMigrationMetadata.Id
        {
            get { return "201812012352403_AddIsCanceledToEvent"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}