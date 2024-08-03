using System.Windows;
using System.Windows.Controls;

namespace PrimalEditor.GameProject
{
    /// <summary>
    /// Interaction logic for NewProjectView.xaml
    /// </summary>
    public partial class NewProjectView : UserControl
    {
        public NewProjectView()
        {
            InitializeComponent();
        }

        private void On_CreateButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NewProject context = DataContext as NewProject;
            string projectPath = context.CreateProject(templateListBox.SelectedItem as ProjectTemplate);
            bool dialogResult = false;
            Window window = Window.GetWindow(this);

            if (!string.IsNullOrEmpty(projectPath))
            {
                dialogResult = true;
                var project = OpenProject.Open(new ProjectData() { ProjectName = context.ProjectName, ProjectPath = projectPath });
                window.DataContext = project;
            }

            window.DialogResult = dialogResult;
            window.Close();
        }
    }
}
