using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Cecs475.Othello.Application
{
    public class OthelloPlayerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int player = (int)value;
            String currPlayer = "";
            if(player == 2)
            {
                currPlayer = "White";
            }
            else
            {
                currPlayer = "Black";
            }
            return currPlayer;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
