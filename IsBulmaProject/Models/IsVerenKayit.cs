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
    
    public partial class IsVerenKayit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IsVerenKayit()
        {
            this.Ilan = new HashSet<Ilan>();
        }
    
        public int isVerenId { get; set; }
        public int isVerenTelNo { get; set; }
        public string isVerenMail { get; set; }
        public string isVerenSirketAdi { get; set; }
        public string isVerenIl { get; set; }
        public string isVerenIlce { get; set; }
        public string isVerenVergiNo { get; set; }
        public string isVerenPassword { get; set; }
        public int RoleID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ilan> Ilan { get; set; }
        public virtual Roles Roles { get; set; }
    }
}
