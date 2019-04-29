namespace Be.Vlaanderen.Basisregisters.Api.Exceptions
{
    using System;
    using System.Threading.Tasks;
    using BasicApiProblem;
    using Microsoft.AspNetCore.Http;

    public interface IExceptionHandler
    {
        /// <summary>ExceptionHandler will handle this exception</summary>
        bool Handles(Exception exception);

        /// <summary>Gets the specific type as which the exception is handled</summary>
        Type HandledExceptionType { get; }

        /// <summary>Gets the ApiProblem that will be used as HttpResponse for the given exception</summary>
        /// <returns>BasicApiProblem or a derived type that will be serialized as HttpResponse</returns>
        Task<ProblemDetails> GetApiProblemFor(Exception exception, HttpContext context);
    }
}
