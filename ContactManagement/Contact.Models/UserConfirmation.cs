﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Models
{
    public class UserConfirmation
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public List<User> ContactsList { get; set; }
    }
}
