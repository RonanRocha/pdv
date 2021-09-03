﻿using EmissorNF.Cliente.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EmissorNF.Cliente.Telas.Caixa
{
    /// <summary>
    /// Lógica interna para WFBuscaProdutos.xaml
    /// </summary>
    public partial class WFBuscaProdutos : Window
    {
        public WFBuscaProdutos(OperacaoVendaViewModel viewModel)
        {
            InitializeComponent();
            viewModel.FecharJanelaProdutosAction = new Action(this.Close);
            DataContext = viewModel;         
        }

    }
}