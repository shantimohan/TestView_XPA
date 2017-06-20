using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestViews_XPA
{
    public class Person
    {
        public string PersonName { private set; get; }
        public DateTime BirthDay { private set; get; }
        public Color FavColor { private set; get; }

        public Person()
        {

        }

        public Person(string personName, DateTime birthDay, Color favColor)
        {
            this.PersonName = personName;
            this.BirthDay = birthDay;
            this.FavColor = favColor;
        }
    }
}
