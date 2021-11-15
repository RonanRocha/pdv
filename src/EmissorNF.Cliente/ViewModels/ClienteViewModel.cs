

namespace EmissorNF.Cliente.ViewModels
{
    public class ClienteViewModel : UsuarioViewModel 
    {

        private string _cnpj;

        public string Cnpj
        {
            get => _cnpj;
            set => SetProperty(ref _cnpj, value);
        }

    }
}
