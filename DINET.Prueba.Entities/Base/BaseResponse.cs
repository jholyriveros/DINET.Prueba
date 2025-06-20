namespace DINET.Prueba.Entities.Base
{
    /// <summary>
    /// Base Response Backend
    /// </summary>
    public class BaseResponse
    {

        /// <summary>
        /// Success
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Error Message
        /// </summary>
        public string? ErrorMessage { get; set; } = default!;
    }

    /// <summary>
    /// BaseResponse<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseResponse<T>
    {
        /// <summary>
        /// Success
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Error Message
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Data
        /// </summary>
        public T? Data { get; set; }
    }
}