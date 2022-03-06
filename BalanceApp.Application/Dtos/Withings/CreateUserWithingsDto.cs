namespace BalanceApp.Application.Dtos.Withings
{
    public record CreateUserWithingsDto
    {
        public string action { get; set; }
        public string client_id { get; set; }
        public string nonce { get; set; }
        public string signature { get; set; }
        public string mailingpref { get; private set; }
        public string birthdate { get; set; }
        public string measures { get; set; }
        public int gender { get; set; }
        public string preflang { get; set; }
        public string unit_pref { get; set; }
        public string email { get; set; }
        public string timezone { get; set; }
        public string shortname { get; set; }
        public string external_id { get; set; }
        public string mac_addresses { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        public CreateUserWithingsDto(int height, int weight, string client_id, string nonce, string macAddress1, string macAddress2, string mailingpref, string birthdate, int gender, string email, string external_id, string firstname, string lastname)
        {
            this.action = "activate";
            this.client_id = client_id;
            this.nonce = nonce;
            this.signature = "";
            this.mailingpref = mailingpref;
            this.birthdate = birthdate;
            this.measures = "[{'value': " + (height * 100) + ",'unit': -2,'type': 4},{'value': " + (weight * 1000) + ",'unit': -2,'type': 1}]";
            this.gender = gender;
            preflang = "fr_FR";
            unit_pref = "{'weight':1,'height':6,'distance':6,'temperature':11}";
            this.email = email;
            timezone = "Europe/Paris";
            this.external_id = external_id;
            mac_addresses = $"['{macAddress1}','{macAddress2}']";
            this.firstname = firstname;
            this.lastname = lastname;
            shortname = $"{firstname}.{lastname}";
        }
    }
}
