using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ParfumeryProj.Model
{
    public partial class Product
    {
        public string GetImage
        {
            get
            {
                return Photo == null ? @"C:\Users\kraic\OneDrive\Рабочий стол\meme\doggy.jpg" : Photo; 
            }
        }

        public string GetColor
        {
            get
            {
                if (MinCost > 100)
                    return Colors.LightGreen.ToString();

                return Colors.White.ToString();
            }
        }

    }
}
