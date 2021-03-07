using System;
using System.Collections.Generic;
using System.Text;

namespace ContactBookRestFulApi
{
    class ContactResponse
    {
        public ContactResponse() { }

        public long id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        //public string dateCreated { get; set; }
        public string comments { get; set; }
    }
}
