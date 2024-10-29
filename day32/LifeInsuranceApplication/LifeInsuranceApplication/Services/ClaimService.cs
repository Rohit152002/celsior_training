using AutoMapper;
using LifeInsuranceApplication.Interface;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;

namespace LifeInsuranceApplication.Services
{
    public class ClaimService : IClaimService
    {
        private readonly IRepository<int, CustomerClaim> _repository;
        private readonly string _uploadFolder;
        private IMapper _mapper;

        public ClaimService(IRepository<int, CustomerClaim> repository, string uploadFolder,IMapper mapper)
        {
            _repository = repository;
            _mapper=mapper;
            _uploadFolder = uploadFolder;
            Directory.CreateDirectory(_uploadFolder);
        }
        public async Task<IEnumerable<ClaimResponseDTO>> GetClaims()
        {
            try
            {
                var claims = await _repository.GetAll();
                 var claimsDTO= _mapper.Map<IEnumerable<ClaimResponseDTO>>(claims);
                return claimsDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> RequestNewClaim(ClaimDTO claimDTO)
        {
            try
            {
                CustomerClaim claim = await MappingClaim(claimDTO);
                var newClaim = await _repository.Create(claim);
                return newClaim;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not create claim: {ex.Message}");
            }

        }

        public async Task<CustomerClaim> MappingClaim(ClaimDTO claimDTO)
        {
            CustomerClaim claim = new CustomerClaim
            {
                PolicyId = claimDTO.PolicyId,
                ClaimTypeId = claimDTO.ClaimTypeId,
                DateOfIncident = claimDTO.DateOfIncident,
                ClaimantName = claimDTO.ClaimantName,
                ClaimantPhone = claimDTO.ClaimantPhone,
                ClaimantEmail = claimDTO.ClaimantEmail,
                SettleForm = await SaveFileAsync(claimDTO.SettleForm),
                DeathCertificateForm = await SaveFileAsync(claimDTO.DeathCertificateForm),
                PolicyCertificateForm = await SaveFileAsync(claimDTO.PolicyCertificateForm),
                Photo = await SaveFileAsync(claimDTO.Photo),
                AddressProof = await SaveFileAsync(claimDTO.AddressProof),
                CancelCheck = await SaveFileAsync(claimDTO.CancelCheck),
                Other = await SaveFileAsync(claimDTO.Other),
            };
            return claim;
        }
        public async Task<string> SaveFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return null;
            }

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_uploadFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return uniqueFileName;
        }

        public async Task<CustomerClaim> UpdateClaimStatus(UpdateStatusDTO updateStatusDTO)
        {
            CustomerClaim claim = await _repository.Get(updateStatusDTO.ClaimId);
            claim.status = updateStatusDTO.Status;
            CustomerClaim updateClaim= await _repository.Update(updateStatusDTO.ClaimId,claim);
            //ClaimDTO claimDTO= _mapper.Map<ClaimDTO>(claim);
            return updateClaim;
        }

       
    }
}