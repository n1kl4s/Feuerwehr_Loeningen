using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Entities
{
    [Table("classification")]
    public partial class Classification
    {
        #region ctor

        public Classification()
        {
            Engines = new HashSet<Engine>();
        }

        #endregion

        #region Colums

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("classificationid")]
        [DataType("integer")]
        public int ClassificationId { get; set; }

        [Required]
        [Column("classificationart")]
        [DataType("character varying(50)")]
        [MaxLength(50)]
        public string ClassificationArt { get; set; }

        [Required]
        [Column("classificationtype")]
        [DataType("character varying(10)")]
        [MaxLength(10)]
        public string ClassificationType { get; set; }

        #endregion

        #region None DB Propertys

        [InverseProperty(nameof(Engine.Classification))]
        public virtual ICollection<Engine> Engines { get; set; }

        #endregion
    }
}
