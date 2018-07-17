using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contact.Business.Contract;
using Contact.Data.Entity;
using Contact.Models.ApplicationLogger;
using Contact.Models;
using AutoMapper;
using System.Net;

namespace Contact.Business.Implementation
{
    public class ContactBusiness : IContactBusiness
    {
        public UserConfirmation Add(User userModel)
        {
            try
            {
                using (var contactInformationEntities = new ContactInformationEntities())
                {
                    ContactDetail contact = new ContactDetail();
                    contact.FirstName = userModel.FirstName;
                    contact.LastName = userModel.LastName;
                    contact.Email = userModel.Email;
                    contact.Phone = userModel.Phone;
                    contact.Status = true;
                    contact.Created_date = DateTime.Now;
                    contact.Updated_date = null;
                    contactInformationEntities.ContactDetails.Add(contact);
                    contactInformationEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                LogException.Write("Exception occured in Business solution", ex);
                return new UserConfirmation { StatusCode = HttpStatusCode.ServiceUnavailable, Message = ex.Message };

            }
            return new UserConfirmation { StatusCode = HttpStatusCode.OK, Message = "Inserted successfully" };
        }
        public UserConfirmation List()
        {
            UserConfirmation userConfirmation = new UserConfirmation();
            ContactInformationEntities Contact_entity=new ContactInformationEntities();
            try
            {
                userConfirmation.ContactsList = new List<User>();
                Mapper.CreateMap<ContactDetail, User>();
                var result = Contact_entity.ContactDetails.Where(x => x.Status == true).ToList();
                foreach (var temp in result)
                {
                    User user = Mapper.Map<ContactDetail, User>(temp);
                    userConfirmation.ContactsList.Add(user);
                }
                userConfirmation.StatusCode = HttpStatusCode.OK;
                userConfirmation.Message = "Retrived Successfully";
                return userConfirmation;
            }
            catch (Exception ex)
            {
                LogException.Write("Exception occured in Business solution", ex);
                return new UserConfirmation { StatusCode = HttpStatusCode.ServiceUnavailable, Message = ex.Message };
            }
        }
        public UserConfirmation Edit(User user)
        {
            ContactInformationEntities Contact_entity = new ContactInformationEntities();
            try
            {
                var contact = Contact_entity.ContactDetails.SingleOrDefault(b => b.Id == user.Id);
                if (contact != null)
                {
                    contact.FirstName = user.FirstName;
                    contact.LastName = user.LastName;
                    contact.Email = user.Email;
                    contact.Phone = user.Phone;
                    contact.Status = true;
                    contact.Updated_date = DateTime.Now;
                    Contact_entity.SaveChanges();
                    return new UserConfirmation { StatusCode = HttpStatusCode.OK, Message = "Updated successfully" };
                }
                else {
                    return new UserConfirmation { StatusCode = HttpStatusCode.NotFound, Message = "Record not found" };
                }
            }
            catch (Exception ex)
            {
                LogException.Write("Exception occured in Business solution", ex);
                return new UserConfirmation
                {
                    StatusCode = HttpStatusCode.ServiceUnavailable,
                    Message = ex.Message
                };

            }

        }
        public UserConfirmation Edit(int id, bool status)
        {
            ContactInformationEntities Contact_entity = new ContactInformationEntities();
            try
            {
                var contact = Contact_entity.ContactDetails.SingleOrDefault(b => b.Id == id);
                if (contact != null)
                {
                    contact.Status = status;
                    contact.Updated_date = DateTime.Now;
                    Contact_entity.SaveChanges();
                    return new UserConfirmation { StatusCode = HttpStatusCode.OK, Message = "Updated successfully" };
                }
                else {
                    return new UserConfirmation { StatusCode = HttpStatusCode.NotFound, Message = "Record not found" };
                }
            }
            catch (Exception ex)
            {
                LogException.Write("Exception occured in Business solution", ex);
                return new UserConfirmation
                {
                    StatusCode = HttpStatusCode.ServiceUnavailable,
                    Message = ex.Message
                };

            }
        }
    }
}
