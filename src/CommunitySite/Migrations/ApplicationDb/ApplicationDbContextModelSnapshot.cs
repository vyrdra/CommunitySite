using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CommunitySite.Repository;

namespace CommunitySite.Migrations.ApplicationDb
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CommunitySite.Models.ForumMessage", b =>
                {
                    b.Property<int>("ForumMessageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<int?>("UserParkMemberID");

                    b.HasKey("ForumMessageID");

                    b.HasIndex("UserParkMemberID");

                    b.ToTable("ForumMessages");
                });

            modelBuilder.Entity("CommunitySite.Models.ParkMember", b =>
                {
                    b.Property<int>("ParkMemberID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("DogBreed");

                    b.Property<string>("DogName")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("ForumAlias")
                        .IsRequired();

                    b.Property<string>("Id");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("ParkMemberID");

                    b.ToTable("ParkMembers");
                });

            modelBuilder.Entity("CommunitySite.Models.Reply", b =>
                {
                    b.Property<int?>("ReplyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<int?>("ForumMessageID");

                    b.Property<string>("From");

                    b.HasKey("ReplyID");

                    b.HasIndex("ForumMessageID");

                    b.ToTable("Reply");
                });

            modelBuilder.Entity("CommunitySite.Models.ForumMessage", b =>
                {
                    b.HasOne("CommunitySite.Models.ParkMember", "User")
                        .WithMany()
                        .HasForeignKey("UserParkMemberID");
                });

            modelBuilder.Entity("CommunitySite.Models.Reply", b =>
                {
                    b.HasOne("CommunitySite.Models.ForumMessage")
                        .WithMany("Replys")
                        .HasForeignKey("ForumMessageID");
                });
        }
    }
}
