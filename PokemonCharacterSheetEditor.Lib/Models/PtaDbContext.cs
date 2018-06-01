using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PokemonCharacterSheetEditor.Lib.Models
{
    public partial class PtaDbContext : DbContext
    {
        public PtaDbContext()
        {
        }

        public PtaDbContext(DbContextOptions<PtaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ability> Ability { get; set; }
        public virtual DbSet<Capability> Capability { get; set; }
        public virtual DbSet<ContestType> ContestType { get; set; }
        public virtual DbSet<Frequency> Frequency { get; set; }
        public virtual DbSet<Keyword> Keyword { get; set; }
        public virtual DbSet<Move> Move { get; set; }
        public virtual DbSet<MoveListType> MoveListType { get; set; }
        public virtual DbSet<MoveStat> MoveStat { get; set; }
        public virtual DbSet<Pokemon> Pokemon { get; set; }
        public virtual DbSet<PokemonAbility> PokemonAbility { get; set; }
        public virtual DbSet<PokemonCapabilities> PokemonCapabilities { get; set; }
        public virtual DbSet<PokemonMove> PokemonMove { get; set; }
        public virtual DbSet<TechnicalMedicine> TechnicalMedicine { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<TypeEffective> TypeEffective { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=PtaDb.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ability>(entity =>
            {
                entity.HasIndex(e => e.AbilityId)
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.AbilityId).HasDefaultValueSql("- 1");

                entity.Property(e => e.Activation)
                    .IsRequired()
                    .HasColumnType("VARCHAR")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Effect)
                    .IsRequired()
                    .HasColumnType("VARCHAR")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Limit)
                    .IsRequired()
                    .HasColumnType("VARCHAR")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("VARCHAR")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.Keyword)
                    .WithMany(p => p.Ability)
                    .HasForeignKey(d => d.KeywordId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Capability>(entity =>
            {
                entity.HasIndex(e => e.CapabilityId)
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.CapabilityId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<ContestType>(entity =>
            {
                entity.HasIndex(e => e.ContestTypeId)
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.ContestTypeId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Frequency>(entity =>
            {
                entity.HasIndex(e => e.FrequencyId)
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.FrequencyId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.HasIndex(e => e.KeywordId)
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.KeywordId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Move>(entity =>
            {
                entity.HasIndex(e => e.MoveId)
                    .IsUnique();

                entity.Property(e => e.MoveId).ValueGeneratedNever();

                entity.Property(e => e.AccuracyCheck)
                    .IsRequired()
                    .HasColumnType("VARCHAR")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ContestKeyword)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.ContestRoll)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Effect)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.EffectScript)
                    .IsRequired()
                    .HasColumnType("VARCHAR")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MoveRange)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Roll)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Target)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.HasOne(d => d.ContestType)
                    .WithMany(p => p.Move)
                    .HasForeignKey(d => d.ContestTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Frequency)
                    .WithMany(p => p.Move)
                    .HasForeignKey(d => d.FrequencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.MoveStat)
                    .WithMany(p => p.Move)
                    .HasForeignKey(d => d.MoveStatId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Move)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MoveListType>(entity =>
            {
                entity.HasIndex(e => e.MoveListTypeId)
                    .IsUnique();

                entity.Property(e => e.MoveListTypeId).ValueGeneratedNever();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<MoveStat>(entity =>
            {
                entity.HasIndex(e => e.MoveStatId)
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.MoveStatId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.HasIndex(e => e.PokemonId)
                    .IsUnique();

                entity.Property(e => e.PokemonId).ValueGeneratedNever();

                entity.Property(e => e.Diets)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.FemaleChance)
                    .IsRequired()
                    .HasColumnType("NUMERIC");

                entity.Property(e => e.Habitats)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Height)
                    .IsRequired()
                    .HasColumnType("NUMERIC");

                entity.Property(e => e.Hp).HasColumnName("HP");

                entity.Property(e => e.Intelligence).HasDefaultValueSql("1");

                entity.Property(e => e.LevelUpScript)
                    .IsRequired()
                    .HasColumnType("VARCHAR")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.MaleChance)
                    .IsRequired()
                    .HasColumnType("NUMERIC");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Overland).HasDefaultValueSql("1");

                entity.Property(e => e.Power).HasDefaultValueSql("1");

                entity.Property(e => e.Sky).HasDefaultValueSql("1");

                entity.Property(e => e.Surface).HasDefaultValueSql("1");

                entity.Property(e => e.Underwater).HasDefaultValueSql("1");

                entity.Property(e => e.Weight)
                    .IsRequired()
                    .HasColumnType("NUMERIC");

                entity.HasOne(d => d.TypeOne)
                    .WithMany(p => p.PokemonTypeOne)
                    .HasForeignKey(d => d.TypeOneId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.TypeTwo)
                    .WithMany(p => p.PokemonTypeTwo)
                    .HasForeignKey(d => d.TypeTwoId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PokemonAbility>(entity =>
            {
                entity.Property(e => e.PokemonAbilityId).ValueGeneratedNever();

                entity.Property(e => e.IsHighAbility)
                    .IsRequired()
                    .HasColumnType("BOOLEAN")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Ability)
                    .WithMany(p => p.PokemonAbility)
                    .HasForeignKey(d => d.AbilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Pokemon)
                    .WithMany(p => p.PokemonAbility)
                    .HasForeignKey(d => d.PokemonId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PokemonCapabilities>(entity =>
            {
                entity.HasKey(e => e.PokemonCapabilityId);

                entity.Property(e => e.PokemonCapabilityId).ValueGeneratedNever();

                entity.HasOne(d => d.Capability)
                    .WithMany(p => p.PokemonCapabilities)
                    .HasForeignKey(d => d.CapabilityId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Pokemon)
                    .WithMany(p => p.PokemonCapabilities)
                    .HasForeignKey(d => d.PokemonId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PokemonMove>(entity =>
            {
                entity.Property(e => e.PokemonMoveId).ValueGeneratedNever();

                entity.HasOne(d => d.Move)
                    .WithMany(p => p.PokemonMove)
                    .HasForeignKey(d => d.MoveId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.MoveListTypeNavigation)
                    .WithMany(p => p.PokemonMove)
                    .HasForeignKey(d => d.MoveListType)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Pokemon)
                    .WithMany(p => p.PokemonMove)
                    .HasForeignKey(d => d.PokemonId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<TechnicalMedicine>(entity =>
            {
                entity.HasKey(e => e.TmRowId);

                entity.HasIndex(e => e.MoveId)
                    .IsUnique();

                entity.HasIndex(e => e.PtaId)
                    .IsUnique();

                entity.HasIndex(e => e.TmRowId)
                    .IsUnique();

                entity.Property(e => e.TmRowId).ValueGeneratedNever();

                entity.Property(e => e.PtaId)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.HasOne(d => d.Move)
                    .WithOne(p => p.TechnicalMedicine)
                    .HasForeignKey<TechnicalMedicine>(d => d.MoveId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.HasIndex(e => e.TypeId)
                    .IsUnique();

                entity.Property(e => e.TypeId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<TypeEffective>(entity =>
            {
                entity.HasIndex(e => e.TypeEffectiveId)
                    .IsUnique();

                entity.Property(e => e.TypeEffectiveId).ValueGeneratedNever();

                entity.HasOne(d => d.Attacking)
                    .WithMany(p => p.TypeEffectiveAttacking)
                    .HasForeignKey(d => d.AttackingId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Defending)
                    .WithMany(p => p.TypeEffectiveDefending)
                    .HasForeignKey(d => d.DefendingId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
