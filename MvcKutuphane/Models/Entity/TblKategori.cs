//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcKutuphane.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblKategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblKategori()
        {
            this.TblKitap = new HashSet<TblKitap>();
        }
    
        public int id { get; set; }
        public string ad { get; set; }
        public Nullable<bool> durum { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblKitap> TblKitap { get; set; }
    }
}
