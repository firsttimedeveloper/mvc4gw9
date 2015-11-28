using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc4gw9.Models
{
    [Table("Groups", Schema = "dbo")]
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentGroupId { get; set; }
    }
    
    [Table("Nomenclature", Schema="dbo")]
    public class Nomenclature
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }

    [Table("FeaturesSets", Schema = "dbo")]
    public class FeaturesSet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

    [Table("Characteristics", Schema = "dbo")]    
    public class Characteristic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set;}
    }

    [Table("Stores", Schema = "dbo")]        
    public class Store
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }

    [Table("FeaturesOfNomenclatures", Schema = "dbo")]
    public class FeaturesOfNomenclature
    {
        [Key]
        public int Id { get; set; }
        //[ForeignKey("NomenclatureVaiant")]
        public int FeaturesSetId { get; set; }
        //[ForeignKey("Characteristic")]
        public int CharacteristicId { get; set; }
        public string Value { get; set; }

        //public NomenclatureVariant NomenclatureVariant { get; set; }
        //public Characteristic Characteristic { get; set; }
    }


    [Table("NomenclatureInStores", Schema = "dbo")]                
    public class NomenclatureInStore
    {
        [Key]
        public int Id { get; set; }
        //[ForeignKey("Store")]
        public int StoreId { get; set; }
        //[ForeignKey("Nomenclature")]
        public int NomenclatureId { get; set; }
        //[ForeignKey("NomenclatureVariant")]
        public int FeaturesSet { get; set; }
        public int Amount { get; set; }
        public int ReservarionAmount { get; set; }

        //public Store Store { get; set; }
        //public Nomenclature Nomenclature { get; set; }
        //public NomenclatureVariant NomenclatureaVariant { get; set; }
    }

    [Table("NomenclatureViews", Schema = "dbo")]
    public class NomenclatureView
    {
        [Key]
        public int Id { get; set; }
        public int NomenclatureId { get; set; }
        public int FeaturesSetId { get; set; }
        public string Image { get; set; }
    }
} 



