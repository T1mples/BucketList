using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace BucketList
{
    class ChangeCompleteActionTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var isCompleted = (bool)value;
            return isCompleted ? "Отменить" : "Выполнить";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            throw new NotImplementedException();
        }
    }
}
