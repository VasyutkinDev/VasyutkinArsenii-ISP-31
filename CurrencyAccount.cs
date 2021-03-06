//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bankir_CurrencyExchangeAccounting
{
    using System;
    using System.Collections.Generic;
    
    public partial class CurrencyAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CurrencyAccount()
        {
            this.Operations = new HashSet<Operation>();
        }
    
        public int id { get; set; }
        public System.DateTime OpeningDate { get; set; }
        public int CurrencyID { get; set; }
        public int ClientID { get; set; }
        public string BIK { get; set; }
        public string NumOfAccount { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual TypeOfCurrency TypeOfCurrency { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Operation> Operations { get; set; }
    }
}
