using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities
{
    [Table("crew")]
    public partial class Crew
    {
        #region ctor

        public Crew()
        {
            
        }

        #endregion

        #region Colums

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("crewid")]
        [DataType("integer")]
        public int CrewId { get; set; }

        [Required]
        [Column("crewvalue")]
        [DataType("character varying(20)")]
        [MaxLength(20)]
        public string CrewValue { get; set; }

        #endregion

        #region None DB Properties
        
        [InverseProperty(nameof(Engine.Crew))]
        public ICollection<Engine> Engines { get; set; }

        #endregion
    }
}
