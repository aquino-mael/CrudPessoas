namespace Domain.Entities
{
    public class PessoaEntity : BaseEntity
    {
        public PessoaEntity(string name, string email, string documentNumber)
        {
            this.Name = name;
            this.Email = email;
            this.DocumentNumber = documentNumber;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public string DocumentNumber { get; set; }
    }
}
