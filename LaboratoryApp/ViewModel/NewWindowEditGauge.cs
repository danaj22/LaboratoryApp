using LaboratoryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LaboratoryApp.ViewModel
{
    public class NewWindowEditGauge : ObservableObject
    {
        public NewWindowEditGauge()
        {
            OKCommand = new SimpleRelayCommand(Confirm);
            CancelCommand = new SimpleRelayCommand(Close);
            InitializeCollectionOfManufacturers();
        }
        private void InitializeCollectionOfManufacturers()
        {
            using (LaboratoryEntities lab = new LaboratoryEntities())
            {
                CollectionOfManufacturers = (from m in lab.model_of_gauges select m.manufacturer_name).Distinct().ToList();
            }
        }
        private void InitializeCollectionOfModels()
        {
            if (SelectedManufacturer != null)
            {
                using (LaboratoryEntities context = new LaboratoryEntities())
                {
                    CollectionOfModels = (from g in context.model_of_gauges where g.manufacturer_name == SelectedManufacturer select g.model).ToList();

                }
            }
        }
        List<string> collectionOfModels;
        public List<string> CollectionOfModels
        {
            get { return collectionOfModels; }
            set
            {
                collectionOfModels = value;
                OnPropertyChanged("CollectionOfModels");
            }
        }
        private string selectedManufacturer;
        public string SelectedManufacturer
        {
            get { return selectedManufacturer; }
            set
            {
                selectedManufacturer = value;
                InitializeCollectionOfModels();
                OnPropertyChanged("SelectedManufacturer");
            }
        }
        private string selectedModel;
        public string SelectedModel
        {
            get { return selectedModel; }
            set
            {
                selectedModel = value;
                OnPropertyChanged("SelectedModel");
            }

        }

        List<string> collectionOfManufacturers = new List<string>();
        public List<string> CollectionOfManufacturers
        {
            get { return this.collectionOfManufacturers; }
            set
            {
                collectionOfManufacturers = value;
                OnPropertyChanged("CollectionOfManufacturers");
            }

        }
        private ICommand okCommand;

        public ICommand OKCommand
        {
            get { return okCommand; }
            set
            {
                okCommand = value;
                base.OnPropertyChanged("OKCommand");
            }
        }
        private ICommand cancelCommand;

        public ICommand CancelCommand
        {
            get { return cancelCommand; }
            set
            {
                cancelCommand = value;
                OnPropertyChanged("CancelCommand");
            }
        }

        private bool isOpen;

        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                isOpen = value;
                base.OnPropertyChanged("IsOpen");
            }
        }
        private bool toConfirm;

        public bool ToConfirm
        {
            get { return toConfirm; }
            set
            {
                toConfirm = value;
                base.OnPropertyChanged("ToConfirm");
            }
        }

        public NewWindowModelOfGauge MessageWindowModelOfGauge
        {
            get
            {
                return messageWindowModelOfGauge;
            }

            set
            {
                messageWindowModelOfGauge = value;
                OnPropertyChanged("MessageWindowModelOfGauge");
            }
        }

        private NewWindowModelOfGauge messageWindowModelOfGauge;

        private ObservableCollection<calibrators_model_of_gauges> CollectionOfCalModel = new ObservableCollection<calibrators_model_of_gauges>();
        private ObservableCollection<model_of_gauges_functions> CollectionOfFunModel = new ObservableCollection<model_of_gauges_functions>();

        public void Confirm()
        {
            if (!ToConfirm) ToConfirm = true;


            using (LaboratoryEntities context = new LaboratoryEntities())
            {

                model_of_gauges result = (from m in context.model_of_gauges where m.model == SelectedModel select m).FirstOrDefault();

                
                {
                    MessageWindowModelOfGauge = new NewWindowModelOfGauge();
                    MessageWindowModelOfGauge.AboutModelOfGauge = new InformationAboutModelOfGauge();

                    MessageWindowModelOfGauge.AboutModelOfGauge.Model = result.model;
                    MessageWindowModelOfGauge.AboutModelOfGauge.ManufacturerName = result.manufacturer_name;
                    MessageWindowModelOfGauge.AboutModelOfGauge.SelectedType = result.type.name;
                    MessageWindowModelOfGauge.AboutModelOfGauge.SelectedUsage = result.usage.description;


                    
                    foreach (calibrator calib in MessageWindowModelOfGauge.CollectionOfCalibrators)
                    {
                        foreach(calibrators_model_of_gauges tmpCalModOfGaug in result.calibrators_model_of_gauges)
                        {
                            if(calib.name == tmpCalModOfGaug.calibrator.name)
                            {
                                calib.IsChecked = true;
                            }
                        }
                    }

                    foreach(function fun in MessageWindowModelOfGauge.CollectionOfCheckedFunction)
                    {
                        foreach(model_of_gauges_functions tmpFunModOfGaug in result.model_of_gauges_functions)
                        {
                            if(fun.name == tmpFunModOfGaug.function.name)
                            {
                                fun.IsChecked = true;
                            }
                        }
                    }

                    if (File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + ".txt"))
                    {
                        string[] str = File.ReadAllLines(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + ".txt");

                        foreach (CalibrationTable calTab in MessageWindowModelOfGauge.ListOfNamesOfTables)
                        {
                            foreach (string tmp in str)
                            {
                                int index = tmp.IndexOf("\t");
                                string tmpName = tmp.Substring(index + 1);
                                if(tmpName == calTab.Name)
                                {
                                    calTab.IsChecked = true;

                                }
                            }
                        }
                    }

                    


                    MessageWindowModelOfGauge.IsOpen = true;

                    if (MessageWindowModelOfGauge.ToConfirm)
                    {
                         if (MessageWindowModelOfGauge.ToConfirm)
                        {
                            if (!String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.ManufacturerName)
                                && !String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.Model)
                                && !String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.SelectedUsage)
                                && !String.IsNullOrEmpty(MessageWindowModelOfGauge.AboutModelOfGauge.SelectedType)
                                )
                            {
                                MessageBoxResult mbr = MessageBox.Show("Czy chcesz dodać nowy model miernika na podstawie tego modelu?", "Pytanie", MessageBoxButton.YesNo);
                               
                                //
                                //Edycja starego modelu
                                //
                                if (mbr == MessageBoxResult.No)
                                {
                                    System.IO.Directory.CreateDirectory(@"C:\ProgramData\DASLSystems\LaboratoryApp\models");

                                    File.Create(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + ".txt").Dispose();

                                    foreach (CalibrationTable str in MessageWindowModelOfGauge.ListOfNamesOfTables)
                                    {
                                        if (str.IsChecked)
                                        {
                                            File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + ".txt", str.TypeOfWindow + "\t" + str.Name);
                                            File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + ".txt", "\n");
                                        }
                                    }


                                    result.manufacturer_name = MessageWindowModelOfGauge.AboutModelOfGauge.ManufacturerName;
                                    result.model = MessageWindowModelOfGauge.AboutModelOfGauge.Model;


                                    {
                                        try
                                        {
                                            {
                                                {
                                                    result.type = (from t in context.types where t.name == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedType select t).FirstOrDefault();
                                                    result.usage = (from u in context.usages where u.description == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedUsage select u).FirstOrDefault();
                                                    result.type_id = (from t in context.types where t.name == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedType select t.typeId).FirstOrDefault();
                                                    result.usage_id = (from u in context.usages where u.description == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedUsage select u.usageId).FirstOrDefault();

                                                    var listOfCheckedItems = MessageWindowModelOfGauge.CollectionOfCalibrators.ToList();
                                                    context.SaveChanges();
                                                }
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            System.Windows.MessageBox.Show("Nie udało się dodać modelu miernika.");
                                            File.AppendAllText(MainWindowViewModel.path, e.ToString());
                                        }
                                    }
                                    try
                                    {




                                        foreach (calibrator zmienna in MessageWindowModelOfGauge.CollectionOfCalibrators)
                                        {

                                            if (zmienna.IsChecked)
                                            {
                                                try
                                                {

                                                    calibrators_model_of_gauges calib_gauge_model = new calibrators_model_of_gauges();
                                                    calib_gauge_model.calibrator_id = zmienna.calibratorId;


                                                    calib_gauge_model.model_of_gauges = result;
                                                    calib_gauge_model.model_of_gaug_id = result.model_of_gaugeId;

                                                    CollectionOfCalModel.Add(calib_gauge_model);


                                                }
                                                catch (Exception e)
                                                {
                                                    System.Windows.MessageBox.Show("Nie udało się dodać kalibratora do modelu miernika.");
                                                    File.AppendAllText(MainWindowViewModel.path, e.ToString());
                                                }

                                            }

                                        }
                                        //do ogarnięcia aktualizowanie zaznaczonych funkcji

                                        try
                                        {
                                            result.calibrators_model_of_gauges = CollectionOfCalModel;
                                            context.SaveChanges();
                                        }
                                        catch (Exception e)
                                        {
                                            File.AppendAllText(MainWindowViewModel.path, e.ToString());
                                        }

                                        foreach (function zmienna in MessageWindowModelOfGauge.CollectionOfCheckedFunction)
                                        {
                                            if (zmienna.IsChecked)
                                            {
                                                try
                                                {
                                                    model_of_gauges_functions fun_mod_of_gaug = new model_of_gauges_functions();
                                                    fun_mod_of_gaug.function_Id = zmienna.functionId;
                                                    fun_mod_of_gaug.model_of_gauges = result;
                                                    fun_mod_of_gaug.model_of_gauge_id = result.model_of_gaugeId;

                                                    CollectionOfFunModel.Add(fun_mod_of_gaug);

                                                }
                                                catch (Exception e)
                                                {
                                                    System.Windows.MessageBox.Show("Nie udało się dodać funkcji do modelu miernika.");
                                                    File.AppendAllText(MainWindowViewModel.path, e.ToString());
                                                }

                                            }
                                            //dodawanie tabel do modelu miernika
                                            //try
                                            //{
                                            //    System.IO.Directory.CreateDirectory(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\model");
                                            //    if (zmienna.IsChecked)
                                            //    {
                                            //        File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\model\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + ".txt", zmienna.functionId + "\n");
                                            //        zmienna.IsChecked = false;
                                            //    }
                                            //}
                                            //catch (Exception e)
                                            //{
                                            //    File.AppendAllText(MainWindowViewModel.path, e.ToString());
                                            //}
                                        }
                                        try
                                        {
                                            result.model_of_gauges_functions = CollectionOfFunModel;
                                            context.SaveChanges();
                                        }
                                        catch (Exception e)

                                        {
                                            File.AppendAllText(MainWindowViewModel.path, e.ToString());
                                        }


                                        ////
                                        ////DO SKOŃCZENIA!!!
                                        ////dodawanie tabeli pomiarowej do listy tabel należacych do miernika
                                        ////
                                        string[] CheckedTables = File.ReadAllLines(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\model\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + ".txt");

                                        List<string> tmp = new List<string>();
                                        foreach (string str in CheckedTables)
                                        {
                                            int indexStart = str.IndexOf("\t");
                                            string s = str.Substring(indexStart + 1);
                                            tmp.Add(s);
                                        }



                                        //foreach (string CheckedTable in CheckedTables)
                                        //{
                                        //    foreach (CalibrationTable CalTab in MessageWindowModelOfGauge.ListOfNamesOfTables)
                                        //    {
                                        //        if (CalTab.Name == CheckedTable.Name)
                                        //        {
                                        //            CalTab.IsChecked = true;
                                        //        }
                                        //    }
                                        //}

                                    }
                                    catch (Exception e)
                                    {
                                        File.AppendAllText(MainWindowViewModel.path, e.ToString());
                                    }
                                }//zakonczenie pytania o to czy chcesz edytować stary miernik czy utworzyc na jego podstawie nowy 

                                else if(mbr == MessageBoxResult.Yes)
                                {
                                    System.IO.Directory.CreateDirectory(@"C:\ProgramData\DASLSystems\LaboratoryApp\models");

                                    if (!File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + ".txt"))
                                    {
                                        foreach (CalibrationTable str in MessageWindowModelOfGauge.ListOfNamesOfTables)
                                        {
                                            if (str.IsChecked)
                                            {
                                                File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + ".txt", str.TypeOfWindow + "\t" + str.Name);
                                                File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + ".txt", "\n");
                                            }
                                        }
                                    }

                                    //if (!File.Exists(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + "$.txt"))
                                    //{
                                    //    //foreach(IEnumerableTable str in MessageWindowModelOfGauge.MessageWindowTable.ListOfWindows)
                                    //    {
                                    //            File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + "$.txt", str.ToString()+"$"+ str/*.NameOfFile*/);
                                    //            File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + "$.txt", "\n");
                                    //    }
                                    //}


                                    model_of_gauges newGauge = new model_of_gauges();
                                    newGauge.manufacturer_name = MessageWindowModelOfGauge.AboutModelOfGauge.ManufacturerName;
                                    newGauge.model = MessageWindowModelOfGauge.AboutModelOfGauge.Model;


                                    try
                                    {
                                        {
                                            {
                                                newGauge.type = (from t in context.types where t.name == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedType select t).FirstOrDefault();
                                                newGauge.usage = (from u in context.usages where u.description == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedUsage select u).FirstOrDefault();
                                                newGauge.type_id = (from t in context.types where t.name == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedType select t.typeId).FirstOrDefault();
                                                newGauge.usage_id = (from u in context.usages where u.description == MessageWindowModelOfGauge.AboutModelOfGauge.SelectedUsage select u.usageId).FirstOrDefault();

                                                var listOfCheckedItems = MessageWindowModelOfGauge.CollectionOfCalibrators.ToList();
                                                //newGauge.calibrators_model_of_gauges = (Models.calibrators_model_of_gauges)listOfCheckedItems;

                                                context.model_of_gauges.Add(newGauge);
                                                context.SaveChanges();
                                            }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        System.Windows.MessageBox.Show("Nie udało się dodać modelu miernika.");
                                        File.AppendAllText(MainWindowViewModel.path, e.ToString());
                                    }
                                    try
                                    {

                                        //int LastModelId = (from m in context.model_of_gauges orderby m.model_of_gaugeId descending select m.model_of_gaugeId).First();

                                        foreach (calibrator zmienna in MessageWindowModelOfGauge.CollectionOfCalibrators)
                                        {

                                            if (zmienna.IsChecked)
                                            {
                                                try
                                                {

                                                    calibrators_model_of_gauges calib_gauge_model = new calibrators_model_of_gauges();
                                                    //calib_gauge_model.calibrator = zmienna;
                                                    calib_gauge_model.calibrator_id = zmienna.calibratorId;

                                                    model_of_gauges model = (from m in context.model_of_gauges orderby m.model_of_gaugeId descending select m).First();

                                                    calib_gauge_model.model_of_gauges = model;
                                                    calib_gauge_model.model_of_gaug_id = model.model_of_gaugeId;



                                                    context.calibrators_model_of_gauges.Add(calib_gauge_model);
                                                    context.SaveChanges();

                                                }
                                                catch (Exception e)
                                                {
                                                    System.Windows.MessageBox.Show("Nie udało się dodać kalibratora do modelu miernika.");
                                                    File.AppendAllText(MainWindowViewModel.path, e.ToString());
                                                }
                                            }
                                            //newGauge.calibrator_model_of_gauge.Add(zmienna);
                                        }
                                        foreach (function zmienna in MessageWindowModelOfGauge.CollectionOfCheckedFunction)
                                        {
                                            try
                                            {
                                                //System.IO.Directory.CreateDirectory(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\model");
                                                if (zmienna.IsChecked)
                                                {
                                                    model_of_gauges_functions mod_of_gaug_fun = new model_of_gauges_functions();
                                                    mod_of_gaug_fun.function_Id = zmienna.functionId;
                                                    model_of_gauges model = (from m in context.model_of_gauges orderby m.model_of_gaugeId descending select m).First();

                                                    mod_of_gaug_fun.model_of_gauges = model;
                                                    mod_of_gaug_fun.model_of_gauge_id = model.model_of_gaugeId;

                                                    context.model_of_gauges_functions.Add(mod_of_gaug_fun);
                                                    context.SaveChanges();

                                                    //File.AppendAllText(@"C:\ProgramData\DASLSystems\LaboratoryApp\models\model\" + MessageWindowModelOfGauge.AboutModelOfGauge.Model + ".txt", zmienna.functionId + "\n");

                                                    zmienna.IsChecked = false;
                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                File.AppendAllText(MainWindowViewModel.path, e.ToString());
                                            }
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        File.AppendAllText(MainWindowViewModel.path, ex.ToString());
                                    }
                                }


                            }

                        }
                        MessageWindowModelOfGauge.ToConfirm = false;


                    }

                    IsOpen = false;

                }
            }
        }
        public void Close()
        {
            IsOpen = false;
        }
    }
}
