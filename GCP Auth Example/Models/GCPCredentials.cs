namespace GCP_Auth_Example.Models
{
    using Newtonsoft.Json;

    [JsonObject]
    public class GCPCredentials
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("private_key")]
        public string PrivateKey { get; set; }

        [JsonProperty("private_key_id")]
        public string PrivateKeyId { get; set; }

        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        [JsonProperty("client_email")]
        public string ClientEmail { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("auth_uri")]
        public string AuthURI { get; set; }

        [JsonProperty("token_uri")]
        public string TokenURI { get; set; }

        [JsonProperty("auth_provider_x509_cert_url")]
        public string AuthProviderCertURL { get; set; }

        [JsonProperty("client_x509_cert_url")]
        public string ClientCertURL { get; set; }
    }
}
