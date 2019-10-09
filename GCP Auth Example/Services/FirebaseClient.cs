namespace GCP_Auth_Example.Services
{
    using GCP_Auth_Example.Models;
    using Google.Apis.Auth.OAuth2;
    using Google.Cloud.Firestore;
    using Google.Cloud.Firestore.V1;
    using Grpc.Auth;
    using Grpc.Core;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class FirebaseClient
    {
        private readonly FirestoreDb _firestore;
        public FirebaseClient(string computeCredsJson, string project)
        {
            var _credential = GoogleCredential.FromJson(computeCredsJson);
            if (_credential.IsCreateScopedRequired)
            {
                _credential = _credential.CreateScoped(FirestoreClient.DefaultScopes);
            }

            Channel channel = new Channel(FirestoreClient.DefaultEndpoint.ToString(), _credential.ToChannelCredentials());
            FirestoreClient client = FirestoreClient.Create(channel);
            _firestore = FirestoreDb.CreateAsync(project, client).GetAwaiter().GetResult();
        }


        public async Task<List<T>> FetchDataFromFireStore<T>(string collectionName) where T: FirestoreEntity
        {
            var returnList = new List<T>();
            CollectionReference reference = _firestore.Collection(collectionName);
            QuerySnapshot querySnapshot = await reference.GetSnapshotAsync();
            foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
            {
                var entity = documentSnapshot.ConvertTo<T>();
                returnList.Add(entity);
            }
            return returnList;
        }
    }
}