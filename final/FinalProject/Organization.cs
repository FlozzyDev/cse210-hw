public class Organization 
{
    private string _name;

    public Organization(string name)
    {
        _name = name;
    }


public string GetOrganizationDetails()
{
    return $"Organization Name: {_name}";
}

}