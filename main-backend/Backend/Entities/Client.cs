using Backend.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities
{
    [Table("client")]
    public partial class Client
    {
        #region Colums

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("clientid")]
        [DataType("integer")]
        public int ClientId { get; set; }

        [Required]
        [Column("clientname")]
        [DataType("character varying(50)")]
        [MaxLength(50)]
        public string ClientName { get; set; }

        [Required]
        [Column("clientprename")]
        [DataType("character varying(50)")]
        [MaxLength(50)]
        public string ClientPrename { get; set; }

        [Required]
        [Column("clientsurname")]
        [DataType("character varying(50)")]
        [MaxLength(50)]
        public string ClientSurname { get; set; }

        [Required]
        [Column("clientpasswordhash")]
        [DataType("character(256)")]
        [MinLength(256)]
        [MaxLength(256)]
        public string ClientPasswordHash { get; set; }

        [Required]
        [Column("clientpasswordsalt")]
        [DataType("character(128)")]
        [MinLength(128)]
        [MaxLength(128)]
        public string ClientPasswordSalt { get; set; }

        [Required]
        [Column("clientrole")]
        [DataType("character varying(100)")]
        public Role ClientRole { get; set; }

        [Column("clientposition")]
        [DataType("character varying(100)")]
        public Position? ClientPosition { get; set; }

        #endregion
    }
}
