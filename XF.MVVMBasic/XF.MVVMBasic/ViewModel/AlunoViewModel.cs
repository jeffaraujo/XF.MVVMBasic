using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.MVVMBasic.Model;
using XF.MVVMBasic.View;

namespace XF.MVVMBasic.ViewModel
{
    public class AlunoViewModel : INotifyPropertyChanged
    {
        

        #region Propriedades
        private string _RM;

        public string RM
        {
            get { return _RM; }
            set
            {
                _RM = value;
                OnPropertyChanged();
            }
        }

        private string _Nome;

        public string Nome
        {
            get { return _Nome; }
            set
            {
                _Nome = value;
                OnPropertyChanged();
            }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                OnPropertyChanged();
            }
        }

        private Aluno alunoSelecionado;

        public Aluno AlunoSelecionado
        {
            get { return alunoSelecionado; }
            set { alunoSelecionado = value;


                EditarCommand.Execute(alunoSelecionado); //Chamando o evento enquanto seleciona um aluno
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Aluno> lstAlunos { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Command NovoAlunoCommand { get; private set; }
        public Command CancelarCommand { get; private set; }
        public Command SalvarCommand { get; private set; }
        public Command<Aluno> ExcluirCommand { get; private set; }
        public Command<Aluno> EditarCommand { get; private set; }

        Page page;
        public AlunoViewModel(Page page)
        {
            lstAlunos = new ObservableCollection<Aluno>();

            NovoAlunoCommand = new Command(NovoAluno);
            CancelarCommand = new Command(Cancelar);
            SalvarCommand = new Command(Salvar);
            ExcluirCommand = new Command<Aluno>(Excluir);
            EditarCommand = new Command<Aluno>(Editar);
            this.page = page; //Para usar os recursos tais como DisplayAlert
        }

        private async void Editar(Aluno aluno)
        {
            //await page.DisplayAlert("Teste", $"Editando o aluno {aluno.Nome} ...", "OK");
            
            App.Current.MainPage = new NavigationPage(new NovoAlunoView(aluno));
        }

        private async void NovoAluno()
        {
            App.Current.MainPage = new NavigationPage(new NovoAlunoView(new Aluno()));
            
        }
        
        private async void Cancelar()
        {
            App.Current.MainPage = new NavigationPage(new AlunoView());
        }

        private async void Salvar()
        {
            var qtd = lstAlunos.Count;
            var flag = false;
            for (int i = 0; i < qtd; i++)
            {
                if (RM == lstAlunos[i].RM && Nome == lstAlunos[i].Nome && Email == lstAlunos[i].Email)
                {
                    flag = true;
                    lstAlunos[i].RM = RM;
                    lstAlunos[i].Nome = Nome;
                    lstAlunos[i].Email = Email;
                }
            }

            if (!flag)
            {
                lstAlunos.Add(new Aluno() { Email = Email, Nome = Nome, RM = RM });
            }
            await page.DisplayAlert("Cadastro Alunos", "Aluno Salvo com êxito!", "OK");
        }

        private async void Excluir(Aluno aluno)
        {
            lstAlunos.Remove(aluno);
            await page.DisplayAlert("Cadastro Alunos", "Aluno Excluído com êxito!", "OK");
        }

        public AlunoViewModel(Aluno aluno)
        {
            this._RM = aluno.RM;
            this._Nome = aluno.Nome;
            this._Email = aluno.Email;
        }

        public void GetAlunos()
        {
            lstAlunos.Add(new Aluno() { Email = "seila@seila.com", Nome = "Não sei", RM = "777777" });
            lstAlunos.Add(new Aluno() { Email = "naosei@seila.com", Nome = "Não sei não", RM = "888888" });
            lstAlunos.Add(new Aluno() { Email = "poxavida@seila.com", Nome = "Poxa Vida", RM = "999999" });
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
