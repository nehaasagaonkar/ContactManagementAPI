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
        public Task<UserConfirmation> AddContact(User userModel)
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
                return Task.FromResult(new UserConfirmation { StatusCode = HttpStatusCode.InternalServerError, Message = ex.Message });

            }
            return Task.FromResult(new UserConfirmation { StatusCode = HttpStatusCode.OK, Message = "Contact inserted successfully" });
        }
        public Task<UserConfirmation> ListContacts()
        {
            UserConfirmation userConfirmation = new UserConfirmation();   
            try
            {
                using (var contactInformationEntities = new ContactInformationEntities())
                {
                    userConfirmation.ContactsList = new List<User>();
                    Mapper.CreateMap<ContactDetail, User>();
                    var result =contactInformationEntities.ContactDetails.Where(x => x.Status == true);
                    foreach (var temp in result)
                    {
                        User user = Mapper.Map<ContactDetail, User>(temp);
                        userConfirmation.ContactsList.Add(user);
                    }
                    userConfirmation.StatusCode = HttpStatusCode.OK;
                    userConfirmation.Message = "Contact retrived Successfully";
                    return Task.FromResult(userConfirmation);
                }
            }
            catch (Exception ex)
            {
                LogException.Write("Exception occured in Business solution", ex);
                return Task.FromResult(new UserConfirmation { StatusCode = HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }
        public Task<UserConfirmation> EditContact(User user)
        {
            try
            {
                using (var contactInformationEntities = new ContactInformationEntities())
                {
                    var contact = contactInformationEntities.ContactDetails.SingleOrDefault(b => b.Id == user.Id);
                    if (contact != null)
                    {
                        contact.FirstName = user.FirstName;
                        contact.LastName = user.LastName;
                        contact.Email = user.Email;
                        contact.Phone = user.Phone;
                        contact.Status = true;
                        contact.Updated_date = DateTime.Now;
                        contactInformationEntities.SaveChanges();
                        return Task.FromResult(new UserConfirmation { StatusCode = HttpStatusCode.OK, Message = "Updated successfully" });
                    }
                    else
                    {
                        return Task.FromResult(new UserConfirmation { StatusCode = HttpStatusCode.NotFound, Message = "Record not found" });
                    }
                }
            }
            catch (Exception ex)
            {
                LogException.Write("Exception occured in Business solution", ex);
                return Task.FromResult(new UserConfirmation
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                });

            }

        }
        public Task<UserConfirmation> DeleteContact(int id, bool status)
        {
            try
            {
                using (var contactInformationEntities = new ContactInformationEntities())
                {
                    var contact = contactInformationEntities.ContactDetails.SingleOrDefault(b => b.Id == id);
                    if (contact != null)
                    {
                        contact.Status = status;
                        contact.Updated_date = DateTime.Now;
                        contactInformationEntities.SaveChanges();
                        return Task.FromResult(new UserConfirmation { StatusCode = HttpStatusCode.OK, Message = "Contact updated successfully" });
                    }
                    else
                    {
                        return Task.FromResult(new UserConfirmation { StatusCode = HttpStatusCode.NotFound, Message = "Contact not found" });
                    }
                }
            }
            catch (Exception ex)
            {
                LogException.Write("Exception occured in Business solution", ex);
                return Task.FromResult(new UserConfirmation
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Message = ex.Message
                });

            }
        }
    }
}
