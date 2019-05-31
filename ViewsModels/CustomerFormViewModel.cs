using Mosh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mosh.ViewsModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

        public String Title
        {
            get
            {
                return Customer.Id != 0 ? "Edit Customer" : "New Customer";
            }
        }
    }
}