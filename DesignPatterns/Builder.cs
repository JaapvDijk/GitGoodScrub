//Creating complex objects by seperating the construction logic into methods

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class PersonBuilder
{
    private readonly Person person;

    public PersonBuilder()
    {
        person = new Person();
    }

    public PersonBuilder WithFirstName(string firstName)
    {
        person.FirstName = firstName;
        return this;
    }

    public PersonBuilder WithLastName(string lastName)
    {
        person.LastName = lastName;
        return this;
    }
    
    public Person Build()
    {
        return person;
    }
}