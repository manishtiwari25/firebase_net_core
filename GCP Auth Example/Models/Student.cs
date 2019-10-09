using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCP_Auth_Example.Models
{
    [FirestoreData]
    public class Student : FirestoreEntity
    {
        [FirestoreProperty("name")]
        public string Name { get; set; }

        [FirestoreProperty("class")]
        public string Class { get; set; }
    }
}
