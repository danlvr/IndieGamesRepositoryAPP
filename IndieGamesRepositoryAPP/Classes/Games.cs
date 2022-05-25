using System;
using IndieGamesRepositoryAPP.Enum;

namespace IndieGamesRepositoryAPP.Classes
{
    public class Games : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Summary { get; set; }
        private int ReleaseData { get; set; }
        private bool IsDeleted { get; set; }

        public Games(int id, Genre genre, string title, string summary, int releaseDate)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Summary = summary;
            this.ReleaseData = releaseDate;
            this.IsDeleted = false;
        }

        public override string ToString()
        {
            var output = "";
            output += "Genre: " + this.Genre + Environment.NewLine;
            output += "Title: " + this.Title + Environment.NewLine;
            output += "Summary: " + this.Summary + Environment.NewLine;
            output += "Release year: " + this.ReleaseData + Environment.NewLine;
            output += "Deleted: " + this.IsDeleted;

            return output;
        }

        public string ReturnTitle()
        {
            return this.Title;
        }

        public int ReturnId()
        {
            return this.Id;
        }

        public bool ReturnIsDeleted()
        {
            return this.IsDeleted;
        }

        public void Delete()
        {
            this.IsDeleted = true;
        }
    }
}