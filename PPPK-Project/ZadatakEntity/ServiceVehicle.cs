//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZadatakEntity
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServiceVehicle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceVehicle()
        {
            this.Stavka = new HashSet<Stavka>();
        }
    
        public int IDServiceVehicle { get; set; }
        public Nullable<int> VehicleID { get; set; }
        public string ChangeTire { get; set; }
        public string ChangeBelt { get; set; }
    
        public virtual Vehicle Vehicle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stavka> Stavka { get; set; }
    }
}
