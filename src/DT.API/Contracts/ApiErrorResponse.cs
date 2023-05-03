using Domain.Primitives;

namespace DT.API.Contracts
{
    public class ApiErrorResponse
    {

        /// <summary>
        /// Initializes the new instance of the <see cref="ApiErrorResponse"/> class
        /// </summary>
        /// <param name="errors">Error list</param>
        public ApiErrorResponse(IReadOnlyCollection<Error> errors) => Errors = errors;


        /// <summary>
        /// Get the errors.
        /// </summary>
        public IReadOnlyCollection<Error> Errors { get; }
    }
}
