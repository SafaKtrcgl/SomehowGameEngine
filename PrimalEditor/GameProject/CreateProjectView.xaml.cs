using System.Windows;
using System.Windows.Controls;

namespace PrimalEditor.GameProject
{
    /// <summary>
    /// Interaction logic for CreateProjectView.xaml
    /// </summary>
    public partial class CreateProjectView : UserControl
    {
        public CreateProjectView()
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
            }

            window.DialogResult = dialogResult;
            window.Close();
        }
    }
}
