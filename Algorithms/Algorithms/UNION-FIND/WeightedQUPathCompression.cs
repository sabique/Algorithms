﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.UNION_FIND
{
    class WeightedQUPathCompression
    {
        int[] id, sz;
        
        public WeightedQUPathCompression(int n)
        {
            id = new int[n];
            sz = new int[n];

            for (int i = 0; i < n; i++)
            {
                id[i] = i;
                sz[i] = 1;
            }
        }

        private int root(int i)
        {
            while(i != id[i])
            {
                id[i] = id[id[i]];
                i = id[i];
            }
            return i;
        }

        public bool Connected(int p, int q)
        {
            return root(p) == root(q);
        }

        public void Union(int p, int q)
        {
            int i = root(p);
            int j = root(q);

            if (i == j) return;

            if(sz[i] < sz[j])
            {
                id[i] = j;
                sz[j] += sz[i];
            }
            else
            {
                id[j] = i;
                sz[i] += sz[j];
            }
        }
    }
}
