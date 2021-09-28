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


namespace MCMNT.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ICommand DeleteItemFromListCommand { get; }
        
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
        private Items _items = new Items();
        
     
        public async Task OnAppearing()
        {
            await Task.CompletedTask;
        }
        public Items Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }
        Realm _realm = Realm.GetInstance();
        public ViewModel()
        {
            //Items.Id = _items.Id;
            //Items.Name = _items.Name;
            //Items.Description = _items.Description;
            //Items.Summ = _items.Summ;
            Items.Id = Guid.NewGuid().ToString();
            //var tempitems = new List<Items>(_realm.All<Order>()).OrderByDescending(x => x.Courier == null).ThenBy(x => x.Status).ThenBy(x => x.Id);
            ListOfItems = new ObservableRangeCollection<Items>(_realm.All<Items>());
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
        

        public Command CreateCMD
        {
            get
            {
                return new Command(() => {
                    // for auto increment the id upon adding
                    
                    _realm.Write(() =>
                    {


                        
                        _realm.Add(Items); // Add the whole set of details
                    });
                    Application.Current.MainPage.Navigation.PopAsync(true);
                    App.Current.MainPage.Navigation.PushAsync(new CreateView());

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
                    await App.Current.MainPage.Navigation.PushAsync(new CreateView());
                });
            }
        }


        protected bool SetProperty<T>(ref T backingStore, T value,
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

