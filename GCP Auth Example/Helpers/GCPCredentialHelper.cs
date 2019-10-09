namespace GCP_Auth_Example.Helpers
{
    using GCP_Auth_Example.Models;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System.Text.RegularExpressions;

    public class GCPCredentialHelper
    {
        public static string GetGCPCredentialJson(IConfiguration _configuration, VaultManager _vaultClient)
        {
            var credential = new GCPCredentials();
            _configuration.GetSection("GCP").Bind(credential);
            credential.PrivateKeyId = _vaultClient.GetSecret(_configuration["KeyVault:FirebasePrivateKeyIdKey"]);
            credential.PrivateKey = Regex.Unescape(_vaultClient.GetSecret(_configuration["KeyVault:FirebasePrivateKey"]));
            credential.ClientId = _configuration["KeyVault:FirebaseClientIdKey"];
            credential.ClientEmail = _configuration["KeyVault:FirebaseClientEmailKey"];
            credential.ProjectId = _configuration["KeyVault:FirebaseProjectIdKey"];
            credential.ClientCertURL = _configuration["KeyVault:FirebaseClientCertURLKey"];
            return JsonConvert.SerializeObject(credential);
        }
    }
}
