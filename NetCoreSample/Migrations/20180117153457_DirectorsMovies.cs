using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NetCoreSample.Migrations
{
    public partial class DirectorsMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directors_Movie_MovieID",
                table: "Directors");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Directors_DirectorId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_DirectorId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Directors_MovieID",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "Directors");

            migrationBuilder.CreateTable(
                name: "DirectorsMovies",
                columns: table => new
                {
                    DirectorId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorsMovies", x => new { x.DirectorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_DirectorsMovies_Movie_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Movie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DirectorsMovies_Directors_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirectorsMovies_MovieId",
                table: "DirectorsMovies",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirectorsMovies");

            migrationBuilder.AddColumn<int>(
                name: "DirectorId",
                table: "Movie",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "Directors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_DirectorId",
                table: "Movie",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Directors_MovieID",
                table: "Directors",
                column: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_Movie_MovieID",
                table: "Directors",
                column: "MovieID",
                principalTable: "Movie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Directors_DirectorId",
                table: "Movie",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
