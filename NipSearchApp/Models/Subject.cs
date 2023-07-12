using NipSearchApp.Helpers;
using System.Text.Json.Serialization;

namespace NipSearchApp.Models
{
    public class Subject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string? nip { get; set; }
        public string? statusVat { get; set; }
        public string? regon { get; set; }
        public string? pesel { get; set; }
        public string? krs { get; set; }
        public string? residenceAddress { get; set; }
        public string? workingAddress { get; set; }
        public DateTime? registrationLegalDate { get; set; }
        public DateTime? registrationDenialDate { get; set; }
        public string? registrationDenialBasis { get; set; }
        public DateTime? restorationDate { get; set; }
        public string? restorationBasis { get; set; }
        public DateTime? removalDate { get; set; }
        public string? removalBasis { get; set; }
        public bool? hasVirtualAccounts { get; set; }
        //public List<string> accountNumbers { get; set; }

        public ICollection<Representatives> representatives { get; set; }
        public ICollection<AuthorizedClerks> authorizedClerks { get; set; }
        public ICollection<Partners> partners { get; set; }

        [JsonConverter(typeof(AccountNumbersConverter))]
        public ICollection<AccountNumbers> accountNumbers { get; set; }

        //dlaczego ICollection?
    }
}
