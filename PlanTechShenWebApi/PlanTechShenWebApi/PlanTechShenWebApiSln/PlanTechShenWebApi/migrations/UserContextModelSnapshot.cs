using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PlanTechShenApp.Data;

namespace PlanTechShenWebApi.migrations
{
    [DbContext(typeof(UserContext))]
    partial class UserContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PlanTechShenWebApi.Models.Authentication", b =>
            {
                b.Property<int>("AuthenticationId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthenticationId"), 1L, 1);

                b.Property<string>("EmailAddress")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<bool>("Enabled")
                    .HasColumnType("bit");

                b.Property<DateTime>("LastLoginTime")
                    .HasColumnType("datetime2");

                b.Property<string>("Password")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("AuthenticationId");

                b.ToTable("Authentication");
            });

            ModelBuilder modelBuilder1 = modelBuilder.Entity("PlanTechShenWebApi.Models.UserAccount", b =>
            {
                b.Property<int>("UserAccountId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserAccountId"), 1L, 1);



                b.Property<string>("UserAccountNumber")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("UserAccountId");

       

                b.HasIndex("Description");

                b.ToTable("UserAccount");
            });

           
            modelBuilder.Entity("PlanTechShenWebApi.Models.Client", b =>
            {
                b.Property<int>("UserId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                b.Property<int>("AuthenticationId")
                    .HasColumnType("int");

                b.Property<string>("CellPhoneNumber")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("EmailAddress")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                

                b.Property<string>("Surname")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("UserId");

                b.HasIndex("AuthenticationId");

                b.ToTable("Client");
            });

          

            

            modelBuilder.Entity("PlanTechShenWebApi.Models.UserAccount", b =>
            {
                b.HasOne("PlanTechShenWebApi.Models.UserAccount", "UserAccount")
                    .WithMany()
                    .HasForeignKey("userAccount")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("PlanTechShenWebApi.Models.Client", "Client")
                    .WithMany("UserAccounts")
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("UserAccount");

                b.Navigation("Client");
            });

            modelBuilder.Entity("PlanTechShenWebApi.Models.Client", b =>
            {
                b.HasOne("PlanTechShenWebApi.Models.Authentication", "Authentication")
                    .WithMany()
                    .HasForeignKey("AuthenticationId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Authentication");
            });

           

            modelBuilder.Entity("PlanTechShenWebApi.Models.UserAccount", b =>
            {
                b.Navigation("Activities");
            });

            modelBuilder.Entity("PlanTechShenWebApi.Models.Client", b =>
            {
                b.Navigation("UserAccounts");
            });
#pragma warning restore 612, 618
        }
    }
}
