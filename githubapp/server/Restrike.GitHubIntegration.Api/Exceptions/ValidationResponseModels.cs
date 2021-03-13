using Restrike.GitHubIntegration.Api.Exceptions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restrike.GitHubIntegration.Api.Exceptions
{
    public class ValidationResponseModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string TraceId { get; set; }
    }

    public class UnprocessableEntityResponseModel : ValidationResponseModel
    {
        [Required]
        public Dictionary<string, IEnumerable<FieldErrorModel>> Errors { get; set; }
    }

    public class ErrorMessageResponseModel : ValidationResponseModel
    {
        [Required]
        public string ErrorMessage { get; set; }
    }
}
