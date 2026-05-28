using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;

namespace FarmaciaSimilares01.Data
{
    public class GitService // Servicio para interactuar con el repositorio Git y obtener información de los commits
    {
        public List<GitCommitModel> ObtenerHistorialCommits() // Método para obtener una lista de commits del repositorio Git
        {
            var listaCommits = new List<GitCommitModel>(); // Lista para almacenar los commits obtenidos

            string rutaBase = AppDomain.CurrentDomain.BaseDirectory; // Obtener la ruta base de la aplicación

            string rutaProyecto = Directory.GetParent(rutaBase)?.Parent?.Parent?.Parent?.FullName ?? "";  // Construir la ruta al proyecto (ajustar según la estructura de carpetas)

            try // Intentar abrir el repositorio Git y leer los commits
            {
                using (var repo = new Repository(rutaProyecto)) // Abrir el repositorio Git ubicado en la ruta del proyecto
                {
                    foreach (Commit c in repo.Commits) // Iterar sobre cada commit en el repositorio
                    {
                        listaCommits.Add(new GitCommitModel // Agregar un nuevo modelo de commit a la lista con información relevante del commit
                        {
                            IdCorto = c.Id.Sha.Substring(0, 7),
                            Mensaje = c.MessageShort,
                            Autor = c.Author.Name,
                            Fecha = c.Author.When.DateTime
                        });
                    }
                }
            }
            catch (Exception ex) // Capturar cualquier excepción que ocurra al intentar leer el repositorio Git y agregar un commit de error a la lista
            {
                listaCommits.Add(new GitCommitModel
                {
                    IdCorto = "ERROR",
                    Mensaje = $"Error al leer Git: {ex.Message}",
                    Autor = "Sistema",
                    Fecha = DateTime.Now
                });
            }

            return listaCommits;
        }
    }

    public class GitCommitModel // Modelo para representar un commit de Git con propiedades relevantes
    {
        public string IdCorto { get; set; } = "";
        public string Mensaje { get; set; } = "";
        public string Autor { get; set; } = "";
        public DateTime Fecha { get; set; }
    }
}
