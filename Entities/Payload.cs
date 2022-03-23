namespace WingsCredentialsApproval
{
    public class Payload
    {
        public string name {get; init;}
        public string description {get; init;}
        public string email {get; init;}
        public string [] apis {get; init;}
        public string personRole {get; init;}
        public string personId {get; init;}

        public Payload(string name, string description, string email, string [] apis, string personRole, string personId)
        {
            this.name = name;
            this.description = description;
            this.email = email;
            this.apis = apis;
            this.personRole = personRole;
            this.personId = personId;
        }

    }
}