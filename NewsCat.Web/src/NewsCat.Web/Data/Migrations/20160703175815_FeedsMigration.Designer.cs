using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NewsCat.Web.Data;

namespace NewsCat.Web.Migrations
{
    [DbContext(typeof(FeedDataContext))]
    [Migration("20160703175815_FeedsMigration")]
    partial class FeedsMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("NewsCat.Web.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("NewsCat.Web.Models.DTO.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<int>("FeedId");

                    b.Property<DateTime>("ImportDate");

                    b.Property<bool>("IsNew");

                    b.Property<bool>("IsRead");

                    b.Property<string>("RawContent");

                    b.Property<DateTime?>("ReadDate");

                    b.Property<int?>("TagId");

                    b.HasKey("DocumentId");

                    b.HasIndex("FeedId");

                    b.HasIndex("TagId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("NewsCat.Web.Models.DTO.DocumentTag", b =>
                {
                    b.Property<int>("DocumentTagId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DocumentId");

                    b.Property<int>("SortKey");

                    b.Property<int>("TagId");

                    b.HasKey("DocumentTagId");

                    b.HasIndex("DocumentId");

                    b.HasIndex("TagId");

                    b.ToTable("DocumentTag");
                });

            modelBuilder.Entity("NewsCat.Web.Models.DTO.Feed", b =>
                {
                    b.Property<int>("FeedId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<int>("SortKey");

                    b.Property<int?>("TagId");

                    b.Property<string>("Url");

                    b.HasKey("FeedId");

                    b.HasIndex("TagId");

                    b.ToTable("Feeds");
                });

            modelBuilder.Entity("NewsCat.Web.Models.DTO.FeedTag", b =>
                {
                    b.Property<int>("FeedTagId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FeedId");

                    b.Property<int>("SortKey");

                    b.Property<int>("TagId");

                    b.HasKey("FeedTagId");

                    b.HasIndex("FeedId");

                    b.HasIndex("TagId");

                    b.ToTable("FeedTag");
                });

            modelBuilder.Entity("NewsCat.Web.Models.DTO.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NewsCat.Web.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NewsCat.Web.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NewsCat.Web.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewsCat.Web.Models.DTO.Document", b =>
                {
                    b.HasOne("NewsCat.Web.Models.DTO.Feed", "Feed")
                        .WithMany("Documents")
                        .HasForeignKey("FeedId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NewsCat.Web.Models.DTO.Tag")
                        .WithMany("Documents")
                        .HasForeignKey("TagId");
                });

            modelBuilder.Entity("NewsCat.Web.Models.DTO.DocumentTag", b =>
                {
                    b.HasOne("NewsCat.Web.Models.DTO.Document", "Document")
                        .WithMany("Tags")
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NewsCat.Web.Models.DTO.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NewsCat.Web.Models.DTO.Feed", b =>
                {
                    b.HasOne("NewsCat.Web.Models.DTO.Tag")
                        .WithMany("Feeds")
                        .HasForeignKey("TagId");
                });

            modelBuilder.Entity("NewsCat.Web.Models.DTO.FeedTag", b =>
                {
                    b.HasOne("NewsCat.Web.Models.DTO.Feed", "Feed")
                        .WithMany("Tags")
                        .HasForeignKey("FeedId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NewsCat.Web.Models.DTO.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
