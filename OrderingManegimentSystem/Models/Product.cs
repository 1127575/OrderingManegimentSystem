//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはテンプレートから生成されました。
//
//     このファイルを手動で変更すると、アプリケーションで予期しない動作が発生する可能性があります。
//     このファイルに対する手動の変更は、コードが再生成されると上書きされます。
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrderingManegimentSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.CartDetails = new HashSet<CartDetail>();
        }
    
        public string Category { get; set; }
        public int ItemNo { get; set; }
        public string PhotoUrl { get; set; }
        public string ItemName { get; set; }
        public decimal UnitPrice { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Overview { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public decimal Stock { get; set; }
        public Nullable<System.DateTime> ReceiptDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartDetail> CartDetails { get; set; }
    }
}