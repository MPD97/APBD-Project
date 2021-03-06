﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Advert.Database.Migrations
{
    public partial class AddedRefreshTokenTokenToClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "RefreshToken",
                "Clients",
                maxLength: 36,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "RefreshToken",
                "Clients");
        }
    }
}