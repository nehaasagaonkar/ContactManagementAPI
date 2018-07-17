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
        UserConfirmation Add(User user);
        UserConfirmation List();
        UserConfirmation Edit(User user);
        UserConfirmation Edit(int id, bool status);
    }
}
