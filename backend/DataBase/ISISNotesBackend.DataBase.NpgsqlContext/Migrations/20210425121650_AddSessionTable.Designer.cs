// <auto-generated />
using System;
using ISISNotesBackend.DataBase.NpgsqlContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ISISNotesBackend.DataBase.NpgsqlContext.Migrations
{
    [DbContext(typeof(ISISNotesContext))]
    [Migration("20210425121650_AddSessionTable")]
    partial class AddSessionTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.File", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FilePath")
                        .HasColumnType("text");

                    b.Property<Guid>("FileTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TextNoteId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FileTypeId");

                    b.HasIndex("TextNoteId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.FileType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("FileTypes");
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.Note", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ChangingDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Header")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.Passcode", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Passcodes");
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.TextNote", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Text")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TextNotes");
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.UserNote", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("NoteId")
                        .HasColumnType("uuid");

                    b.Property<int>("Rights")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("NoteId");

                    b.HasIndex("UserId");

                    b.ToTable("UserNotes");
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.UserPhoto", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserPhotos");
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.File", b =>
                {
                    b.HasOne("ISISNotesBackend.DataBase.Models.FileType", "FileType")
                        .WithMany("Files")
                        .HasForeignKey("FileTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISISNotesBackend.DataBase.Models.TextNote", null)
                        .WithMany("Files")
                        .HasForeignKey("TextNoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FileType");
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.Passcode", b =>
                {
                    b.HasOne("ISISNotesBackend.DataBase.Models.User", "User")
                        .WithOne("Passcode")
                        .HasForeignKey("ISISNotesBackend.DataBase.Models.Passcode", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.Session", b =>
                {
                    b.HasOne("ISISNotesBackend.DataBase.Models.User", null)
                        .WithMany("Sessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.TextNote", b =>
                {
                    b.HasOne("ISISNotesBackend.DataBase.Models.Note", "Note")
                        .WithOne("TextNote")
                        .HasForeignKey("ISISNotesBackend.DataBase.Models.TextNote", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Note");
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.UserNote", b =>
                {
                    b.HasOne("ISISNotesBackend.DataBase.Models.Note", "Note")
                        .WithMany("UserNotes")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ISISNotesBackend.DataBase.Models.User", "User")
                        .WithMany("UserNotes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Note");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.UserPhoto", b =>
                {
                    b.HasOne("ISISNotesBackend.DataBase.Models.User", "User")
                        .WithOne("UserPhoto")
                        .HasForeignKey("ISISNotesBackend.DataBase.Models.UserPhoto", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.FileType", b =>
                {
                    b.Navigation("Files");
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.Note", b =>
                {
                    b.Navigation("TextNote");

                    b.Navigation("UserNotes");
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.TextNote", b =>
                {
                    b.Navigation("Files");
                });

            modelBuilder.Entity("ISISNotesBackend.DataBase.Models.User", b =>
                {
                    b.Navigation("Passcode");

                    b.Navigation("Sessions");

                    b.Navigation("UserNotes");

                    b.Navigation("UserPhoto");
                });
#pragma warning restore 612, 618
        }
    }
}
