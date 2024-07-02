using esantacruzS5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SQLite.SQLite3;
using SQLite;

namespace esantacruzS5.Utils
{
    public class PersonRepository
    {
        string dbPath;
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }

        private void Init() 
        {
            if (conn is not null)
                return;
            conn = new(dbPath);
            conn.CreateTable<Persona>();  
        }
        public PersonRepository(string path) 
        {
            dbPath = path;
        }

        public void AddNewPerson(string nombre) 
        {
            int result = 0;
            try 
            {
                Init();
                
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("El nombre es requerido");

                Persona person = new() { Nombre = nombre };
                result = conn.Insert(person);

                StatusMessage = string.Format("Dato añadido correctamente", result, nombre);

            } catch (Exception EX) {
                StatusMessage = string.Format("Error al instertar", EX.Message);
            }

        }

        public List<Persona> GetAllPeople() 
        {
            try {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception EX) 
            { 
                StatusMessage = string.Format("Error al mostrar", EX.Message);
            }

            return new List<Persona>();
        
        }

        public void DeletePerson(int id)
        {
            try
            {
                Init();
                var person = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (person != null)
                {
                    conn.Delete(person);
                    StatusMessage = "Persona eliminada correctamente";
                }
                else
                {
                    StatusMessage = "Persona no encontrada";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error al eliminar: {ex.Message}";
            }
        }

        public void UpdatePerson(Persona person)
        {
            try
            {
                Init();
                var existingPerson = conn.Table<Persona>().FirstOrDefault(p => p.Id == person.Id);
                if (existingPerson != null)
                {
                    existingPerson.Nombre = person.Nombre;
                    conn.Update(existingPerson);
                    StatusMessage = "Persona modificada correctamente";
                }
                else
                {
                    StatusMessage = "Persona no encontrada";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error al modificar: {ex.Message}";
            }
        }

    }
}
