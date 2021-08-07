using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorNF.Cliente.ViewModels
{
    public class UsuarioViewModel : ObservableObject
    {

        private int _id;
        private string _email;
        private string _nome;
        private string _cpf;
        private string _senha;
        private DateTime _dataCadastro;


        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Nome
        {
            get => _nome;
            set => SetProperty(ref _nome, value);
        }

        public string Cpf
        {
            get => _cpf;
            set => SetProperty(ref _cpf, value);
        }

        public string Senha
        {
            get => _senha;
            set => SetProperty(ref _senha, value);
        }

        public DateTime DataCadastro
        {
            get => _dataCadastro;
            set => SetProperty(ref _dataCadastro, value);
        }


    }
}
