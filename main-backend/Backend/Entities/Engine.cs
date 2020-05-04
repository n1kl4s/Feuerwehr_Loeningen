using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities
{
    [Table("engine")]
    public partial class Engine
    {
        #region Colums

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("engineid")]
        [DataType("integer")]
        public int EngineId { get; set; }

        [Column("enginenumber")]
        [DataType("character varying(7)")]
        [MaxLength(7)]
        public string EngineNumber { get; set; }

        [Column("engineps")]
        [DataType("integer")]
        public int? EnginePs { get; set; }

        [Column("enginecapacityccm")]
        [DataType("integer")]
        public int? EngineCapacityCcm { get; set; }

        [Column("enginecylinder")]
        [DataType("integer")]
        public int? EngineCylinder { get; set; }

        [Required]
        [Column("engineconstructionyear")]
        [DataType("integer")]
        public int EngineConstructionYear { get; set; }

        [Required]
        [Column("enginelength")]
        [DataType("integer")]
        public int EngineLength { get; set; }

        [Required]
        [Column("enginewidth")]
        [DataType("integer")]
        public int EngineWidth { get; set; }

        [Required]
        [Column("enginehight")]
        [DataType("integer")]
        public int EngineHight { get; set; }

        [Column("enginebody")]
        [DataType("character varying(50)")]
        [MaxLength(50)]
        public string EngineBody { get; set; }

        [Column("enginechassis")]
        [DataType("character varying(50)")]
        [MaxLength(50)]
        public string EngineChassis { get; set; }

        [Required]
        [Column("engineisdeprecated")]
        [DataType("boolean")]
        [DefaultValue(false)]
        public bool EngineIsDeprecated { get; set; }

        [Required]
        [Column("enginelicenseplate")]
        [DataType("character varying(12)")]
        [MaxLength(12)]
        public string EngineLicensePlate { get; set; }


        [Column("engineradiocall")]
        [DataType("character varying(50)")]
        [MaxLength(50)]
        public string EngineRadioCall { get; set; }


        #endregion

        #region ForeignKey Colums

        [Required]
        [Column("classificationid")]
        [DataType("integer")]
        [ForeignKey(nameof(Engine.Classification))]
        public int ClassificationId { get; set; }

        [Required]
        [Column("crewid")]
        [DataType("integer")]
        [ForeignKey(nameof(Engine.Crew))]
        public int CrewId { get; set; }

        #endregion

        #region None DB Properties

        public Crew Crew { get; set; }

        public Classification Classification { get; set; }

        #endregion
    }
}
