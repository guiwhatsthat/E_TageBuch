﻿using System;
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

namespace e_tagebuch
{
    /// <summary>
    /// Interaction logic for frmHauptSeite.xaml
    /// </summary>
    public partial class frmHauptSeite : Window
    {
        public frmHauptSeite()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            e_tagebuch.frmEditor EditWindow = new frmEditor();
            this.Close();
            EditWindow.Show();
        }
    }
}
