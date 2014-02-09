//---------------------------------------------------------------------
// SFMovieLocations.Comparers.SFMovieComparer.cs
//--------------------------------------------------------------------

namespace SFMovieLocations.Comparers
{
    #region using directives
    using System.Collections.Generic;
    using SFMovieLocations.Models;
    #endregion 

    /// <summary>
    /// SF Movie Equality Comparer Class
    /// </summary>
    public class SFMovieComparer : IEqualityComparer<SFMovieLocation>
    {
        /// <summary>
        /// SF Movie Comparer
        /// Two movies are equal if their title and release year are equal.
        /// </summary>
        /// <param name="x">SFMovieLocation to compare</param>
        /// <param name="y">SFMovieLocation to compare</param>
        /// <returns>true if SFMovieLocations x and y are equal; false otherwise</returns>
        public bool Equals(SFMovieLocation x, SFMovieLocation y)
        {
            if (x == null || string.IsNullOrWhiteSpace(x.Title) || 
                y == null || string.IsNullOrWhiteSpace(y.Title))
            {
                return false;
            }

            return x.Title.Trim() == y.Title.Trim() && x.ReleaseYear == y.ReleaseYear;
        }

        /// <summary>
        /// Gets hash code for SFMovieLocation.  
        /// Must return identical hash codes for equal objects implemened in Equals() method.
        /// </summary>
        /// <param name="sfMovieLocation">sf movie location object</param>
        /// <returns>sfMovieLocation hashcode</returns>
        public int GetHashCode(SFMovieLocation sfMovieLocation)
        {
            if (sfMovieLocation == null || string.IsNullOrWhiteSpace(sfMovieLocation.Title))
            {
                return 0;
            }

            var movieTitleHash = sfMovieLocation.Title.Trim().GetHashCode();
            var movieReleaseYearHash = sfMovieLocation.ReleaseYear.GetHashCode();

            return movieTitleHash ^ movieReleaseYearHash;
        }
    }
}