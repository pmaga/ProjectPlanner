using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ProjectPlannerASP5.Models;

namespace ProjectPlannerASP5.Migrations
{
    [DbContext(typeof(ProjectPlannerContext))]
    [Migration("20151019212342_ProjectNameCol")]
    partial class ProjectNameCol
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta8-15964")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectPlannerASP5.Entities.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("DueDate");

                    b.Property<int>("IssueNumber");

                    b.Property<DateTime>("LastChangeDate");

                    b.Property<int>("ProjectId");

                    b.Property<int>("Status");

                    b.Property<string>("Summary");

                    b.Property<string>("UserName");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("ProjectPlannerASP5.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired()
                        .Annotation("MaxLength", 5);

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Creator");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("ProjectPlannerASP5.Entities.Issue", b =>
                {
                    b.HasOne("ProjectPlannerASP5.Entities.Project")
                        .WithMany()
                        .ForeignKey("ProjectId");
                });
        }
    }
}
