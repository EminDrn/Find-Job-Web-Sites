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
    
    public partial class Ilan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ilan()
        {
            this.Basvuru = new HashSet<Basvuru>();
            this.favori = new HashSet<favori>();
        }
    
        public int ilanId { get; set; }
        public int isVerenId { get; set; }
        public string ilanAdi { get; set; }
        public string ilanSehir { get; set; }
        public string ilanCalismaBicimi { get; set; }
        public string ilanDepertman { get; set; }
        public Nullable<int> ilanBasvuruSayisi { get; set; }
        public int isKategoriId { get; set; }
        public Nullable<System.DateTime> IlanEklenmeTarihi { get; set; }
        public string ilanCalismaZamani { get; set; }
        public Nullable<int> PozisyonSeviyeId { get; set; }
        public Nullable<int> ilanTanitimId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Basvuru> Basvuru { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<favori> favori { get; set; }
        public virtual IlanTanitim IlanTanitim { get; set; }
        public virtual IsKategori IsKategori { get; set; }
        public virtual IsVerenKayit IsVerenKayit { get; set; }
        public virtual IlanPozisyonSeviye IlanPozisyonSeviye { get; set; }
    }
}