using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using LibraryObjects;
using Database;

/// <summary>
/// Summary description for PersonService
/// </summary>
[WebService]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class PersonService : System.Web.Services.WebService
{
    HumanDBHelper humanDBHelper = new HumanDBHelper();

    public PersonService()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public bool AddNewPerson(int id, string name, string surname, string password, DateTime birthDate, string phoneNumber, string email)
    {
        Person person = new Person(id, name, surname, password, birthDate, phoneNumber, email);
        return humanDBHelper.AddNewPerson(person);
    }

    [WebMethod]
    public bool DeletePerson(Person person)
    {
        return humanDBHelper.DeletePerson(person);
    }

    [WebMethod]
    public bool EditPerson(Person oldPerson, Person newPerson)
    {
        return humanDBHelper.EditPerson(oldPerson, newPerson);
    }

    [WebMethod]
    public Person GetPersonByID(int id)
    {
        return humanDBHelper.GetPersonByID(id);
    }

    [WebMethod]
    public Person GetPersonByNameSurnamePassword(string name, string surname, string password)
    {
        return humanDBHelper.GetPersonByNameSurnamePassword(name, surname, password);
    }

    [WebMethod]
    public List<Person> GetAllPersons()
    {
        return humanDBHelper.GetAllPersons();
    }

    [WebMethod]
    public int getNextId()
    {
        return humanDBHelper.getNextId();
    }

    public static Person returnPerson(int id, string name, string surname, string password, DateTime birthDate, string phoneNumber, string email)
    {
        return new Person(id, name, surname, password, birthDate, phoneNumber, email);
    }
}
