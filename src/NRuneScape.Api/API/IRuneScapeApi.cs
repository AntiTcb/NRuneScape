using System;
using RestEase;

namespace NRuneScape.API
{
    /// <summary>
    /// The most abstract Api representation for RuneScape.
    /// </summary>
    internal interface IRuneScapeApi : IDisposable
    {
        [Header("User-Agent")]
        string UserAgent { get; set; }
    }
}
