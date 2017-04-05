using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IdeallySpeaking.Data;

namespace IdeallySpeaking.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170405010845_MVCRunThrough_1")]
    partial class MVCRunThrough_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IdeallySpeaking.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("ApplicationUserId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("IdeallySpeaking.Models.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AuthorId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Headline")
                        .HasMaxLength(125);

                    b.Property<int?>("ProfileId");

                    b.Property<string>("Teaser");

                    b.HasKey("ArticleId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("IdeallySpeaking.Models.Badge", b =>
                {
                    b.Property<int>("BadgeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Caption")
                        .HasMaxLength(150);

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<int?>("ProfileId");

                    b.HasKey("BadgeId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Badges");
                });

            modelBuilder.Entity("IdeallySpeaking.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationUserId");

                    b.Property<string>("ApplicationUserId1");

                    b.Property<int>("ArticleId");

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasMaxLength(600);

                    b.Property<DateTime>("CommentDate");

                    b.Property<int?>("CommentId1");

                    b.Property<int?>("ProfileId");

                    b.Property<int>("Rating");

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("CommentId");

                    b.HasIndex("ApplicationUserId1");

                    b.HasIndex("ArticleId");

                    b.HasIndex("CommentId1");

                    b.HasIndex("ProfileId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("IdeallySpeaking.Models.Profile", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Facebook");

                    b.Property<DateTime>("JoinDate");

                    b.Property<string>("Link");

                    b.Property<string>("Location")
                        .HasMaxLength(50);

                    b.Property<string>("Signature")
                        .HasMaxLength(180);

                    b.Property<string>("Twitter");

                    b.Property<string>("UserName")
                        .HasMaxLength(16);

                    b.HasKey("ProfileId");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

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

            modelBuilder.Entity("IdeallySpeaking.Models.Article", b =>
                {
                    b.HasOne("IdeallySpeaking.Models.ApplicationUser", "Author")
                        .WithMany("AuthoredArticles")
                        .HasForeignKey("AuthorId");

                    b.HasOne("IdeallySpeaking.Models.Profile")
                        .WithMany("AuthoredArticles")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("IdeallySpeaking.Models.Badge", b =>
                {
                    b.HasOne("IdeallySpeaking.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("BadgeList")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("IdeallySpeaking.Models.Profile")
                        .WithMany("BadgeList")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("IdeallySpeaking.Models.Comment", b =>
                {
                    b.HasOne("IdeallySpeaking.Models.ApplicationUser")
                        .WithMany("UserCommentList")
                        .HasForeignKey("ApplicationUserId1");

                    b.HasOne("IdeallySpeaking.Models.Article")
                        .WithMany("ArticleCommentsList")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IdeallySpeaking.Models.Comment")
                        .WithMany("UserCommentList")
                        .HasForeignKey("CommentId1");

                    b.HasOne("IdeallySpeaking.Models.Profile")
                        .WithMany("UserCommentList")
                        .HasForeignKey("ProfileId");
                });

            modelBuilder.Entity("IdeallySpeaking.Models.Profile", b =>
                {
                    b.HasOne("IdeallySpeaking.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("Profile")
                        .HasForeignKey("IdeallySpeaking.Models.Profile", "ApplicationUserId");
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
                    b.HasOne("IdeallySpeaking.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("IdeallySpeaking.Models.ApplicationUser")
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

                    b.HasOne("IdeallySpeaking.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
