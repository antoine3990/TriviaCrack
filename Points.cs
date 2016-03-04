using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaCrack
{
    class Points
    {
        public int points { get;  private set; }
        public Category category { get; private set; }

        public Points(Category category_, int points_ = 0)
        {
            category = category_;
            points = points_;
        }

        public void addPoint()
        {
            points++;
        }
    }
}
