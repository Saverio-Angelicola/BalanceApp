namespace BalanceApp.API.Dtos.Balance
{
    public class BalanceDto
    {
        public string Name { get; set; }
        public string MacAdress { get; set; }

        public BalanceDto(string name, string macAdress)
        {
            Name = name;
            MacAdress = macAdress;
        }

        public BalanceDto()
        {
            Name = string.Empty;
            MacAdress = string.Empty;
        }
    }
}
