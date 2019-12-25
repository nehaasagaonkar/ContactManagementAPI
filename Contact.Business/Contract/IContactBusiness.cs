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
        Task<UserConfirmation> AddContact(User user);
        Task<UserConfirmation> ListContacts();
        Task<UserConfirmation> EditContact(User user);
        Task<UserConfirmation> DeleteContact(int id, bool status);
    }
}
