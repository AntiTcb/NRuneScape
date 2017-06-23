namespace NRuneScape.Rest
{                 
    public abstract class RestEntity<T> where T : IRuneScapeClient
    {
        /// <summary>
        /// An instance of the client that retrieved this entity.
        /// </summary>
        public T RuneScape { get; }
        public Game GameSource { get; }

        internal RestEntity(T client, Game game)
        {
            RuneScape = client;
            GameSource = game;
        }
                                                  
    }
}