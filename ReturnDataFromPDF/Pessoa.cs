using System;
using System.Collections.Generic;
using System.Text;

namespace ReturnDataFromPDF
{
      class Pessoa
    {
        
        public string Nome { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }

        public Pessoa(string nome, string contact, string email)
        {
            Nome = nome;
            Contact = contact;
            Email = email;

            Console.WriteLine("nome " + nome);
            Console.WriteLine("Contacto " + contact);
            Console.WriteLine("email " + email);
        }

        public override string ToString()
        {
            string temp = " ";
            temp += Nome;
            temp += Contact;
            temp += Email;
            return temp;
        }
    }
}
