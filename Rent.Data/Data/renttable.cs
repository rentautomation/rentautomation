//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rent.Data.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class renttable
    {
        public int rentnumber { get; set; }
        public Nullable<int> membernumber { get; set; }
        public Nullable<int> vehiclenumber { get; set; }
        public Nullable<System.DateTime> rentdatebegin { get; set; }
        public Nullable<System.DateTime> rentdateend { get; set; }
        public Nullable<int> beginkm { get; set; }
        public Nullable<int> endkm { get; set; }
        public Nullable<double> totalprice { get; set; }
    }
}