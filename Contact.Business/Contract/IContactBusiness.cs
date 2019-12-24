using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact.Models;

namespace Contact.Business.Contract
{
    public interface IContactBusiness
    {
        UserConfirmation AddContact(User user);
        UserConfirmation ListContacts();
        UserConfirmation EditContact(User user);
        UserConfirmation EditContact(int id, bool status);
    }
}
