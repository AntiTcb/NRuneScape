using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NRuneScape
{
    public interface IRuneScapeClient : IDisposable
    {
        Task<IHiscoreCharacter> GetCharacterAsync(string accountName, Game game, GameMode mode);

        Task<IItem> GetItemAsync(int itemId, Game game);
        IAsyncEnumerable<IItem> GetItemsAsync(string name, Game game, int? limit = null);
   }
}