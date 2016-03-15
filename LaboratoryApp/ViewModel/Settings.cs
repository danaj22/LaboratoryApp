using System.Runtime.Serialization;

namespace LaboratoryApp.ViewModel
{
    [System.Serializable()]
    public class Settings : ObservableObject, ISerializable
    {

        //Deserialization constructor.
        public Settings(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            SelectedUser = (string)info.GetValue("SelectedUser", typeof(string));
            IsStampPrint = (bool)info.GetValue("IsStampPrint", typeof(bool));
            PathToMailing = (string)info.GetValue("PathToMailing", typeof(string));
            

        }

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"

            info.AddValue("SelectedUser", SelectedUser);
            info.AddValue("IsStampPrint", IsStampPrint);
            info.AddValue("PathToMailing", PathToMailing);
        }

        #region fields
        private string selectedUser;
        private bool isStampPrint;
        private string pathToMailing;

        public Settings()
        {
            SelectedUser = "";
            IsStampPrint = false;
            PathToMailing = "";
        }
        public string SelectedUser
        {
            get
            {
                return selectedUser;
            }

            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }

        public bool IsStampPrint
        {
            get
            {
                return isStampPrint;
            }

            set
            {
                isStampPrint = value;
                OnPropertyChanged("IsStampPrint");
            }
        }

        public string PathToMailing
        {
            get
            {
                return pathToMailing;
            }

            set
            {
                pathToMailing = value;
                OnPropertyChanged("PathToMailing");
            }
        }
        #endregion 
    }
}