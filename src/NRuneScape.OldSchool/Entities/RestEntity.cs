namespace NRuneScape.OldSchool
{                 
    public abstract class RestEntity
    {
        /// <summary>
        /// An instance of the client that retrieved this entity.
        /// </summary>
        public OSClient RuneScape { get; }

        internal RestEntity(OSClient client)
        {
            RuneScape = client;
        }
    }
}