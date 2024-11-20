using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class MusicasDAL
    {
        private readonly ScreenSoundContext context;

        public MusicasDAL(ScreenSoundContext context)
        {
            this.context = context;
        }

        //Lista de Musicas
        public IEnumerable<Musica> Listar()
        {
            return context.Musicas.ToList();
        }

        //Adicionar Musicas
        public void Adicionar(Musica musica)
        {
            context.Musicas.Add(musica);
            context.SaveChanges();
        }

        //Deletar Musicas
        public void Deletar(Musica musica)
        {
            context.Musicas.Remove(musica);
            context.SaveChanges();
        }

        //Modificar Musica
        public void Modificar(Musica musica)
        {
            context.Musicas.Update(musica);
            context.SaveChanges();
        }

        public Musica? RecuperarPeloNome(string nome)
        {
            return context.Musicas.FirstOrDefault(musica => musica.Nome.Equals(nome));
        }
    }
}
