using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TasteCrafters.Models
{
    public class IngredientModel: INotifyPropertyChanged
    {
        private bool _isSelected;
        public string Name { get; set; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                    SelectionChanged?.Invoke(this, new EventArgs());
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler SelectionChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
