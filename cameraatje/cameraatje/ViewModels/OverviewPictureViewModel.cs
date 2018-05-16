using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using cameraatje.Models;

namespace cameraatje.ViewModels
{
    //Author: Stef Kerkhofs
    public class OverviewPictureViewModel : ViewModelBase
    {
        public OverviewPictureViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Fotolijst";

            
       
        }

        private IList<Picture> pictures;
        public IList<Picture> Pictures
        {
            set { SetProperty(ref pictures, value); }
            get { return pictures; }
        }
    }
}
