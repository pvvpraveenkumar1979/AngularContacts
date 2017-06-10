using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyAngularContactsBDLayers;
using System.Diagnostics;

namespace AngularContactsBDTestProject
{
    [TestClass]
    public class ContactsDataLayerTestClass
    {
        public const string ContactFilePath = "";
        [TestMethod]
        public void AddNewContactTest()
        {
            DTOContact newContact = new DTOContact();
            newContact.City = "Hyderabad";
            newContact.ContactId = 1;
            newContact.CreatedOn = DateTime.Now;
            newContact.EMailId = "ganapathy@kailasam.com";
            newContact.FirstName = "MahaGanapathy";
            newContact.HNo = "2-4-525";
            newContact.ImagePath = "Mahaganapthy.jpg";
            newContact.LastName = "The Lord";
            newContact.ModifiedOn = DateTime.Now;
            newContact.PIN = "500035";
            newContact.RoadNo = "Road No 3";
            newContact.State = "Telangana";
            newContact.Street = "New Nagole Colony";
            bool successfullyCreated = MyAngularContactsDataLayer.AddNewContact(newContact);
            Debug.Equals(successfullyCreated, true);
        }
        [TestMethod]
        public void UpdateContactTest()
        {
            DTOContact newContact = new DTOContact();
            newContact.City = "Hyderabad";
            newContact.ContactId = 1;
            newContact.EMailId = "ganapathy@kailasam.com";
            newContact.FirstName = "MahaGanapathy";
            newContact.HNo = "2-4-525";
            newContact.ImagePath = "Mahaganapthy.jpg";
            newContact.LastName = "The Lord";
            newContact.ModifiedOn = DateTime.Now;
            newContact.PIN = "500035";
            newContact.RoadNo = "Road No 3";
            newContact.State = "Telangana";
            newContact.Street = "New Nagole Colony";
            bool successfullyCreated = MyAngularContactsDataLayer.UpdateContact(newContact);
            Debug.Equals(successfullyCreated, true);
        }
        [TestMethod]
        public void DeleteContactTest()
        {
            DTOContact newContact = new DTOContact();
            newContact.ContactId = 1;
            bool successfullyDeleted = MyAngularContactsDataLayer.DeleteContact(newContact);
            Debug.Assert(successfullyDeleted == true, "successfully deleted");
        }

        [TestMethod]
        public void ListContactsTest()
        {
            DTOContacts Contacts = MyAngularContactsDataLayer.ListContacts();
            Debug.Assert(Contacts.Contacts.Count == Contacts.ContactsCount, "Retrieval of contacts is successful"); 

        }
    }
}
