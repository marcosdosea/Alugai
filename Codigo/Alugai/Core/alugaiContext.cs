using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core
{
    public partial class alugaiContext : DbContext
    {
        public alugaiContext()
        {
        }

        public alugaiContext(DbContextOptions<alugaiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluguel> Aluguel { get; set; }
        public virtual DbSet<Aluguelimovel> Aluguelimovel { get; set; }
        public virtual DbSet<Anuncio> Anuncio { get; set; }
        public virtual DbSet<Despesas> Despesas { get; set; }
        public virtual DbSet<Imovel> Imovel { get; set; }
        public virtual DbSet<Manuntencao> Manuntencao { get; set; }
        public virtual DbSet<Pagamento> Pagamento { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Pessoaaluguel> Pessoaaluguel { get; set; }
      //  public virtual DbSet<Statusimovel> Statusimovel { get; set; }
     //   public virtual DbSet<Statusmanuntencao> Statusmanuntencao { get; set; }
        public virtual DbSet<Statuspagamento> Statuspagamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluguel>(entity =>
            {
                entity.HasKey(e => e.CodigoAluguel)
                    .HasName("PRIMARY");

                entity.ToTable("aluguel");

                entity.HasIndex(e => e.CodigoStatusPagamento)
                    .HasName("fk_Aluguel_StatusPagamento1_idx");

                entity.Property(e => e.CodigoAluguel).HasColumnName("codigoAluguel");

                entity.Property(e => e.CodigoStatusPagamento).HasColumnName("codigoStatusPagamento");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoStatusPagamentoNavigation)
                    .WithMany(p => p.Aluguel)
                    .HasForeignKey(d => d.CodigoStatusPagamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Aluguel_StatusPagamento1");
            });

            modelBuilder.Entity<Aluguelimovel>(entity =>
            {
                entity.HasKey(e => new { e.CodigoAluguel, e.CodigoImovel })
                    .HasName("PRIMARY");

                entity.ToTable("aluguelimovel");

                entity.HasIndex(e => e.CodigoAluguel)
                    .HasName("fk_tbAluguel_has_tbImovel_tbAluguel1_idx");

                entity.HasIndex(e => e.CodigoImovel)
                    .HasName("fk_tbAluguel_has_tbImovel_tbImovel1_idx");

                entity.Property(e => e.CodigoAluguel).HasColumnName("codigoAluguel");

                entity.Property(e => e.CodigoImovel).HasColumnName("codigoImovel");

                entity.HasOne(d => d.CodigoAluguelNavigation)
                    .WithMany(p => p.Aluguelimovel)
                    .HasForeignKey(d => d.CodigoAluguel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tbAluguel_has_tbImovel_tbAluguel1");

                entity.HasOne(d => d.CodigoImovelNavigation)
                    .WithMany(p => p.Aluguelimovel)
                    .HasForeignKey(d => d.CodigoImovel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tbAluguel_has_tbImovel_tbImovel1");
            });

            modelBuilder.Entity<Anuncio>(entity =>
            {
                entity.HasKey(e => e.CodigoAnuncio)
                    .HasName("PRIMARY");

                entity.ToTable("anuncio");

                entity.HasIndex(e => e.CodigoImovel)
                    .HasName("fk_tbAnuncio_tb_imovel1_idx");

                entity.HasIndex(e => e.CodigoPessoa)
                    .HasName("fk_tbAnuncio_tbPessoa1_idx");

                entity.Property(e => e.CodigoAnuncio).HasColumnName("codigoAnuncio");

                entity.Property(e => e.CodigoImovel).HasColumnName("codigoImovel");

                entity.Property(e => e.CodigoPessoa).HasColumnName("codigoPessoa");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDeAnuncio)
                    .IsRequired()
                    .HasColumnName("tipoDeAnuncio")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodigoImovelNavigation)
                    .WithMany(p => p.Anuncio)
                    .HasForeignKey(d => d.CodigoImovel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tbAnuncio_tb_imovel1");

                entity.HasOne(d => d.CodigoPessoaNavigation)
                    .WithMany(p => p.Anuncio)
                    .HasForeignKey(d => d.CodigoPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tbAnuncio_tbPessoa1");
            });

            modelBuilder.Entity<Despesas>(entity =>
            {
                entity.HasKey(e => e.CodigoDespesas)
                    .HasName("PRIMARY");

                entity.ToTable("despesas");

                entity.HasIndex(e => e.CodigoDespesas)
                    .HasName("codigo_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.CodigoImovel)
                    .HasName("fk_tbDespesas_tbImovel1_idx");

                entity.Property(e => e.CodigoDespesas).HasColumnName("codigoDespesas");

                entity.Property(e => e.CodigoImovel).HasColumnName("codigoImovel");

                entity.Property(e => e.DescricaoDespesa)
                    .IsRequired()
                    .HasColumnName("descricaoDespesa")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDeDespesa)
                    .IsRequired()
                    .HasColumnName("tipoDeDespesa")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.CodigoImovelNavigation)
                    .WithMany(p => p.Despesas)
                    .HasForeignKey(d => d.CodigoImovel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tbDespesas_tbImovel1");
            });

            modelBuilder.Entity<Imovel>(entity =>
            {
                entity.HasKey(e => e.CodigoImovel)
                    .HasName("PRIMARY");

                entity.ToTable("imovel");

                entity.HasIndex(e => e.CodigoImovel)
                    .HasName("codigo_imovel_UNIQUE")
                    .IsUnique();

            /*    entity.HasIndex(e => e.StatusImovelCodigoStatusImovel)
                    .HasName("fk_Imovel_StatusImovel1_idx"); */

                entity.Property(e => e.CodigoImovel).HasColumnName("codigoImovel");

                entity.Property(e => e.AreaQuadrada).HasColumnName("areaQuadrada");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ComplementoEndereco)
                    .HasColumnName("complementoEndereco")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoUf)
                    .IsRequired()
                    .HasColumnName("estadoUf")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.QuantidadeCozinha).HasColumnName("quantidadeCozinha");

                entity.Property(e => e.QuantidadeDeAndares).HasColumnName("quantidadeDeAndares");

                entity.Property(e => e.QuantidadeDeBanheiros).HasColumnName("quantidadeDeBanheiros");

                entity.Property(e => e.QuantidadeDeGaragem).HasColumnName("quantidadeDeGaragem");

                entity.Property(e => e.QuantidadeDeQuartos).HasColumnName("quantidadeDeQuartos");

                entity.Property(e => e.QuantidadeDeSala)
                    .IsRequired()
                    .HasColumnName("quantidadeDeSala")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.QuantidadeDeSuites).HasColumnName("quantidadeDeSuites");

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasColumnName("rua")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                   .IsRequired()
                   .HasColumnName("status")
                   .HasMaxLength(45)
                   .IsUnicode(false);


                // entity.Property(e => e.StatusImovelCodigoStatusImovel).HasColumnName("StatusImovel_codigoStatusImovel");

                entity.Property(e => e.TipoImovel)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ValorDoAluguel).HasColumnName("valorDoAluguel");

                entity.Property(e => e.ValorDoCondominio).HasColumnName("valorDoCondominio");

                entity.Property(e => e.ValorDoIptu).HasColumnName("valorDoIptu");

             /*   entity.HasOne(d => d.StatusImovelCodigoStatusImovelNavigation)
                    .WithMany(p => p.Imovel)
                    .HasForeignKey(d => d.StatusImovelCodigoStatusImovel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Imovel_StatusImovel1"); */
            });

            modelBuilder.Entity<Manuntencao>(entity =>
            {
                entity.HasKey(e => e.CodigoManuntencao)
                    .HasName("PRIMARY");

                entity.ToTable("manuntencao");

                entity.HasIndex(e => e.CodigoImovel)
                    .HasName("fk_tbManuntencao_tb_imovel1_idx");

                entity.HasIndex(e => e.CodigoManuntencao)
                    .HasName("codigo_manuntencao_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.CodigoPessoa)
                    .HasName("fk_tbManuntencao_tbPessoa1_idx");

               // entity.HasIndex(e => e.StatusManuntencaoCodigoStatusManuntencao)
                 //   .HasName("fk_Manuntencao_StatusManuntencao1_idx");

                entity.Property(e => e.CodigoManuntencao).HasColumnName("codigoManuntencao");

                entity.Property(e => e.CodigoImovel).HasColumnName("codigoImovel");

                entity.Property(e => e.CodigoPessoa).HasColumnName("codigoPessoa");

                entity.Property(e => e.ComodoImovel)
                    .IsRequired()
                    .HasColumnName("comodoImovel")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.StatusManuntencao)
                    .IsRequired()
                    .HasColumnName("statusManuntencao")
                    .HasMaxLength(25)
                    .IsUnicode(false);

             //  entity.Property(e => e.StatusManuntencaoCodigoStatusManuntencao).HasColumnName("StatusManuntencao_codigoStatusManuntencao");

                entity.Property(e => e.TipoDeManuntencao)
                    .IsRequired()
                    .HasColumnName("tipoDeManuntencao")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.CodigoImovelNavigation)
                    .WithMany(p => p.Manuntencao)
                    .HasForeignKey(d => d.CodigoImovel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tbManuntencao_tb_imovel1");

                entity.HasOne(d => d.CodigoPessoaNavigation)
                    .WithMany(p => p.Manuntencao)
                    .HasForeignKey(d => d.CodigoPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tbManuntencao_tbPessoa1");

           /*     entity.HasOne(d => d.StatusManuntencaoCodigoStatusManuntencaoNavigation)
                    .WithMany(p => p.Manuntencao)
                    .HasForeignKey(d => d.StatusManuntencaoCodigoStatusManuntencao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Manuntencao_StatusManuntencao1"); */
            });

            modelBuilder.Entity<Pagamento>(entity =>
            {
                entity.HasKey(e => e.CodigoPagamento)
                    .HasName("PRIMARY");

                entity.ToTable("pagamento");

                entity.HasIndex(e => e.CodigoAluguel)
                    .HasName("fk_tbPagamento_tbAluguel1_idx");

                entity.HasIndex(e => e.CodigoPagamento)
                    .HasName("codigo_pagamento_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CodigoPagamento).HasColumnName("codigoPagamento");

                entity.Property(e => e.CodigoAluguel).HasColumnName("codigoAluguel");

                entity.Property(e => e.DataPagamento).HasColumnName("dataPagamento");

                entity.Property(e => e.DataVencimento).HasColumnName("dataVencimento");

                entity.Property(e => e.FormaDePagamento)
                    .IsRequired()
                    .HasColumnName("formaDePagamento")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.CodigoAluguelNavigation)
                    .WithMany(p => p.Pagamento)
                    .HasForeignKey(d => d.CodigoAluguel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tbPagamento_tbAluguel1");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.CodigoPessoa)
                    .HasName("PRIMARY");

                entity.ToTable("pessoa");

                entity.HasIndex(e => e.CodigoPessoa)
                    .HasName("codigo_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.CodigoTipoPessoa)
                    .HasName("fk_tbPessoa_tbTipoPessoa1_idx");

                entity.Property(e => e.CodigoPessoa).HasColumnName("codigoPessoa");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasColumnName("bairro")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("cep")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasColumnName("cidade")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoTipoPessoa).HasColumnName("codigoTipoPessoa");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnName("dataNascimento");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoUf)
                    .IsRequired()
                    .HasColumnName("estadoUF")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDoEndereco).HasColumnName("numeroDoEndereco");

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasColumnName("rg")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasColumnName("rua")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnName("sexo")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'masculino/feminino'");

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnName("telefone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoTipoPessoa)
                    .IsRequired()
                    .HasColumnName("TipoPessoa")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pessoaaluguel>(entity =>
            {
                entity.HasKey(e => new { e.CodigoPessoa, e.CodigoAluguel })
                    .HasName("PRIMARY");

                entity.ToTable("pessoaaluguel");

                entity.HasIndex(e => e.CodigoAluguel)
                    .HasName("fk_tbPessoa_has_tb_aluguel_tb_aluguel1_idx");

                entity.HasIndex(e => e.CodigoPessoa)
                    .HasName("fk_tbPessoa_has_tb_aluguel_tbPessoa1_idx");

                entity.Property(e => e.CodigoPessoa).HasColumnName("codigoPessoa");

                entity.Property(e => e.CodigoAluguel).HasColumnName("codigoAluguel");

                entity.HasOne(d => d.CodigoAluguelNavigation)
                    .WithMany(p => p.Pessoaaluguel)
                    .HasForeignKey(d => d.CodigoAluguel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tbPessoa_has_tb_aluguel_tb_aluguel1");

                entity.HasOne(d => d.CodigoPessoaNavigation)
                    .WithMany(p => p.Pessoaaluguel)
                    .HasForeignKey(d => d.CodigoPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tbPessoa_has_tb_aluguel_tbPessoa1");
            });

        /*    modelBuilder.Entity<Statusimovel>(entity =>
            {
                entity.HasKey(e => e.CodigoStatusImovel)
                    .HasName("PRIMARY");

                entity.ToTable("statusimovel");

                entity.Property(e => e.CodigoStatusImovel).HasColumnName("codigoStatusImovel");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });*/


            modelBuilder.Entity<Statuspagamento>(entity =>
            {
                entity.HasKey(e => e.CodigoStatusPagamento)
                    .HasName("PRIMARY");

                entity.ToTable("statuspagamento");

                entity.Property(e => e.CodigoStatusPagamento).HasColumnName("codigoStatusPagamento");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
