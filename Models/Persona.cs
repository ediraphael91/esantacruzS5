using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esantacruzS5.Models
{
    [Table("persona")]
    public class Persona
    { 
    
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
            
    [MaxLength(25), Unique]
    public string Nombre { get; set; }
    }
}

