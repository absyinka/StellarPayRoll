using StellarPayRoll.Core.Attributes;
using StellarPayRoll.Core.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace StellarPayRoll.Core.Models.Dtos.ResponseModels
{
    public class CreateEmployeeRequestModel
    {
        [Required(ErrorMessage = "Employee number is required"), RegularExpression(@"^[A-Z]{3,3}[0-9]{3}$")]
        public string EmployeeNo { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EnumRequired]
        public Gender Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public DateTime DateJoined { get; set; }

        [Required]
        public string Phone { get; set; }

        [GuidRequired]
        public Guid DesignationId { get; set; }

        [GuidRequired]
        public Guid PositionId { get; set; }

        [GuidRequired]
        public Guid DepartmentId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string NationalIdentificationNo { get; set; }

        [EnumRequired]
        public PaymentMethod PaymentMethod { get; set; }

        [EnumRequired]
        public UnionMember UnionMember { get; set; }

    }
}
