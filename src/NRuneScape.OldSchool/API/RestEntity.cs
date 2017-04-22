namespace NRuneScape.OldSchool
{
    public abstract class RestEntity
    {
        public OSRSClient RuneScape { get; }

        internal RestEntity(OSRSClient client)
        {
            RuneScape = client;
        }
    }
}