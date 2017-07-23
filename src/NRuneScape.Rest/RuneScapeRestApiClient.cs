using System;
using System.Threading.Tasks;
using RestEase;

namespace NRuneScape.API
{
    internal class RuneScapeRestApiClient : BaseRestApiClient
    {                               
        public RuneScapeRestApiClient() : base(new RestDeserializer()) { }   
        public RuneScapeRestApiClient(IResponseDeserializer responseDeserializer)
            : base(responseDeserializer) { }

        internal override Task<IHiscoreCharacterModel> GetCharacterAsync(string accountName, string route, string gameMode) 
            => throw new NotSupportedException();
    }
}
                                                                                       