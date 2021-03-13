using System.ComponentModel.DataAnnotations;

namespace Restrike.GitHubIntegration.Api.Exceptions
{
    public class FieldErrorModel
    {
        [Required]
        public string Message { get; set; }

        [Required]
        public int ErrorNumber { get; set; } = 0;
    }
}
