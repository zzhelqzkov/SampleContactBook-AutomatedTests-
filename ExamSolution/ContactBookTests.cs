using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ContactBookRestFulApi
{
    public class ContactBookTests
    {
        private RestClient client;
        [SetUp]
        public void Setup()
        {
            client = new RestClient("https://samplecontactbook.zhivkozhelqzkov.repl.co/api");
            client.Timeout = 3000;
        }

        //List contacts and assert that the first contact is “Steve Jobs”
        [Test]
        public void List_Contacts_Asser_First_Is_SteveJobs()
        {
            var request = new RestRequest("/contacts", Method.GET);
            var response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(response.ContentType.StartsWith("application/json"));

            var contactList = new JsonDeserializer().Deserialize<List<ContactResponse>>(response);

            Assert.AreEqual("Steve", contactList.First().firstName);
            Assert.AreEqual("Jobs", contactList.First().lastName);

            //foreach (var contact in contactList)
            //{
            //    if (contact.id == 1)
            //    {
            //        Assert.IsTrue(contact.firstName == "Steve");
            //        Assert.IsTrue(contact.lastName == "Jobs");
            //    }
            //}
        }

        // Find contacts by keyword “albert” and assert that the first result holds “Albert Einstein” 
        [Test]
        public void Search_Contact_By_Word_Alber_Positive()
        {
            var request = new RestRequest("/contacts/search/albert", Method.GET);
            var response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var responseContact = new JsonDeserializer().Deserialize<List<ContactResponse>>(response);

            Assert.AreEqual("Albert", responseContact.First().firstName);
            Assert.AreEqual("Einstein", responseContact.First().lastName);
        }

        //	Find contacts by keyword “albert” and assert that the first result holds “Albert Einstein” 
        [Test]
        public void Search_Contact_By_Invailid_Keyword()
        {
            var request = new RestRequest("/contacts/search/missing{randnum}", Method.GET);
            var response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var responseContact = new JsonDeserializer().Deserialize<List<ContactResponse>>(response);
            Assert.IsEmpty(responseContact);
        }

        //Try to create a new contact, holding invalid data, and assert an error is returned 
        [Test]
        public void Create_New_Contact_Invailid_Email()
        {
            var request = new RestRequest("/contacts", Method.POST);
            var body = new
            {
                firstName = "Anton",
                lastName = "Angelov",
                email = "invailid-mail",
                phone = "+359 887 666 666",
                comments = "My Old friend"
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);
            var response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.IsTrue(response.Content.Contains("Invalid email"));
        }

        // Create a new contact, holding valid data, and assert the new contact is added and is properly listed in the contacts list 
        [Test]
        public void Create_New_Contact_Vailid_Data()
        {
            var request = new RestRequest("/contacts", Method.POST);
            var body = new
            {
                firstName = "Anton",
                lastName = "Angelov",
                email = "aangelov@abv.bg",
                phone = "+359 887 666 666",
                comments = "My Old friend"
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);
            var response = client.Execute(request);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            var succesResponse = new JsonDeserializer().Deserialize<CreateContactResponse>(response);
            var expectedContact = new JsonDeserializer().Serialize(body);
            Assert.IsTrue(succesResponse.msg.Contains("Contact added"));

            //Assert.AreEqual(expectedContact, succesResponse.contact);
            Assert.IsTrue(body.firstName == succesResponse.contact.firstName);
            Assert.IsTrue(body.lastName == succesResponse.contact.lastName);
            Assert.IsTrue(body.email == succesResponse.contact.email);
            Assert.IsTrue(body.comments == succesResponse.contact.comments);
        }
    }
}