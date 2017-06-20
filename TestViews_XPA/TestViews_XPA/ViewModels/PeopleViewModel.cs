using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestViews_XPA
{
    public class PeopleViewModel
    {
        public List<Person> People { get; set; }

        public PeopleViewModel()
        {
            People = new List<Person>
            {
                new Person("Abigail", new DateTime(1975, 1, 15), Color.Aqua),
                new Person("Bob", new DateTime(1976, 2,20), Color.Black),
                new Person("Cathy", new DateTime(1977, 3, 10), Color.Violet),
                new Person("David", new DateTime(1978, 4, 25), Color.Magenta),
                new Person("Eugenie", new DateTime(1979, 6, 5), Color.Olive),
                new Person("Freddie", new DateTime(1960, 6, 30), Color.Green),
                new Person("Greta", new DateTime(1961, 7, 15), Color.Red),
                new Person("Harold", new DateTime(1962, 6, 10), Color.Brown),
                new Person("Irene", new DateTime(1963, 9, 25), Color.Blue),
                new Person("Yvonne", new DateTime(1987, 1, 10), Color.Purple),
                new Person("Zachary", new DateTime(1988, 2, 5), Color.Red),
            };
        }
    }
}
