using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookRestFulApi
{
    class CreateContactResponse
    {
        public CreateContactResponse() { }

        public string msg { get; set; }
        public ContactResponse contact { get; set; }
    }
}
