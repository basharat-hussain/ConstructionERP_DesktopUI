﻿using ConstructionERP_DesktopUI.API;
using ConstructionERP_DesktopUI.Helpers;
using ConstructionERP_DesktopUI.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ConstructionERP_DesktopUI.Pages
{
    /// <summary>
    /// Interaction logic for MainLayout.xaml
    /// </summary>
    public partial class MainLayout : INotifyPropertyChanged
    {
        #region Initialization

        public MainLayout(ProjectModel selectedProject)
        {
            InitializeComponent();
            DataContext = this;
            SelectedProject = selectedProject;
            SetValues();
        }

        async void SetValues()
        {
            NavigationCommand = new RelayCommand(SetActiveControl);
            LoggedInUser = Application.Current.Properties["LoggedInUser"] as LoggedInUser;
            await GetProjects();
            NavigationCommand.Execute("Dashboard");
        }

        #endregion

        #region ActiveControl

        public ICommand NavigationCommand { get; private set; }

        public void SetActiveControl(object item)
        {
            object view = null;
            switch (item.ToString())
            {
                case "Dashboard":
                    view = new Dashboard(this);
                    break;
                case "Task":
                    view = new TaskControl(this);
                    break;
                case "TaskStatus":
                    view = new TaskStatus(this);
                    break;
                case "TaskType":
                    view = new TaskType(this);
                    break;
                case "TaskCategory":
                    view = new TaskCategory(this);
                    break;
                case "Sheet":
                    view = new Sheet(this);
                    break;
                case "Document":
                    view = new Document(this);
                    break;
                case "Contractor":
                    view = new Contractor(this);
                    break;
                case "ProjectContractor":
                    view = new ProjectContractor(this);
                    break;
                case "Supplier":
                    view = new Supplier(this);
                    break;
                case "ProjectSupplier":
                    view = new ProjectSupplier(this);
                    break;
                case "Customer":
                    view = new Customer(this);
                    break;
                case "Unit":
                    view = new Unit(this);
                    break;
                case "Material":
                    view = new Material(this);
                    break;
                case "SalesEnquiry":
                    view = new SalesEnquiry(this);
                    break;
                case "Firm":
                    view = new Firm(this);
                    break;
                case "Project":
                    view = new Project(this);
                    break;
                case "ProjectStatus":
                    view = new ProjectStatus(this);
                    break;
                case "ProjectType":
                    view = new ProjectType(this);
                    break;
                case "SiteManager":
                    view = new SiteManager(this);
                    break;
                case "Team":
                    view = new Team(this);
                    break;
                case "Quotation":
                    view = new Quotation(this);
                    break;
                case "Masters":
                    view = new Masters(this);
                    break;
                case "Settings":
                    view = new Settings(this);
                    break;
                case "PaymentMode":
                    view = new PaymentMode(this);
                    break;
                default:
                    view = new Dashboard(this);
                    break;
            }
            Container.Content = view;
        }

        #endregion

        #region Properties

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private LoggedInUser loggedInUser;

        public LoggedInUser LoggedInUser
        {
            get { return loggedInUser; }
            set
            {
                loggedInUser = value;
                OnPropertyChanged("LoggedInUser");
            }
        }


        private ObservableCollection<ProjectModel> projects;

        public ObservableCollection<ProjectModel> Projects
        {
            get { return projects; }
            set
            {
                projects = value;
                OnPropertyChanged("Projects");
            }
        }


        private ProjectModel selectedProject;

        public ProjectModel SelectedProject
        {
            get { return selectedProject; }
            set
            {
                selectedProject = value;
                OnPropertyChanged("SelectedProject");
            }
        }

        #endregion

        #region Get Projects

        public async Task GetProjects()
        {
            try
            {
                Projects = await new ProjectAPIHelper().GetProjects(LoggedInUser.Token);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }


        }

        #endregion

        #region Window Dimensions

        private double layoutMaxHeight;

        public double LayoutMaxHeight
        {
            get { return layoutMaxHeight; }
            set
            {
                layoutMaxHeight = value;
                OnPropertyChanged("LayoutMaxHeight");
            }
        }

        private double layoutMaxWidth;

        public double LayoutMaxWidth
        {
            get { return layoutMaxWidth; }
            set
            {
                layoutMaxWidth = value;
                OnPropertyChanged("LayoutMaxWidth");
            }
        }

        void SetDimensions()
        {
            LayoutMaxHeight = SystemParameters.WorkArea.Width;
            LayoutMaxWidth = SystemParameters.WorkArea.Height;
        }

        #endregion
    }
}
