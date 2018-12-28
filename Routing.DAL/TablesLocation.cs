namespace Routing.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TablesLocation")]
    public partial class TablesLocation
    {
        [Key]
        public int intLocationId { get; set; }

        [StringLength(500)]
        public string strLocationName { get; set; }

        public int? intMajorLocationID { get; set; }

        public double? floatWageStatements { get; set; }

        public int? intWageStatementsCurrency { get; set; }

        public double? floatAdministrativeExpenses { get; set; }

        public int? intAdministrativeExpensesCurrency { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }
    }
}
