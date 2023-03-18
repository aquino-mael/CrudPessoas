namespace Domain.Entities
{
    public class PessoaEntity : BaseEntity
    {
        public PessoaEntity(string name, string email, string cpf)
        {
            this.Name = name;
            this.Email = email;
            this.Cpf = cpf;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }
    }
}
