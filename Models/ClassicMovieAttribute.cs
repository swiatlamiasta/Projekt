using System.ComponentModel.DataAnnotations;
using Projekt.Models;

public class ClassicMovieAttribute : ValidationAttribute
{
    private int _year;

    public ClassicMovieAttribute(int Year)
    {
        _year = Year;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        Movie movie = (Movie)validationContext.ObjectInstance;

        if (movie.Genre == "Classic" && movie.ReleaseDate.Year > _year)
        {
            return new ValidationResult("Classic movies can't be made after 1960!");
        }

        return ValidationResult.Success;
    }
}