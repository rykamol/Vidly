using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MemberShipType> MemberShipTypes { get; set; }
        public Customer Customer { get; set; }

        public NewCustomerViewModel()
        {
            MemberShipTypes = new List<MemberShipType>();
        }
    }
}