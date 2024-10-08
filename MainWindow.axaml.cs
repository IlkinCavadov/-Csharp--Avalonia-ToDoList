using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.ObjectModel;

namespace ToDoApp
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> _tasks = new ObservableCollection<string>();
        
        public MainWindow()
        {
            InitializeComponent();

            //Setze Itemsoruce des LB auf die sammlung der Aufgaben
            TaskListBox.ItemsSource = _tasks;
        }

            //method für  add Button
        private void OnAddTaskClicked(object ? sender, RoutedEventArgs e) //Nullable Typ für sender
        {
            string ? newTask = NewTaskTextBox.Text; //Nullable für den Text

            if(!string.IsNullOrWhiteSpace(newTask))
            {
                _tasks.Add(newTask);

                NewTaskTextBox.Text = string.Empty;
            }

        }

        private void OnDeleteTaskClicked(object ? sender, RoutedEventArgs e)
        {
            //Hole die ausgewählte Tasks

            var selectedTask = TaskListBox.SelectedItem as string;

            if(selectedTask != null)
            {
                _tasks.Remove(selectedTask);
            }
        }

        private void OnMarkAsDoneClicked(object ? sender, RoutedEventArgs e)
        {
            var selectedTask = TaskListBox.SelectedItem as string;
            if(selectedTask != null)
            {
                _tasks.Add($"✅{selectedTask}");
                _tasks.Remove(selectedTask);
            }
        }
    }
}
