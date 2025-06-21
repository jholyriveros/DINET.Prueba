namespace DINET.Prueba.Models.Response.Base
{
    /// <summary>
    /// Base Response
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
    /// Base Response Generic
    /// </summary>
    public class BaseResponseGeneric<T> : BaseResponse
    {
        /// <summary>
        /// Data
        /// </summary>
        public T? Data { get; set; }
    }
}