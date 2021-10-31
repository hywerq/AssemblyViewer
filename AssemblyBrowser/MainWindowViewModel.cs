using AssemblyBrowser.Components;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Forms;

namespace AssemblyBrowser
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<Namespaces> _namespaces;
        private RelayCommand _command;

        public ObservableCollection<Namespaces> Namespaces
        {
            get
            {
                return _namespaces;
            }
            set
            {
                _namespaces = value;
                OnPropertyChanged("Namespaces");
            }
        }

        public RelayCommand OpenFile
        {
            get
            {
                return _command ??
                  (_command = new RelayCommand(OpenFileMethod));
            }
        }

        public void OpenFileMethod(object obj)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                    return;

                Namespaces = new ObservableCollection<Namespaces>()
                {
                    new Namespaces(Assembly.LoadFrom(openFileDialog.FileName))
                };        
            }
        }
    }
}
