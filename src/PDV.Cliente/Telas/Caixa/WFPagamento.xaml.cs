using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PDV.Cliente.ViewModels;
using PDV.Dominio.Entidades;
using Serilog;
using System;
using System.Windows;


namespace PDV.Cliente.Telas.Caixa
{
    /// <summary>
    /// Lógica interna para WFPagamento.xaml
    /// </summary>
    public partial class WFPagamento : Window
    {

        private OperacaoVendaViewModel _viewModel;
        private readonly IValidator<Venda> _validator;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _sp;

        public WFPagamento(OperacaoVendaViewModel viewModel, IValidator<Venda> validator, IMapper mapper, IServiceProvider sp)
        {

            InitializeComponent();
            viewModel.FecharJanelaPagamentoAction = new Action(this.Close);
            DataContext = viewModel;
            _viewModel = viewModel;
            this._validator = validator;
            this._sp = sp;
            this._mapper = mapper;
            Loaded += Window_Onload;
            Closed += Window_Onclose;
            winActions.ButtonMaximize.Visibility = Visibility.Collapsed;
            winActions.ButtonMinimize.Click += WindowMinimize;
            winActions.ButtonMaximize.Click += WindowMaximize;
            winActions.ButtonClose.Click += WindowClose;
                       
        }

        private void WindowMinimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        public void WindowClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowMaximize(object sender, RoutedEventArgs e)
        {

            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                return;
            }

            this.WindowState = WindowState.Maximized;
        }

        private void  Window_Onload(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.AbrirJanelaPagamentoCommand.Execute(null);

            }
            catch(Exception ex)
            {
                Log.Error("Erro ao carregar tela de pagamentos");
                Log.Error(ex.Message);
            }
           
        }

        private void Window_Onclose(object sender, EventArgs e)
        {

            try
            {
                _viewModel.FecharJanelaPagamentoCommand.Execute(null);

            }
            catch (Exception ex)
            {
                Log.Error("Erro ao fechar tela de pagamentos");
                Log.Error(ex.Message);
            }
        }

        private void FormasPagamento_OnChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.TrocarFormaPagamentoCommand.Execute(null);

            }catch(Exception ex)
            {
                Log.Error("Error no combobox de formas de pagamento");
                Log.Error(ex.Message);
            }
        }


        private void AdicionarFormaPagamento_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.AdicionarPagamentoCommand.Execute(null);

            }
            catch (Exception ex)
            {
                Log.Error("Erro ao adicionar formas de pagamento [botao]");
                Log.Error(ex.Message);
            }
        }


        private void DataRowGrid_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                VendaFormaPagamentoViewModel vendaProdutoVm = ((FrameworkElement)sender).DataContext as VendaFormaPagamentoViewModel;
                _viewModel.RemovePagamentoCommand.Execute(vendaProdutoVm);
            }
            catch (Exception ex)
            {
                Log.Error("Erro ao remover forma de pagamento da venda [datagrid]");
                Log.Error(ex.Message);
            }
        }


        public void FecharVenda_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var venda = _mapper.Map<Venda>(_viewModel.Venda);

                var validationResult = this._validator.Validate(venda);

                if (!validationResult.IsValid) throw new Exception("Erro de validação de venda");

               _viewModel.FecharVendaCommand.Execute(venda);

                var wfVendaConcluida = _sp.GetRequiredService<WFVendaConcluida>();

                wfVendaConcluida.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.Error("Erro ao fechar venda");
                Log.Error(ex.Message);
            }
        }


    }
}
