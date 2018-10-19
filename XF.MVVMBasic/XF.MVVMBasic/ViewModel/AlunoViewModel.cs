using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using XF.MVVMBasic.Model;

namespace XF.MVVMBasic.ViewModel
{
    public class AlunoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Propriedades
        public string RM { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        #endregion

        public AlunoViewModel(Aluno aluno)
        {
            this.RM = aluno.RM;
            this.Nome = aluno.Nome;
            this.Email = aluno.Email;
        }

        public ObservableCollection<Aluno> lstAlunos { get; set; }


        public static ObservableCollection<Aluno> GetAlunos()
        {

            return new ObservableCollection<Aluno>()
            {
                new Aluno(){ Email = "seila@seila.com", Nome = "Não sei", RM = "777777" },
                new Aluno(){ Email = "naosei@seila.com", Nome = "Não sei não", RM = "888888" },
                new Aluno(){ Email = "poxavida@seila.com", Nome = "Poxa Vida", RM = "999999" }
            };
        }

        public static Aluno GetAluno()
        {
            var aluno = new Aluno()
            {
                Id = Guid.NewGuid(),
                RM = "331132",
                Nome = "Jeferson Leal",
                Email = "jefao@ufc.com"
            };
            return aluno;
        }

    }
}
