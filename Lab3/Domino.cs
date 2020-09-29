using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Domino
    {
        int first, second;
        bool used;
        public Domino(int first, int second)
        {
            this.first = first;
            this.second = second;
            used = false;
        }

        public bool Cover(int first, int second)
        {
            if (used)
                return false;
            if((this.first == first && this.second == second) || (this.first == second && this.second == first))
            {
                used = true;
                return true;
            }
            return false;
        }

        public bool Uncover(int first, int second)
        {
            if (this.first == first && this.second == second || this.first == second && this.second == first)
            {
                used = false;
            }
            return !used;
        }
    }
}
