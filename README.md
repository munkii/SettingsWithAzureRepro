# SettingsWithAzureRepro
Repro case for an issue I am seeing with CheeseBaron's Settings Plugin for MVVMCross and Microsoft's Azure Mobile Services SDK

FirstViewModel has a Settings1 property that uses the Settings plugin to read a simple String value added in the 
Core project's App.cs.

This property works fine until I introduce the following line of code that initialises a 
Microsoft.WindowsAzure.MobileServices.MobileServiceClient

<pre><code>var client = new MobileServiceClient(applicationURL, applicationKey);</pre></code>

Once that line has been executed the FirstViewModel.Setimgs1 property will error with the following Exception

*System.ArgumentException: 'jobject' must not be IntPtr.Zero.*
*Parameter name: jobject*

The Call Stack from VS at the time of the excpetion is

<pre><code>
in jObjectRepro.Core.ViewModels.FirstViewModel.get_Settings1 at c:\Projects\My Projects\jObjectRepro\jObjectRepro.Core\ViewModels\FirstViewModel.cs:30,-1	C#
in System.Reflection.MonoProperty.GetterAdapterFrame<jObjectRepro.Core.ViewModels.FirstViewModel, string>	C#  
in System.Reflection.MonoProperty.GetValue	C#  
in Cirrious.MvvmCross.Binding.Bindings.Source.Leaf.MvxLeafPropertyInfoSourceBinding.GetValue	C#
in Cirrious.MvvmCross.Binding.Bindings.SourceSteps.MvxPathSourceStep.GetSourceValue	C#
in Cirrious.MvvmCross.Binding.Bindings.SourceSteps.MvxSourceStep.GetValue	C#
in Cirrious.MvvmCross.Binding.Bindings.MvxFullBinding.UpdateTargetOnBind	C#
in Cirrious.MvvmCross.Binding.Bindings.MvxFullBinding.CreateSourceBinding	C#
in Cirrious.MvvmCross.Binding.Bindings.MvxFullBinding..ctor	C#
in Cirrious.MvvmCross.Binding.Binders.MvxFromTextBinder.BindSingle	C#
in Cirrious.MvvmCross.Binding.Binders.MvxFromTextBinder.	C#
in System.Linq.Enumerable.<CreateSelectIterator>c__Iterator10<Cirrious.MvvmCross.Binding.Bindings.MvxBindingDescription,Cirrious.MvvmCross.Binding.Bindings.CreateSelectIterator	C#
in System.Collections.Generic.List<Cirrious.MvvmCross.Binding.Bindings.IMvxUpdateableBinding>.AddEnumerable	C#
in System.Collections.Generic.List<Cirrious.MvvmCross.Binding.Bindings.IMvxUpdateableBinding>.AddRange	C#
in Cirrious.MvvmCross.Binding.Droid.Binders.MvxAndroidViewBinder.ApplyBindingsFromAttribute	C#
in Cirrious.MvvmCross.Binding.Droid.Binders.MvxAndroidViewBinder.BindView	C#
in Cirrious.MvvmCross.Binding.Droid.Binders.MvxBindingLayoutInflatorFactory.OnCreateView	C#
in Android.Views.LayoutInflater.IFactoryInvoker.n_OnCreateView_Ljava_lang_String_Landroid_content_Context_Landroid_util_AttributeSet_ at /Users/builder/data/lanes/monodroid-mlion-monodroid-4.21-series/9e05e39f/source/monodroid/src/Mono.Android/platforms/android-19/src/generated/Android.Views.LayoutInflater.cs:78,5	C#
in object.8afd7204-9aad-4777-9a9f-53f796723a61	C#
in Android.Runtime.JNIEnv.CallObjectMethod at /Users/builder/data/lanes/monodroid-mlion-monodroid-4.21-series/9e05e39f/source/monodroid/src/Mono.Android/src/Runtime/JNIEnv.g.cs:191,4	C#
in Android.Views.LayoutInflater.Inflate at /Users/builder/data/lanes/monodroid-mlion-monodroid-4.21-series/9e05e39f/source/monodroid/src/Mono.Android/platforms/android-19/src/generated/Android.Views.LayoutInflater.cs:609,5	C#
in Cirrious.MvvmCross.Binding.Droid.BindingContext.MvxAndroidBindingContext.CommonInflate	C#
in Cirrious.MvvmCross.Binding.Droid.BindingContext.MvxAndroidBindingContext.BindingInflate	C#
in Cirrious.MvvmCross.Binding.Droid.BindingContext.MvxAndroidBindingContext.BindingInflate	C#
in Cirrious.MvvmCross.Binding.Droid.BindingContext.MvxBindingContextOwnerExtensions.BindingInflate	C#
in Cirrious.MvvmCross.Droid.Views.MvxActivity.SetContentView	C#
in jObjectRepro.Droid.Views.FirstView.OnCreate at c:\Projects\My Projects\jObjectRepro\jObjectRepro.Droid\Views\FirstView.cs:13,-1	C#
</pre></code>
