using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;

namespace FarmaciaSimilares01.Data
{
    public class GitService // Servicio para obtener el historial de commits de Git
    {
        public List<GitCommitModel> ObtenerHistorialCommits() // Método para obtener la lista de commits del repositorio Git
        {
            var listaCommits = new List<GitCommitModel>(); // Lista para almacenar los commits

            string rutaBase = AppDomain.CurrentDomain.BaseDirectory; // Obtener la ruta base de la aplicación

            string rutaProyecto = Directory.GetParent(rutaBase)?.Parent?.Parent?.Parent?.FullName ?? ""; // Intentar subir 4 niveles para llegar a la raíz del proyecto

            try
            {
                using (var repo = new Repository(rutaProyecto))
                {
                    foreach (Commit c in repo.Commits)
                    {
                        listaCommits.Add(new GitCommitModel
                        {
                            IdCorto = c.Id.Sha.Substring(0, 7),
                            Mensaje = c.MessageShort,
                            Autor = c.Author.Name,
                            Fecha = c.Author.When.DateTime
                        });
                    }
                }
            }
            catch (Exception ex)
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

    public class GitCommitModel
    {
        public string IdCorto { get; set; } = "";
        public string Mensaje { get; set; } = "";
        public string Autor { get; set; } = "";
        public DateTime Fecha { get; set; }
    }
}
