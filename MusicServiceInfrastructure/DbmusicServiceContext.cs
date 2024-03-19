using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MusicServiceDomain.Model;

public partial class DbmusicServiceContext : DbContext
{
    public DbmusicServiceContext()
    {
    }

    public DbmusicServiceContext(DbContextOptions<DbmusicServiceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Lyric> Lyrics { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    public virtual DbSet<SongsAlbum> SongsAlbums { get; set; }

    public virtual DbSet<SongsArtist> SongsArtists { get; set; }

    public virtual DbSet<SongsGenre> SongsGenres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-VHUPPU2\\SQLEXPRESS; Database=DBMusicService; Trusted_Connection=True; TrustServerCertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.Property(e => e.Country)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Image).HasColumnType("image");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Lyric>(entity =>
        {
            entity.HasIndex(e => e.SongId, "UK_SongID").IsUnique();

            entity.Property(e => e.Text)
                .HasMaxLength(4000)
                .IsUnicode(false);

            entity.HasOne(d => d.Song).WithOne(p => p.Lyric)
                .HasForeignKey<Lyric>(d => d.SongId)
                .HasConstraintName("FK_LYRICS_SONGS");
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.Property(e => e.LyricsId).HasColumnName("LyricsID");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SongsAlbum>(entity =>
        {
            entity.Property(e => e.AlbumId).HasColumnName("AlbumID");
            entity.Property(e => e.SongId).HasColumnName("SongID");

            entity.HasOne(d => d.Album).WithMany(p => p.SongsAlbums)
                .HasForeignKey(d => d.AlbumId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SONGSALBUMS_ALBUMS");

            entity.HasOne(d => d.Song).WithMany(p => p.SongsAlbums)
                .HasForeignKey(d => d.SongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SONGSALBUMS_SONGS");
        });

        modelBuilder.Entity<SongsArtist>(entity =>
        {
            entity.Property(e => e.ArtistId).HasColumnName("ArtistID");
            entity.Property(e => e.SongId).HasColumnName("SongID");

            entity.HasOne(d => d.Artist).WithMany(p => p.SongsArtists)
                .HasForeignKey(d => d.ArtistId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SONGSARTISTS_ARTISTS");

            entity.HasOne(d => d.Song).WithMany(p => p.SongsArtists)
                .HasForeignKey(d => d.SongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SONGSARTISTS_SONGS");
        });

        modelBuilder.Entity<SongsGenre>(entity =>
        {
            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.SongId).HasColumnName("SongID");

            entity.HasOne(d => d.Genre).WithMany(p => p.SongsGenres)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SONGSGENRES_GENRES");

            entity.HasOne(d => d.Song).WithMany(p => p.SongsGenres)
                .HasForeignKey(d => d.SongId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SONGSGENRES_SONGS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
