using System.Diagnostics;
using NRuneScape.Rest;
using ItemModel = NRuneScape.API.Item;

namespace NRuneScape.OldSchool
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class OSItem : RSItem
    {  
        internal OSItem(OldSchoolRestClient client, ItemModel model) : base(client, Game.OldSchool, model)
        {   
            Update(model);
        }  
        internal static OSItem Create(OldSchoolRestClient client, ItemModel model)
        {
            return new OSItem(client, model);
        } 
            

        private string DebuggerDisplay => $"({Name} | {Id})";
    }
}
