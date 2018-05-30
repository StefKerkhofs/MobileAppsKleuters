using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using cameraatje.Models;
using cameraatje.Repositories;
using cameraatje.Contracts;
using Prism.Navigation;
using Prism.Services;

namespace cameraatje.ViewModels
{
	public class OverviewToddlerViewModel : ViewModelBase
	{
        private IRepository repos;
        private IDbContext dbContext;


        private IList<Toddler> toddlers;
        public IList<Toddler> Toddlers
        {
            set { SetProperty(ref toddlers, value); }
            get { return toddlers; }
        }
        private Toddler selectedToddler;
        public Toddler SelectedToddler
        {
            get { return selectedToddler; }
            set
            {
                if (SetProperty(ref selectedToddler, value) && selectedToddler != null)
                {
                    var p = new NavigationParameters
                    {
                        { "Kid", selectedToddler },
                        { "PictureUrl", pictureUrl }
                    };
                    NavigationService.NavigateAsync("OverviewCornerView", p);
                    selectedToddler = null;
                }
            }
        }

        private string pictureUrl;
        public OverviewToddlerViewModel(INavigationService navigationService,  IRepository repos, IDbContext dbContext) : base(navigationService)
        {
            this.dbContext = dbContext;
            this.repos = repos;
    }
        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
           
            if (parameters.ContainsKey("PictureUrl"))
            {
                pictureUrl = (string)parameters["PictureUrl"];
            }

            repos = new CameraatjeRepository(dbContext);
            Toddlers = await repos.GetToddlersAsync();
        }
    }
}
