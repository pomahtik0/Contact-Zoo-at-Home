﻿// <auto-generated />
using System;
using Contact_zoo_at_home.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Contact_zoo_at_home.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Comments.BaseComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("BaseComment");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseComment");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Contracts.BaseContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActivityType")
                        .HasColumnType("int");

                    b.Property<string>("ContractAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ContractDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<int>("StatusOfTheContract")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BaseContract");

                    b.HasDiscriminator<string>("Discriminator").HasValue("BaseContract");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Pets.ExtraPetOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OptionLanguage")
                        .HasColumnType("int");

                    b.Property<string>("OptionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PetId");

                    b.ToTable("ExtraPetOption");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Pets.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ActivityType")
                        .HasColumnType("int");

                    b.Property<int?>("AnimalShelterId")
                        .HasColumnType("int");

                    b.Property<int?>("BaseContractId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CurrentPetStatus")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(4096)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IndividualPetOwnerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("RatedBy")
                        .HasColumnType("int");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(3,2)");

                    b.Property<int>("RestorationTimeInDays")
                        .HasColumnType("int");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Species")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SubSpecies")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.Property<int?>("ZooShopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalShelterId");

                    b.HasIndex("BaseContractId");

                    b.HasIndex("IndividualPetOwnerId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ZooShopId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.BaseUser", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ContactPhone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("ProfileImage")
                        .HasMaxLength(1048576)
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RatedBy")
                        .HasColumnType("int");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(3,2)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Comments.PetComment", b =>
                {
                    b.HasBaseType("Contact_zoo_at_home.Core.Entities.Comments.BaseComment");

                    b.Property<int?>("AnswerToId")
                        .HasColumnType("int");

                    b.Property<int>("CommentTargetId")
                        .HasColumnType("int");

                    b.HasIndex("AnswerToId");

                    b.HasIndex("CommentTargetId");

                    b.HasDiscriminator().HasValue("PetComment");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Comments.UserComment", b =>
                {
                    b.HasBaseType("Contact_zoo_at_home.Core.Entities.Comments.BaseComment");

                    b.Property<float>("CommentRating")
                        .HasColumnType("real");

                    b.Property<int>("CommentTargetId")
                        .HasColumnType("int");

                    b.HasIndex("CommentTargetId");

                    b.ToTable("BaseComment", t =>
                        {
                            t.Property("CommentTargetId")
                                .HasColumnName("UserComment_CommentTargetId");
                        });

                    b.HasDiscriminator().HasValue("UserComment");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Contracts.StandartContract", b =>
                {
                    b.HasBaseType("Contact_zoo_at_home.Core.Entities.Contracts.BaseContract");

                    b.HasDiscriminator().HasValue("StandartContract");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.BaseCompany", b =>
                {
                    b.HasBaseType("Contact_zoo_at_home.Core.Entities.Users.BaseUser");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.IndividualUsers.CompanyPetRepresentative", b =>
                {
                    b.HasBaseType("Contact_zoo_at_home.Core.Entities.Users.BaseUser");

                    b.Property<int>("CompanyRepresentedId")
                        .HasColumnType("int");

                    b.HasIndex("CompanyRepresentedId");

                    b.ToTable("CompanyPetRepresentatives");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.IndividualUsers.CustomerUser", b =>
                {
                    b.HasBaseType("Contact_zoo_at_home.Core.Entities.Users.BaseUser");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.IndividualUsers.IndividualPetOwner", b =>
                {
                    b.HasBaseType("Contact_zoo_at_home.Core.Entities.Users.BaseUser");

                    b.ToTable("IndividualPetOwners");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.UsersAsCompany.AnimalShelter", b =>
                {
                    b.HasBaseType("Contact_zoo_at_home.Core.Entities.Users.BaseCompany");

                    b.ToTable("AnimalShelters");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.UsersAsCompany.ZooShop", b =>
                {
                    b.HasBaseType("Contact_zoo_at_home.Core.Entities.Users.BaseCompany");

                    b.ToTable("ZooShops");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Comments.BaseComment", b =>
                {
                    b.HasOne("Contact_zoo_at_home.Core.Entities.Users.BaseUser", "Author")
                        .WithMany("MyComments")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Pets.ExtraPetOption", b =>
                {
                    b.HasOne("Contact_zoo_at_home.Core.Entities.Pets.Pet", null)
                        .WithMany("PetOptions")
                        .HasForeignKey("PetId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Pets.Pet", b =>
                {
                    b.HasOne("Contact_zoo_at_home.Core.Entities.Users.UsersAsCompany.AnimalShelter", null)
                        .WithMany("OwnedPets")
                        .HasForeignKey("AnimalShelterId");

                    b.HasOne("Contact_zoo_at_home.Core.Entities.Contracts.BaseContract", null)
                        .WithMany("PetsInContract")
                        .HasForeignKey("BaseContractId");

                    b.HasOne("Contact_zoo_at_home.Core.Entities.Users.IndividualUsers.IndividualPetOwner", null)
                        .WithMany("OwnedPets")
                        .HasForeignKey("IndividualPetOwnerId");

                    b.HasOne("Contact_zoo_at_home.Core.Entities.Users.BaseUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Contact_zoo_at_home.Core.Entities.Users.UsersAsCompany.ZooShop", null)
                        .WithMany("OwnedPets")
                        .HasForeignKey("ZooShopId");

                    b.OwnsMany("Contact_zoo_at_home.Core.Entities.Pets.PetBlockedDate", "BlockedDates", b1 =>
                        {
                            b1.Property<int>("PetId")
                                .HasColumnType("int");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<DateTime>("BlockedDate")
                                .HasColumnType("datetime2");

                            b1.Property<int>("Reason")
                                .HasColumnType("int");

                            b1.HasKey("PetId", "Id");

                            b1.ToTable("PetBlockedDate");

                            b1.WithOwner()
                                .HasForeignKey("PetId");
                        });

                    b.Navigation("BlockedDates");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.BaseUser", b =>
                {
                    b.OwnsOne("Contact_zoo_at_home.Core.Entities.Notifications.NotificationOptions", "NotificationOptions", b1 =>
                        {
                            b1.Property<int>("BaseUserId")
                                .HasColumnType("int");

                            b1.Property<bool>("NotifyOnPhone")
                                .HasColumnType("bit");

                            b1.Property<bool>("NotifyOnTelegram")
                                .HasColumnType("bit");

                            b1.Property<bool>("NotifyOnViber")
                                .HasColumnType("bit");

                            b1.Property<string>("OtherPhones")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("BaseUserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("BaseUserId");
                        });

                    b.Navigation("NotificationOptions")
                        .IsRequired();
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Comments.PetComment", b =>
                {
                    b.HasOne("Contact_zoo_at_home.Core.Entities.Comments.PetComment", "AnswerTo")
                        .WithMany()
                        .HasForeignKey("AnswerToId");

                    b.HasOne("Contact_zoo_at_home.Core.Entities.Pets.Pet", "CommentTarget")
                        .WithMany("Comments")
                        .HasForeignKey("CommentTargetId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AnswerTo");

                    b.Navigation("CommentTarget");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Comments.UserComment", b =>
                {
                    b.HasOne("Contact_zoo_at_home.Core.Entities.Users.BaseUser", "CommentTarget")
                        .WithMany("Comments")
                        .HasForeignKey("CommentTargetId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CommentTarget");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.BaseCompany", b =>
                {
                    b.HasOne("Contact_zoo_at_home.Core.Entities.Users.BaseUser", null)
                        .WithOne()
                        .HasForeignKey("Contact_zoo_at_home.Core.Entities.Users.BaseCompany", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.IndividualUsers.CompanyPetRepresentative", b =>
                {
                    b.HasOne("Contact_zoo_at_home.Core.Entities.Users.BaseCompany", "CompanyRepresented")
                        .WithMany("CompanyPetRepresentatives")
                        .HasForeignKey("CompanyRepresentedId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Contact_zoo_at_home.Core.Entities.Users.BaseUser", null)
                        .WithOne()
                        .HasForeignKey("Contact_zoo_at_home.Core.Entities.Users.IndividualUsers.CompanyPetRepresentative", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyRepresented");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.IndividualUsers.CustomerUser", b =>
                {
                    b.HasOne("Contact_zoo_at_home.Core.Entities.Users.BaseUser", null)
                        .WithOne()
                        .HasForeignKey("Contact_zoo_at_home.Core.Entities.Users.IndividualUsers.CustomerUser", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.IndividualUsers.IndividualPetOwner", b =>
                {
                    b.HasOne("Contact_zoo_at_home.Core.Entities.Users.BaseUser", null)
                        .WithOne()
                        .HasForeignKey("Contact_zoo_at_home.Core.Entities.Users.IndividualUsers.IndividualPetOwner", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.UsersAsCompany.AnimalShelter", b =>
                {
                    b.HasOne("Contact_zoo_at_home.Core.Entities.Users.BaseCompany", null)
                        .WithOne()
                        .HasForeignKey("Contact_zoo_at_home.Core.Entities.Users.UsersAsCompany.AnimalShelter", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.UsersAsCompany.ZooShop", b =>
                {
                    b.HasOne("Contact_zoo_at_home.Core.Entities.Users.BaseCompany", null)
                        .WithOne()
                        .HasForeignKey("Contact_zoo_at_home.Core.Entities.Users.UsersAsCompany.ZooShop", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Contracts.BaseContract", b =>
                {
                    b.Navigation("PetsInContract");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Pets.Pet", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("PetOptions");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.BaseUser", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("MyComments");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.BaseCompany", b =>
                {
                    b.Navigation("CompanyPetRepresentatives");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.IndividualUsers.IndividualPetOwner", b =>
                {
                    b.Navigation("OwnedPets");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.UsersAsCompany.AnimalShelter", b =>
                {
                    b.Navigation("OwnedPets");
                });

            modelBuilder.Entity("Contact_zoo_at_home.Core.Entities.Users.UsersAsCompany.ZooShop", b =>
                {
                    b.Navigation("OwnedPets");
                });
#pragma warning restore 612, 618
        }
    }
}
