using System;
using Voltaic;
using Voltaic.Serialization;

namespace NRuneScape.GETracker
{
    public class User
    {
        // TODO: Guid?
        [ModelProperty("userId")]
        public string UserId { get; set; }
        [ModelProperty("name")]
        public string Username { get; set; }
        [ModelProperty("email")]
        public Optional<string> Email { get; set; }
        [ModelProperty("totalProfit")]
        public Optional<int> TotalProfit { get; set; }
        [ModelProperty("registeredOn")]
        public Optional<DateTimeOffset> RegistrationDate { get; set; }
        [ModelProperty("emailVerified")]
        public Optional<bool> IsVerified { get; set; }
        [ModelProperty("profilePic")]
        public string ProfilePictureUrl { get; set; }
        [ModelProperty("apiKey")]
        public Optional<string> ApiKey { get; set; }
        [ModelProperty("url")]
        public Optional<string> Url { get; set; }
        [ModelProperty("premium")]
        public Optional<PremiumFlags> Premium { get; set; }
        [ModelProperty("permissions")]
        public Optional<UserPermissions> Permissions { get; set; }
        [ModelProperty("flagShared")]
        public Optional<bool> IsFlagShared { get; set; }
        [ModelProperty("editUrl")]
        public Optional<string> EditUrl { get; set; }
    }
}
