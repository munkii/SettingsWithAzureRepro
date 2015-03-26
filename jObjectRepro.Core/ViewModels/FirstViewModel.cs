using Cirrious.MvvmCross.ViewModels;

namespace jObjectRepro.Core.ViewModels
{
    using Cheesebaron.MvxPlugins.Settings.Interfaces;

    using Cirrious.CrossCore;

    using Microsoft.WindowsAzure.MobileServices;

    public class FirstViewModel 
		: MvxViewModel
    {
		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
            set
            {
                _hello = value; RaisePropertyChanged(() => Hello);
            }
		}

        public string Settings1
        {
            get
            {
                var settings = Mvx.Resolve<ISettings>();

                return settings.GetValue<string>("test1");
            }
        }

        public override void Start()
        {
            base.Start();

            string applicationURL = @"http://localhost:1762";
            string applicationKey = @"YaaNjAoBvaypeGYIOMhkbZfbpKzTUg46";
            
            // TODO CheeseBaron. Commenting out this line will stop the issue with the Settings plugin
            var client = new MobileServiceClient(applicationURL, applicationKey);
        }
    }
}
