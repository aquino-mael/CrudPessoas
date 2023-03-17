using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pessoa : BaseEntity
    {
        public Pessoa(string name, string email, string cpf)
        {
            this.Name = name;
            this.Email = email;
            this.cpf = cpf;

        }

        public string Name { get; set; }

        public string Email { get; set; }

        public string cpf { get; set; }
    }
}
