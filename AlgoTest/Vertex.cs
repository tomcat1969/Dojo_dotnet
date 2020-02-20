using System;
using System.Collections.Generic;

namespace AlgoTest
{
    class Vertex
    {
        public int val;
        public List<Vertex> neighbors;
        public Vertex (int val)
        {
            this.val = val;
        }
    }
}
