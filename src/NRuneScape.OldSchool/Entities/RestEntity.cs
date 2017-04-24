namespace NRuneScape.OldSchool
{                 
    public abstract class RestEntity
    {
        /// <summary>
        /// An instance of the client that retrieved this entity.
        /// </summary>
        public OSRSClient RuneScape { get; }

        internal RestEntity(OSRSClient client)
        {
            RuneScape = client;
        }
    }
}