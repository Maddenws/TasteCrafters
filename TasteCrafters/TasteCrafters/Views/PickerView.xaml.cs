using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TasteCrafters.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerView : ContentView
    {
        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create(nameof(Source), typeof(ObservableCollection<string>), typeof(PickerView), null);

        public ObservableCollection<string> Source
        {
            get 
            { 
                return (ObservableCollection<string>)GetValue(SourceProperty);
            }
            set 
            { 
                SetValue(SourceProperty, value);
            }
        }

        public PickerView()
        {
            InitializeComponent();
        }

        public PickerView(ObservableCollection<string> source)
        {
            InitializeComponent();
            picker.ItemsSource = source;
            picker2.ItemsSource= source;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //var stack = this.Parent as StackLayout;
            //stack.Children.Remove(this); //fix ability to remove add picker 
        }
    }
}
