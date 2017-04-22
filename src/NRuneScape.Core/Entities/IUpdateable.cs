using System.Threading.Tasks;

namespace NRuneScape
{
    public interface IUpdateable
    {
        /// <summary> Updates this object's properties with its current state. </summary>
        Task UpdateAsync();
    }
}