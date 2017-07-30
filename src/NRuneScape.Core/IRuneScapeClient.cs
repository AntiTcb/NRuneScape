using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NRuneScape
{
    public interface IRuneScapeClient : IDisposable
    {
        Task<IHiscoreCharacter> GetCharacterAsync(string accountName, Game game, GameMode mode, RequestOptions options = null);

        Task<IItem> GetItemAsync(int itemId, Game game, RequestOptions options = null);
        IAsyncEnumerable<IItem> GetItemsAsync(string name, Game game, int? limit = null, RequestOptions options = null);
   }
}