//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KCBilgisayar.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Urunler_Tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urunler_Tbl()
        {
            this.Satıs_Tbl = new HashSet<Satıs_Tbl>();
        }
    
        public int UrunID { get; set; }
        public string UrunAd { get; set; }
        public Nullable<int> UrunKategori { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
    
        public virtual Kategori_Tbl Kategori_Tbl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satıs_Tbl> Satıs_Tbl { get; set; }
    }
}