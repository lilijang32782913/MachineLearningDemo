using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ML1.LeetCode
{
    class OneAndZero
    {
        /*
        
        给你一个二进制字符串数组 strs 和两个整数 m 和 n 。

        请你找出并返回 strs 的最大子集的大小，该子集中 最多 有 m 个 0 和 n 个 1 。

        如果 x 的所有元素也是 y 的元素，集合 x 是集合 y 的 子集 。

 
        示例 1：

        输入：strs = ["10", "0001", "111001", "1", "0"], m = 5, n = 3
        输出：4
        解释：最多有 5 个 0 和 3 个 1 的最大子集是 {"10","0001","1","0"} ，因此答案是 4 。
        其他满足题意但较小的子集包括 {"0001","1"} 和 {"10","1","0"} 。{"111001"} 不满足题意，因为它含 4 个 1 ，大于 n 的值 3 。
        示例 2：

        输入：strs = ["10", "0", "1"], m = 1, n = 1
        输出：2
        解释：最大的子集是 {"0", "1"} ，所以答案是 2 。
        

        提示：

        1 <= strs.length <= 600
        1 <= strs[i].length <= 100
        strs[i] 仅由 '0' 和 '1' 组成
        1 <= m, n <= 100

         */

        public static void Test()
        {
            var obj = new OneAndZero();
            
            //var strs = new string[] { "10", "0001", "111001", "1", "0" };
            //var r = obj.FindMaxForm(strs, 5, 3);

            var strs = new string[] { "10", "0", "1" };
            var r = obj.FindMaxForm(strs, 1, 1);

            //["0","1101","01","00111","1","10010","0","0","00","1","11","0011"]

            //var strs = new string[] { "0", "1101", "01", "00111", "1", "10010", "0", "0", "00", "1", "11", "0011" };
            //var r = obj.FindMaxForm(strs, 63, 36);
        }

        int[,] paths;

        //路径数量缓存, key是用','分割的索引
        Dictionary<string, int> pathCountCaches = new Dictionary<string, int>();

        public int FindMaxForm(string[] strs, int m, int n)
        {
            //代表0,1数量的数组。并且排序为总数,0数量 从小到大
            var arr = new List<Tuple<int, int>>();

            strs = strs.OrderBy(i => i.Length).ToArray();
            foreach (var str in strs)
            {
                var count0 = str.Count(i => i == '0');
                arr.Add(new Tuple<int, int>(count0, str.Length - count0));
            }

            return _FindMaxForm(arr,m,n);
        }

        public int _FindMaxForm(List<Tuple<int, int>> ds, int m, int n)
        {
            if (m <= 0 && n <= 0) return 0;
            var paths = new List<int[]>();
            AddAllPath(Enumerable.Range(0, ds.Count).ToList(), m, n,in paths);
            var strPaths = paths.Select(i=> string.Join(',', i)).Distinct().ToList();
            strPaths = strPaths.OrderBy(i => i).ToList();

            return strPaths.Max(i => {
                var c = GetPathCount(i, ds, m, n);

                return c;
            });
        }

        public void AddAllPath(List<int> indexs, int m, int n,in List<int[]> paths)
        {
            if (indexs.Count == 0) return;
            for (int i = 0; i < indexs.Count; i++)
            {
                var item = indexs[i];
                var sub = indexs.ToList();
                sub.Remove(item);
                AddAllPath(sub, m, n, paths);
                sub.Insert(0, item);
                paths.Add(sub.ToArray());
            }
        }

        /// <summary>
        /// 获取指定路径数量
        /// </summary>
        /// <param name="path"></param>
        /// <param name="ds"></param>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int GetPathCount(string path, List<Tuple<int, int>> ds, int m, int n)
        {
            if (string.IsNullOrWhiteSpace(path)) return 0;

            var r = 0;
            if (pathCountCaches.ContainsKey(path))
            {
                return pathCountCaches[path];
            }
            else
            {
                var subIndex = path.Split(',').ToList();
                var first = int.Parse(subIndex[0]);
                var fitem = ds[first];
                if (subIndex.Count > 0 && fitem.Item1 <= m && fitem.Item2 <= n)
                {
                    subIndex.RemoveAt(0);
                    var subPath = string.Join(',', subIndex);

                    r = GetPathCount(subPath, ds, m - fitem.Item1, n - fitem.Item2) + 1;
                }

                pathCountCaches[path] = r;
            }

            return r;
        }
    }
}
