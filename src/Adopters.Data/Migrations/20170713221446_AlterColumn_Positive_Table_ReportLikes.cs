﻿// <auto-generated/>
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Adopters.Data.Migrations
{
    public partial class AlterColumn_Positive_Table_ReportLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Positive",
                table: "ReportLikes",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Positive",
                table: "ReportLikes",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
