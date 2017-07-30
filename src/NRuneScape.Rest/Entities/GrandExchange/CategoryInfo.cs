using System.Diagnostics;
using Model = NRuneScape.API.CategoryInfoModel;

namespace NRuneScape.Rest
{
    [DebuggerDisplay("{ToString}")]
    public class CategoryInfo : RestEntity<RuneScapeRestClient>
    {
        public char Letter { get; set; }
        public int ItemCount { get; set; }

        internal CategoryInfo(RuneScapeRestClient client, Game game, Model model) 
            : base(client, game)
        {
            Letter = model.Letter[0];
            ItemCount = model.ItemCount;
        }

        internal static CategoryInfo Create(RuneScapeRestClient client, Game game, Model model)
            => new CategoryInfo(client, game, model);

        public override string ToString() => $"{Letter} C: {ItemCount}";
    }
}
