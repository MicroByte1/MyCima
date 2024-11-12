




using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppContext : IdentityDbContext<AppUser> {


    /*public AppContext(DbContextOptions<AppContext> options) : base(options)
    {
        
    }*/
    public AppContext(DbContextOptions options) : base(options)
    {
    }   

    public DbSet<Actor> Actors { get; set; }

    public DbSet<Producer> Producers { get; set; }

    public DbSet<Movie> Movies { get; set; }

    public DbSet<Actors_Movies> actors_Movies {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producer>()
                    .HasMany(e => e.Movies)
                    .WithOne(e => e.Producer)
                    .HasForeignKey(e => e.ProducerId)
                    .IsRequired(false);


        modelBuilder.Entity<Actors_Movies>()
                    .HasKey(e => new {e.ActorId, e.MovieId});
        modelBuilder.Entity<Actors_Movies>()
                    .HasOne(e => e.Actor)
                    .WithMany(e => e.Actors_Movies)
                    .HasForeignKey(e => e.ActorId);
        modelBuilder.Entity<Actors_Movies>()
                    .HasOne(e => e.Movie)
                    .WithMany(e => e.Actors_Movies)
                    .HasForeignKey(e => e.MovieId);
                    
        
        base.OnModelCreating(modelBuilder);
    }

}