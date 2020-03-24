using Practice.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Domain.Model
{
    public class ItemSupplier : EntityDescription
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public ItemSupplierDTO ToDTO()
        {
            return new ItemSupplierDTO
            {
                SupplierId = SupplierId,
                SupplierName = Supplier.Name,
                SupplierAddress = Supplier.Address,
                SupplierPhone = Supplier.PhoneNo
            };
        }
    }
    public class ItemSupplierDTO
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierPhone { get; set; }
    }
}

