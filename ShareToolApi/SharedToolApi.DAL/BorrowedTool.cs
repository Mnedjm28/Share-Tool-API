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
    
    public partial class BorrowedTool
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ToolId { get; set; }
        public bool Approved { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
        public virtual Tool Tool { get; set; }
    }
}
