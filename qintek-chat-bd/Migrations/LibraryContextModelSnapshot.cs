// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using qintek_chat_bd;

namespace qintek_chat_bd.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("qintek_chat_bd.Models.groups", b =>
                {
                    b.Property<int>("groupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("dateCreated")
                        .HasColumnType("timestamp");

                    b.Property<byte[]>("grupo")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("userID_A")
                        .HasColumnType("int");

                    b.Property<int>("userID_B")
                        .HasColumnType("int");

                    b.HasKey("groupID");

                    b.ToTable("groups");
                });

            modelBuilder.Entity("qintek_chat_bd.Models.messages", b =>
                {
                    b.Property<int>("messageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("group")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("message")
                        .HasColumnType("text");

                    b.Property<bool>("readed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("messageID");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("qintek_chat_bd.Models.users", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("connectionId")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTimeOffset>("dateLogged")
                        .HasColumnType("timestamp");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int?>("messages")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("nick")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("UserID");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
