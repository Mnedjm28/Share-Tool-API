//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SharedToolApi.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class Tool
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tool()
        {
            this.BorrowedTools = new HashSet<BorrowedTool>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int QtyReal => Quantity - BorrowedTools?.Where(o => o.Approved).Count() ?? 0;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BorrowedTool> BorrowedTools { get; set; }
    }
}
