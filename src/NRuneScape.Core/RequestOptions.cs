using System.Threading;

namespace NRuneScape
{
    public class RequestOptions
    {
        public static RequestOptions Default => new RequestOptions();
        
        /// <summary>
        /// Gets or sets the cancellation token to be passsed into this request.
        /// </summary>
        public CancellationToken CancelToken { get; set; } = CancellationToken.None;

        internal static RequestOptions CreateOrClone(RequestOptions options)
        {
            if (options == null)
                return new RequestOptions();
            else
                return options.Clone();
        }         

        public RequestOptions Clone() => MemberwiseClone() as RequestOptions;
    }
}
