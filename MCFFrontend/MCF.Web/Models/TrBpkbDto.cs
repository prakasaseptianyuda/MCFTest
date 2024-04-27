using System.ComponentModel.DataAnnotations;

namespace MCF.Web.Models
{
    public class TrBpkbDto
    {
        [Required]
        [MaxLength(100)]
        public string AgreementNumber { get; set; } = null!;
        [Required]
		[MaxLength(100)]
		public string? BpkbNo { get; set; }
        [Required]
		[MaxLength(10)]
		public string? BranchId { get; set; }
        [Required]
        public DateTime? BpkbDate { get; set; }
        [Required]
		[MaxLength(100)]
		public string? FakturNo { get; set; }
        [Required]
        public DateTime? FakturDate { get; set; }
        [Required]
		[MaxLength(10)]
		public string LocationId { get; set; } = null!;
        [Required]
		[MaxLength(20)]
		public string? PoliceNo { get; set; }
        [Required]
        public DateTime? BpkbDateIn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
