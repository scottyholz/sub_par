using System;
using FluentMigrator;

namespace SubPar.Persistence.Migrations.Migrations
{
    [Migration(20201227124029)]
    public class initial_schema : Migration
    {
        public override void Up()
        {

            Create.Table("Roles")
                .WithColumn("Id").AsInt32().PrimaryKey()
                .WithColumn("Name").AsString(20).NotNullable()
                .WithColumn("CreatedAt").AsDateTime().NotNullable()
                .WithColumn("UpdatedAt").AsDateTime().NotNullable();

            var now = DateTime.Now.ToString("g");
            Execute.Sql($"insert into Roles(Id, Name, CreatedAt, UpdatedAt) values (1,'Administrator','{now}','{now}')");
            Execute.Sql($"insert into Roles(Id, Name, CreatedAt, UpdatedAt) values (2,'Golfer','{now}','{now}')");

            Create.Table("Users")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString(30).NotNullable()
                .WithColumn("LastName").AsString(30).NotNullable()
                .WithColumn("Email").AsString(50).NotNullable()
                .WithColumn("RoleId").AsInt32().NotNullable()
                .WithColumn("DeactivatedAt").AsDateTime().Nullable()
                .WithColumn("CreatedAt").AsDateTime().NotNullable()
                .WithColumn("UpdatedAt").AsDateTime().NotNullable();

            Create.ForeignKey("fk_Users_Role")
                .FromTable("Users").ForeignColumn("RoleId")
                .ToTable("Roles").PrimaryColumn("Id");
        }

        public override void Down()
        {
        }
    }
}
