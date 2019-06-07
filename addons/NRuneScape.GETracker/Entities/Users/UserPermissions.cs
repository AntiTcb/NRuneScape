using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public struct UserPermissions
    {
        [ModelProperty("moderator")]
        public bool IsModerator { get; set; }
        [ModelProperty("staff")]
        public bool IsStaff { get; set; }
        [ModelProperty("admin")]
        public bool IsAdmin { get; set; }
        [ModelProperty("dsiabled")]
        public bool IsDisabled { get; set; }
    }
}
