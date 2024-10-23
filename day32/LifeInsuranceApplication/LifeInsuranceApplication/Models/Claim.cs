using System;
using System.ComponentModel.DataAnnotations;
namespace LifeInsuranceApplication.Models
{
    public class Claim{
        
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public Policy? Policy{ get; set; }   
        public int ClaimTypeId { get; set; }
        public ClaimType? ClaimType{ get; set; }

        public DateTime DateOfIncident {get; set; }
        public string ClaimantName { get; set; }=string.Empty;
        
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 15 characters.")]
        public string ClaimantPhone { get; set; }=string.Empty;
        public string ClaimantEmail { get; set; }=string.Empty;
        public string? SettleForm {get;set;}=string.Empty;
        public string? DeathCertificateForm {get; set;}=string.Empty;
        public string? PolicyCertificateForm {get; set;}=string.Empty;
        public string? Photo {get; set;}=string.Empty;
        public string? AddressProof {get; set;}=string.Empty;
        public string? CancelCheck  {get; set;}=string.Empty;
        public string? Other  {get; set;}=string.Empty;

    }
}