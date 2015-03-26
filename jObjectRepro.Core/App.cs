using Cirrious.CrossCore.IoC;

namespace jObjectRepro.Core
{
    using Cheesebaron.MvxPlugins.Settings.Interfaces;

    using Cirrious.CrossCore;

    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
            RegisterAppStart<ViewModels.FirstViewModel>();

            var settings = Mvx.Resolve<ISettings>();
            settings.AddOrUpdateValue("test1", "Our Settings Value");
        }
    }
}