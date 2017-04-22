using System;
using System.Threading.Tasks;

namespace NRuneScape
{
    public interface IRSClient : IDisposable
    {
        Task<ICharacter> GetCharacterAsync(string name);
    }
}