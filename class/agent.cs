public class agent
{
    public int id { get; set; }
    public string codeName { get; set; }
    public string realName { get; set; }
    public string location { get; set; }
    public string status { get; set; }
    public int missionsCompleted { get; set; }

    public agent(string codeName, string realName, string location, string status)
    {
        this.codeName = codeName;
        this.realName = realName;
        this.location = location;
        this.status = status;
    }
}