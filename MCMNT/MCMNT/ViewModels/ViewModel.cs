using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MCMNT.Models;
using MCMNT.Views;
using Realms;
using System.Linq;
using Xamarin.Forms;
using Xamarin.CommunityToolkit;
using Xamarin.CommunityToolkit.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using System.Diagnostics;
using System.Threading;

using System.Net.Http;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.CommunityToolkit.Extensions;

namespace MCMNT.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {

        private Size pagesize;
        public Size PageSize { get => pagesize; set => SetProperty(ref pagesize, value); }
        public ICommand DeleteItemFromListCommand { get; }
      

      public double Cash { get; set; }
        public double CashLost { get; set; }
        public async Task DeleteItemFrom(Items item)
        {

            try
            {
                    _realm.Write(() =>
                    {
                       
                        _realm.Remove(item);
                        ListOfItems.Remove(item);

                    });
                
                //await ShowWarning("(◉◡◉)", " Накладная удалена ");

            }
            catch (Exception e)
            {
                
            }
           
            //await Application.Current.MainPage.Navigation.PopAsync(true);
            //await App.Current.MainPage.Navigation.PushAsync(new ListPage());
        }
        private ObservableRangeCollection<Items> _listofitems;
        public ObservableRangeCollection<Items> ListOfItems
        {
            get=> _listofitems;
            
            set => SetProperty(ref _listofitems, value);
        }
        private ObservableRangeCollection<MyCash> _listofcash;
        public ObservableRangeCollection<MyCash> ListOfCash
        {
            get => _listofcash;

            set => SetProperty(ref _listofcash, value);
        }
        private Items _items = new Items();
        private MyCash _myCash = new MyCash();
     
        public async Task OnAppearing()
        {
            // Cash = _realm.All<MyCash>().Where(MyCash.Cash = 0); ;
            _realm.Write(() =>
            {
                var cash = _realm.All<MyCash>();
                ListOfCash.ReplaceRange(cash);
            });
            
           
            await Task.CompletedTask;
        }
        public Items Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }
        public MyCash MyCash
        {
            get => _myCash;
            set => SetProperty(ref _myCash, value);
        }
        Realm _realm = Realm.GetInstance();
        public ViewModel()
        {


           
            Items.Id = Guid.NewGuid().ToString();            
            ListOfItems = new ObservableRangeCollection<Items>(_realm.All<Items>());
            ListOfCash = new ObservableRangeCollection<MyCash>();
          

            DeleteItemFromListCommand = new AsyncCommand<Items>(DeleteItemFrom);

        }

     

        public void Search(string srh)
       {
            if (string.IsNullOrEmpty(srh))
            {
                ListOfItems = new ObservableRangeCollection<Items>(_realm.All<Items>());
            }
            else
            {
    
               var newitems = _realm.All<Items>().Where(c => c.Name.Contains(srh));
               ListOfItems.ReplaceRange(newitems);
            }

        }

        public Command AddCash
        {
            get
            {
                return new Command(() => {
                    // for auto increment the id upon adding
                  

                    _realm.Write(() =>
                    {

                        
                        _realm.Add(MyCash);
                 
                        
                    });
                 

                });
            }

        }
        public Command CreateCMD
        {
            
            get
            {
                return new Command(() => {
                    try
                    {
                        var @cash = _realm.All<MyCash>().First(d => d.id == "1");
                        MyCash mycash = new MyCash();
                        mycash.Cash = @cash.Cash;
                        mycash.CashLost = @cash.CashLost;

                        _realm.Write(() =>
                        {
                            _realm.Add(Items); // Add the whole set of details
                            mycash.Cash = mycash.Cash - Items.Summ;
                            mycash.CashLost = mycash.CashLost + Items.Summ;
                            @cash = mycash;
                            _realm.RemoveAll<MyCash>();
                            _realm.Add(mycash);
                        });
                    }
                    catch (Exception ex)
                    {

                    }
                    // for auto increment the id upon adding
                   
                    //Application.Current.MainPage.Navigation.PopAsync(true);
                   App.Current.MainPage.Navigation.PushAsync(new MainPage());

                });
            }

        }



        public Command NavToListCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushAsync(new ListPage());
                });
            }
        }
        public Command NavToCreateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    

                    await Shell.Current.GoToAsync("//CreateView");
                });
            }
        }


        public bool SetProperty<T>(ref T backingStore, T value,
             [CallerMemberName] string propertyName = "",
             Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}

