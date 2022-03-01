namespace BalanceApp.Application.Dtos.Balance
{
    public record BalanceDto
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
