using BlogMaster_Domain.Entities.Abstracts;
using BlogMaster_Domain.Validations;

namespace BlogMaster_Domain.Entities {
    public class Author : Base {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string CPF { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public Author()
        {
            
        }

        public Author(int id, string name, string email, string password, string cpf, DateTime dateOfBirth)
        {
            ValidateProperties(id, name, email, password, cpf, dateOfBirth);

            Id = id;
            Name = name;
            Email = email;
            Password = password;
            CPF = cpf;
            DateOfBirth = dateOfBirth;
        }

        public void ValidateProperties(int id, string name, string email, string password, string cpf, DateTime dateOfBirth) {
            //DomainExceptionValidation.When(id <= 0, "Informe um id válido");
            DomainExceptionValidation.When(string.IsNullOrEmpty(name) || name.Length > 100, "Informe um nome válido");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email) || email.Length > 150 || !email.Contains("@"), "Informe um email válido");
            DomainExceptionValidation.When(string.IsNullOrEmpty(password) || password.Length > 30, "Informe uma senha de até 30 caracteres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(cpf) || cpf.Length > 11, "Informe um CPF válido(Apenas números)");
            DomainExceptionValidation.When(dateOfBirth == DateTime.MinValue || dateOfBirth == DateTime.MaxValue, "Informe uma data de nascimento válida");
        }
    }
}
