//---------------------------------------------------------------------
// SFMovieLocations.Models.SFMovieLocationsModels.cs
//--------------------------------------------------------------------

namespace SFMovieLocations.Models
{
    #region using directives
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    #endregion

    /// <summary>
    /// SFMovieLocations Database Context Class
    /// </summary>
    public class SFMovieLocationsContext : DbContext
    {
        public SFMovieLocationsContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<SFMovieLocation> SFMovieLocations { get; set; }
    }

    /// <summary>
    /// SFMovieLocation Class
    /// </summary>
    [Table("SFMovieLocations")]
    public class SFMovieLocation
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string LocationName { get; set; }
        public decimal LocationLat { get; set; }
        public decimal LocationLng { get; set; }
        public string Director { get; set; }
        public string Actor1 { get; set; }
        public string Actor2 { get; set; }
        public string Actor3 { get; set; }
        public string Writer { get; set; }
        public string ProductionCompany { get; set; }
        public string Distributor { get; set; }
        public string FunFacts { get; set; }
    }
}