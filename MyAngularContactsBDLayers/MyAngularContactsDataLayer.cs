using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;


namespace MyAngularContactsBDLayers
{
    public class MyAngularContactsDataLayer
    {
        #region "Public Methods"
        public static bool AddNewContact(DTOContact Contact)
        {
            try
            {
                DTOContacts availableContacts = GetContacts();
                availableContacts.Contacts.Add(Contact);
                availableContacts.ContactsCount = availableContacts.Contacts.Count;
                SaveContacts(availableContacts.Contacts);
                return true;
            }
            catch(Exception ex)
            {
                // Throw exception 

                return false;
            }
        }
        public static bool UpdateContact(DTOContact Contact)
        {
            try
            {
                DTOContacts availableContacts = GetContacts();
                DTOContact ContactToUpdate = availableContacts.Contacts.FirstOrDefault<DTOContact>(ct => ct.ContactId == Contact.ContactId);
                ContactToUpdate.EMailId = Contact.EMailId;
                ContactToUpdate.FirstName = Contact.FirstName;
                ContactToUpdate.HNo = Contact.HNo;
                ContactToUpdate.ImagePath = Contact.ImagePath;
                ContactToUpdate.LastName = Contact.LastName;
                ContactToUpdate.PIN = Contact.PIN;
                ContactToUpdate.RoadNo = Contact.RoadNo;
                ContactToUpdate.State = Contact.State;
                ContactToUpdate.Street = Contact.Street;
                ContactToUpdate.ModifiedOn = DateTime.Now;
                SaveContacts(availableContacts.Contacts);
                return true;
            }
            catch
            {
                // Throw exception 

                return false;
            }
        }
        public static bool DeleteContact(DTOContact Contact)
        {
            try
            {
                DTOContacts availableContacts = GetContacts();
                DTOContact ContactToDelete = availableContacts.Contacts.FirstOrDefault<DTOContact>(ct => ct.ContactId == Contact.ContactId);
                if (ContactToDelete == null)
                {

                    return false;
                }
                else
                {
                    availableContacts.Contacts.Remove(ContactToDelete);
                    availableContacts.ContactsCount = availableContacts.Contacts.Count;
                    SaveContacts(availableContacts.Contacts);
                    return true;
                }
            }
            catch
            {
                // Throw exception 

                return false;
            }
        }
        public static DTOContacts ListContacts()
        {
            return GetContacts();
        }

        #endregion

        #region "HelperAndPrivate Methods"
        private static void SaveContacts(List<DTOContact> Contacts)
        {
            string json = JsonConvert.SerializeObject(Contacts, Formatting.Indented);
            FileStream fs = new FileStream(@"C:\Contacts.pk", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(json);
            sw.Close();
            fs.Close();
        }
        private static DTOContacts GetContacts()
        {
            FileStream fs = new FileStream(@"C:\Contacts.pk", FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string jsonContacts = sr.ReadToEnd();
            List<DTOContact> contactList = JsonConvert.DeserializeObject<List<DTOContact>>(jsonContacts);
            sr.Close();
            fs.Close();

            DTOContacts contacts = new DTOContacts();
            if (contactList == null)
            {
                contacts.Contacts = new List<DTOContact>();
                contacts.ContactsCount = 0;
            }
            else
            {
                contacts.Contacts = contactList;
                contacts.ContactsCount = contactList.Count;
            }
            return contacts;
        }
        #endregion
    }
}
