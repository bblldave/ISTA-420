//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaseballApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Schedule
    {
        public string Team1 { get; set; }
        public string Team2 { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public long gameId { get; set; }
    
        public virtual Team Team { get; set; }
        public virtual Team Team3 { get; set; }
    }
}
