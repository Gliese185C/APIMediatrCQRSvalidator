using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class GetContactDTO
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public long Phone { get; set; }
        public string Address { get; set; }
    }
}
