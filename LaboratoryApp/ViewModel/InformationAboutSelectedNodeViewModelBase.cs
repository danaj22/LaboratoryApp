using LaboratoryApp.ViewModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
namespace LaboratoryApp
{
    public abstract class InformationAboutSelectedNodeViewModelBase:ObservableObject
    {
        public abstract string Name { get; set; }

        public ObservableCollection<client> Clients { get; set; }
        public client SelectedClient { get; set; }
        public ICommand LoadContent { get; set; }

        public InformationAboutSelectedNodeViewModelBase()
        {

            Clients = new ObservableCollection<client>();
            //Clients.Add(new SingleViewModel() { Title="Q1 : Single Choice Sample"});

            //SelectedClient = Clients[0];
            //SelectedClient.GetContent();

            //LoadContent = new RelayCommand(
            //    () =>
            //{
            //    SelectedClient.GetContent();
            //}, () => {
            //    return SelectedClient != null;
            //});
        

        }
    }
}
