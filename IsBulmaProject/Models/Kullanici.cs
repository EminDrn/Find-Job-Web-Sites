//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IsBulmaProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            this.Basvuru = new HashSet<Basvuru>();
            this.favori = new HashSet<favori>();
        }
    
        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string kullaniciSoyadi { get; set; }
        public string sehir { get; set; }
        public string Mail { get; set; }
        public string telefon { get; set; }
        public System.DateTime dogumTarihi { get; set; }
        public string sifre { get; set; }
        public int RoleID { get; set; }
        public string kullaniciOzet { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Basvuru> Basvuru { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<favori> favori { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
