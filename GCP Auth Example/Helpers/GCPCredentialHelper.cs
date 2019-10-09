namespace GCP_Auth_Example.Helpers
{
    using GCP_Auth_Example.Models;
    using Microsoft.Azure.KeyVault;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class GCPCredentialHelper
    {
        public async static Task<string> GetGCPCredentialJson(IConfiguration _configuration, KeyVaultClient _vaultClient, string KeyvaultDNS)
        {
            var credential = new GCPCredentials();
            _configuration.GetSection("GCP").Bind(credential);
            credential.PrivateKeyId = (await _vaultClient.GetSecretAsync(KeyvaultDNS, _configuration["KeyVault:FirebasePrivateKeyIdKey"])).Value;
            credential.PrivateKey = Regex.Unescape((await _vaultClient.GetSecretAsync(KeyvaultDNS, _configuration["KeyVault:FirebasePrivateKey"])).Value);
            credential.ClientId = _configuration["KeyVault:FirebaseClientIdKey"];
            credential.ClientEmail = _configuration["KeyVault:FirebaseClientEmailKey"];
            credential.ProjectId = _configuration["KeyVault:FirebaseProjectIdKey"];
            credential.ClientCertURL = _configuration["KeyVault:FirebaseClientCertURLKey"];
            return JsonConvert.SerializeObject(credential);
        }
    }
}
