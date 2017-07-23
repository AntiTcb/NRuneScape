using System;
using RestEase;

namespace NRuneScape.API
{                 
    internal interface IRuneScapeApi : IDisposable
    {
        [Header("User-Agent")]
        string UserAgent { get; set; }
    }
}
