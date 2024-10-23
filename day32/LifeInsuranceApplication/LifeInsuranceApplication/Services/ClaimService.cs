using AutoMapper;
using LifeInsuranceApplication.Interface;
using LifeInsuranceApplication.Models;
using LifeInsuranceApplication.Models.DTO;

namespace LifeInsuranceApplication.Services
{
    public class ClaimService : IClaimService
    {
        private readonly IRepository<int, Claim> _repository;
        private readonly string _uploadFolder;
        private IMapper _mapper;

        public ClaimService(IRepository<int, Claim> repository, string uploadFolder,IMapper mapper)
        {
            _repository = repository;
            _mapper=mapper;
            _uploadFolder = uploadFolder;
            Directory.CreateDirectory(_uploadFolder);
        }
        public async Task<IEnumerable<ClaimDTO>> GetClaims()
        {
            try
            {
                var claims = await _repository.GetAll();
                var claimsDTO= _mapper.Map<IEnumerable<ClaimDTO>>(claims);
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
                Claim claim = await MappingClaim(claimDTO);
                var newClaim = await _repository.Create(claim);
                return newClaim;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not create claim: {ex.Message}");
            }

        }

        public async Task<Claim> MappingClaim(ClaimDTO claimDTO)
        {
            Claim claim = new Claim
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
    }
}