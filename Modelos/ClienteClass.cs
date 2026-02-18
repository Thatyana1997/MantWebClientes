using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MantWebClientes.Modelos
{
    public class ClienteClass
    {
        public int Id { get; set; }              
        public string Nombre { get; set; }       
        public string Email { get; set; }       
        public string Telefono { get; set; }     
        public DateTime FechaCreacion { get; set; }     
        public string UsuarioCreacion { get; set; }   
        public DateTime? FechaModificacion { get; set; }     
        public string UsuarioModificacion { get; set; }      
         
        public ClienteClass() { }
         
        public ClienteClass(int id, string nombre, string email, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Telefono = telefono;
        }
    }
}