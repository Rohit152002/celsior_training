namespace LifeInsuranceApplication.Models.DTO
{
    public class ClaimDTO
    {
                public int PolicyId { get; set; }
        public int ClaimTypeId { get; set; }

        public DateTime DateOfIncident {get; set; }
        public string ClaimantName { get; set; }=string.Empty;
    public string ClaimantPhone { get; set; }=string.Empty;
        public string ClaimantEmail { get; set; }=string.Empty;
        public IFormFile? SettleForm {get;set;}
        public IFormFile? DeathCertificateForm {get; set;}
        public IFormFile? PolicyCertificateForm {get; set;}
        public IFormFile? Photo {get; set;}
        public IFormFile? AddressProof {get; set;}
        public IFormFile? CancelCheck  {get; set;}
        public IFormFile? Other  {get; set;}

    }
}