﻿// <auto-generated />
using System;
using API.Source.Base.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240216234207_PassRequired")]
    partial class PassRequired
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API.Model.Data.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Horario")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Observacao")
                        .HasColumnType("text");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProfissionalId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("API.Model.Data.Atendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AgendamentoId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DataAgendada")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Observacao")
                        .HasColumnType("text");

                    b.Property<int>("PacienteId")
                        .HasColumnType("integer");

                    b.Property<int>("ProfissionalId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusAtendimento")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AgendamentoId")
                        .IsUnique();

                    b.HasIndex("PacienteId");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("Atendimento");
                });

            modelBuilder.Entity("API.Model.Data.HoraAgendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DataAgendamento")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("Hora")
                        .HasColumnType("interval");

                    b.Property<int?>("ProfissionalId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("HoraAgendamento");
                });

            modelBuilder.Entity("API.Model.Data.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int?>("Idade")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("API.Model.Data.Profissional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CargoAtribuido")
                        .HasColumnType("integer");

                    b.Property<string>("Cpf")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("Idade")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ProfissionalId")
                        .HasColumnType("integer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ProfissionalId");

                    b.ToTable("Profissional");
                });

            modelBuilder.Entity("API.Model.Data.Agendamento", b =>
                {
                    b.HasOne("API.Model.Data.Paciente", "Paciente")
                        .WithMany("Agendamento")
                        .HasForeignKey("PacienteId");

                    b.HasOne("API.Model.Data.Profissional", "Profissional")
                        .WithMany("Agendamento")
                        .HasForeignKey("ProfissionalId");

                    b.Navigation("Paciente");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("API.Model.Data.Atendimento", b =>
                {
                    b.HasOne("API.Model.Data.Agendamento", "Agendamento")
                        .WithOne("Atendimento")
                        .HasForeignKey("API.Model.Data.Atendimento", "AgendamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Model.Data.Paciente", "Paciente")
                        .WithMany("Atendimento")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Model.Data.Profissional", "Profissional")
                        .WithMany("Atendimento")
                        .HasForeignKey("ProfissionalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agendamento");

                    b.Navigation("Paciente");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("API.Model.Data.HoraAgendamento", b =>
                {
                    b.HasOne("API.Model.Data.Profissional", "Profissional")
                        .WithMany("HoraAgendamento")
                        .HasForeignKey("ProfissionalId");

                    b.Navigation("Profissional");
                });

            modelBuilder.Entity("API.Model.Data.Profissional", b =>
                {
                    b.HasOne("API.Model.Data.Profissional", null)
                        .WithMany("Paciente")
                        .HasForeignKey("ProfissionalId");
                });

            modelBuilder.Entity("API.Model.Data.Agendamento", b =>
                {
                    b.Navigation("Atendimento");
                });

            modelBuilder.Entity("API.Model.Data.Paciente", b =>
                {
                    b.Navigation("Agendamento");

                    b.Navigation("Atendimento");
                });

            modelBuilder.Entity("API.Model.Data.Profissional", b =>
                {
                    b.Navigation("Agendamento");

                    b.Navigation("Atendimento");

                    b.Navigation("HoraAgendamento");

                    b.Navigation("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}
