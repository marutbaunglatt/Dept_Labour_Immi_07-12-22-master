using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dept_Labour_Immi.Models
{
    public class Agency
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Agency Name")]
        public string AgencyName { get; set; }
        public string? Address { get; set; }
        [Required]
        [DisplayName("License No")]
        public string? RegNo { get; set; }

        [DisplayName("License Start Date")]
        [DataType(DataType.Date)]
        public DateTime? LicenseStartDate { get; set; }

        [DisplayName("Valid Date")]
        [DataType(DataType.Date)]
        public DateTime? LicenseEndDate { get; set; }
        public string? Phone { get; set; }

        [DisplayName("Managing Director")]
        public string? BOD_Name { get; set; }

        [NotMapped]
        public string? BODName { get; set; }
        //public int? BODID { get; set; }
        //public BOD bOD { get; set; }
        //public int? ThaiCompanyID { get; set; }
        //public ThaiCompany thaiCompany { get; set; }
        public List<Blacklist> blacklists { get; set; }

        public List<BOD> bODs { get; set; }
        public List<ThaiCompany> thaiCompanies { get; set; }
        public List<Operation_1> Operation_1s { get; set; }

        //public int? BlacklistID { get; set; }
        //public Blacklist blacklist { get; set; }
        [NotMapped]
        public List<BOD> BODList { get; set; }
        [NotMapped]
        public List<Penalty> PenaltyList { get; set; }
        [NotMapped]
        public BOD BOD { get; set; }
        [NotMapped]
        public Penalty Penalty { get; set; }

    }
}
