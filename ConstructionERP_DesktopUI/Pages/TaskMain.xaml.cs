﻿using ConstructionERP_DesktopUI.Helpers;
using System.Windows.Controls;
using System.Windows.Input;

namespace ConstructionERP_DesktopUI.Pages
{
    /// <summary>
    /// Interaction logic for TaskMain.xaml
    /// </summary>
    public partial class TaskMain : UserControl
    {

        #region Initialization

        MainLayout mainLayout = null;

        public TaskMain(MainLayout mainLayout)
        {
            InitializeComponent();
            DataContext = this;
            this.mainLayout = mainLayout;
            NavigationCommand = new RelayCommand(mainLayout.SetActiveControl);
        }

        #endregion

        #region Navigation Command

        public ICommand NavigationCommand { get; private set; }

        #endregion
    }
}