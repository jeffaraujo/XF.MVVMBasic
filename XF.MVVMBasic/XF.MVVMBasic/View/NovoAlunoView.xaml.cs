﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.MVVMBasic.Model;
using XF.MVVMBasic.ViewModel;

namespace XF.MVVMBasic.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NovoAlunoView : ContentPage
	{
		public NovoAlunoView (Aluno aluno)
		{
            var alunoViewModel = new AlunoViewModel(this);
            alunoViewModel.RM = aluno.RM;
            alunoViewModel.Nome = aluno.Nome;
            alunoViewModel.Email = aluno.Email;

            BindingContext = alunoViewModel;
			InitializeComponent ();
		}
        
    }
}