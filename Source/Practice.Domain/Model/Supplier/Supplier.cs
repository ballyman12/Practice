using Practice.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practice.Domain.Model
{
    public class Supplier : EntityDescription
    {
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public SupplierDTO ToDTO()
        {
            return new SupplierDTO
            {
                SupplierId = Id,
                SupplierName = Name,
                SupplierAddress = Address,
                SupplierPhone = PhoneNo
            };
        }
    }
    public class SupplierDTO
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierPhone { get; set; }
    }
}
