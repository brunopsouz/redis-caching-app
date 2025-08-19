using FluentMigrator;

namespace App.Infrastructure.Migrations.Versions;

[Migration(DatabaseVersions.TABLE_PRODUCT, "Create table to save the Products information")]
public class Version0000001 : VersionBase
{
    public override void Up()
    {
        CreateTable("Products")
            .WithColumn("Code").AsString(255).NotNullable()
            .WithColumn("Description").AsString(255).NotNullable()
            .WithColumn("Price").AsString(2000).NotNullable();
    }
}

