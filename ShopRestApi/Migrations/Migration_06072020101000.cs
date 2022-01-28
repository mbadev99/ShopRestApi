using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRestApi.Migrations
{
    [Migration(06072020101000)]
    public class Migration_06072020101000:Migration
    {
        public override void Down()
        {
            Delete.Table("Products");
        }

        public override void Up()
        {
            Create.Table("Products")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Count").AsInt32().NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable();
        }
    }
}
