using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using cameraatje.Models;
using cameraatje.Repositories;
using cameraatje.Contracts;
using Prism.Navigation;
namespace cameraatje.ViewModels
{
	public class OverviewToddlerViewModel : ViewModelBase
	{
        private IToddlerRepository toddlerRepository;

        private IList<Toddler> toddlers;
        public IList<Toddler> Toddlers
        {
            set { SetProperty(ref toddlers, value); }
            get { return toddlers; }
        }

        public OverviewToddlerViewModel(INavigationService navigationService,  IToddlerRepository toddlerRepository) : base(navigationService)
        {

            this.toddlerRepository = toddlerRepository;
            foreach (var toddler in toddlers)
            {
                    
            }

        /*  var kleuterList = from t in Toddler
                            orderby t.Name ascending
                            select t;*/

        /*  Items.Clear();
          foreach (var kleuter in kleuterList)
          {
              Items.Add(item);
          }*/
    }
        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
          //  Toddlers = await ToddlerRepository.GetItemsAsync();
        }
    }
}
