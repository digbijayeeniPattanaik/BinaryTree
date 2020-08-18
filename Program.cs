using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTreeLeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ////var tree = new TreeNode() { val = 10, left = new TreeNode() { val = 5 }, right = new TreeNode() { val = 15, left = new TreeNode() { val = 6 }, right = new TreeNode() { val = 20 } } };
            ////var output = IsValidBST(tree);
            var linkedList = new ListNode() { val = 1, next = new ListNode() { val = 2, next = new ListNode() { val = 3, next = new ListNode() { val = 4, next = new ListNode() { val = 5 } } } } };
            var reverseList = ReverseList(linkedList);
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }



        public static ListNode ReverseList(ListNode head)
        {
            List<int> lis = new List<int>();
            var currentHead = head;
            lis.Add(currentHead.val);
            while (currentHead != null && currentHead.next != null)
            {
                lis.Add(currentHead.next.val);
                currentHead = currentHead.next;
            }

            var reverse = new ListNode();
            int len = lis.Count;
            reverse.val = lis[len - 1];
            for (int i = 1; i < len; i++)
            {
                var current = reverse;
                var temp = new ListNode(lis[len - i - 1]);
                current.next = temp;
                reverse = current;
            }
            return reverse;
        }
        public static bool IsValidBST(TreeNode root)
        {
            bool isValid = true;
            if (root != null)
            {
                if (root.left != null)
                {
                    isValid = root.val > root.left.val ? true : false;
                    if (isValid)
                        isValid = IsValidBST(root.left);
                }
                if (root.right != null)
                {
                    isValid = root.val < root.right.val ? true : false;
                    if (isValid)
                        isValid = IsValidBST(root.right);
                }
                if (root.left == null && root.right == null) isValid = true;
            }
            return isValid;
        }

        public static string LongestCommonPrefix(string[] strs)
        {
            int length = strs.Length;
            if (length == 0) return "";
            if (length == 1) return strs[0];
            Array.Sort(strs);
            int minimumLength = strs.Min(a => a.Length);
            int i = 0;
            while (i < minimumLength && strs[0][i] == strs[length - 1][i])
                i++;

            return strs[0].Substring(0, i);
        }

        public static int StrStr(string haystack, string needle)
        {
            if (haystack.Contains(needle, StringComparison.InvariantCultureIgnoreCase))
                return haystack.IndexOf(needle);
            return -1;
        }

        public static bool IsPalindrome(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return true;
            string reverse = string.Empty;

            var newS = new String(s.Where(a => char.IsLetterOrDigit(a)).ToArray());
            var len = newS.Length - 1;
            while (len >= 0)
            {
                reverse += newS[len];
                len--;
            }
            if (newS.Equals(reverse, StringComparison.InvariantCultureIgnoreCase)) return true;
            return false;
        }

        public bool IsAnagram(string s, string t)
        {
            if (string.IsNullOrWhiteSpace(s) && string.IsNullOrWhiteSpace(t)) return true;
            if (string.IsNullOrWhiteSpace(s)) return false;
            if (string.IsNullOrWhiteSpace(t)) return false;
            if (s.Equals(t, StringComparison.InvariantCultureIgnoreCase)) return true;
            if (s.Length != t.Length) return false;
            var sCharCount = s.ToCharArray().GroupBy(a => a).Select(a => new { a.Key, Count = a.Count() });
            var tCharCount = t.ToCharArray().GroupBy(a => a).Select(a => new { a.Key, Count = a.Count() });
            var result = true;
            foreach (var item in sCharCount)
            {
                if (!tCharCount.Any(a => a.Key == item.Key && a.Count == item.Count)) result = false;
            }
            return result;
        }

        public static void ReverseString(string[] s)
        {
            var backup = new string[s.Length];
            Array.Copy(s, 0, backup, 0, s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = backup[s.Length - 1 - i];
            }
        }

        public static int Reverse(int x)
        {
            var a = (x < 0) ? "-" : "";
            if (a == "-") x = x * -1;
            var test = x.ToString().ToCharArray();
            var test2 = new char[test.Length];
            for (int i = 0; i < test.Length; i++)
            {
                test2[i] = test[test.Length - 1 - i];
            }
            string final = string.Empty;
            foreach (var item in test2)
            {
                final += item;
            }

            try
            {
                return string.IsNullOrWhiteSpace(a) ? Convert.ToInt32(final) : Convert.ToInt32(a + final);
            }
            catch (Exception ex)
            {
                return 0;
            };
        }

        public int FirstUniqChar(string s)
        {
            var test = s.ToCharArray();
            var duplicate = test.GroupBy(a => a).Select(a => new { a.Key, Count = a.Count() });
            if (duplicate.Count(a => a.Count == 1) == 0) return -1;
            var chars = duplicate.Where(a => a.Count == 1).FirstOrDefault().Key;
            return s.IndexOf(chars);

            return duplicate.Count(a => a.Count == 1) == 0 ? -1 : duplicate.Count(a => a.Count == 1);
        }

        public int[] PlusOne(int[] digits)
        {
            int index = digits.Length - 1;
            digits[index] = digits[index] + 1;
            return digits;
        }

        public static void Rotate(int[] nums, int k)
        {
            int len = nums.Length;
            int[] result = nums.ToArray();
            //for (int i = 0; i < k; i++)
            //{
            //    for (int j = 0; j < nums.Length; j++)
            //    {
            //        nums[j] = nums[len - 1 - i];
            //    }
            //}
        }

        public static int RemoveDuplicates(int[] nums)
        {
            ////nums = nums.Distinct().ToArray();
            ////return nums.Count();

            if (nums == null) return 0;
            if (!nums.Any()) return 0;
            int len = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    nums[len] = nums[i];
                    len++;
                }
            }
            return len;
        }
        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            return Helper(preorder, inorder, 0, preorder.Length - 1, 0, inorder.Length);
        }

        public static TreeNode Helper(int[] preorder, int[] inorder, int preOrderLeftIndex, int preOrderRightIndex, int inOrderLeftIndex, int inOrderRightIndex)
        {
            int root = preorder[preOrderLeftIndex];
            var parentTree = new TreeNode(root);
            int inOrderRoot = Array.IndexOf(inorder, root);

            preorder = preorder.Skip(preOrderLeftIndex + 1).Take(preOrderRightIndex + 1).ToArray();

            parentTree.left = Helper(preorder, inorder, 0, preorder.Length - 1, 0, inOrderRoot);
            parentTree.right = Helper(preorder, inorder, 0, preorder.Length - 1, inOrderRoot, inorder.Length - 1);
            return parentTree;
        }


        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root != null) result.Add(root.val);
            if (root != null && root.left != null) result.AddRange(PreorderTraversal(root.left));
            if (root != null && root.right != null) result.AddRange(PreorderTraversal(root.right));
            return result;
        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root != null && root.left != null) result.AddRange(InorderTraversal(root.left));
            if (root != null) result.Add(root.val);
            if (root != null && root.right != null) result.AddRange(InorderTraversal(root.right));
            return result;
        }

        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if (root != null && root.left != null) result.AddRange(PostorderTraversal(root.left));
            if (root != null && root.right != null) result.AddRange(PostorderTraversal(root.right));
            if (root != null) result.Add(root.val);
            return result;
        }
        public IList<IList<int>> LevelOrderFinal(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Queue<TreeNode> rootQueue = new Queue<TreeNode>();
            if (root != null)
            {
                rootQueue.Enqueue(root);

                while (rootQueue.Any())
                {
                    IList<int> nodeValues = new List<int>();
                    int currentSize = rootQueue.Count;
                    int index = 0;
                    while (index < currentSize)
                    {
                        var node = rootQueue.Dequeue();
                        if (node != null) nodeValues.Add(node.val);
                        if (node.left != null) rootQueue.Enqueue(node.left);
                        if (node.right != null) rootQueue.Enqueue(node.right);
                        index++;
                    }
                    result.Add(nodeValues);
                }
            }

            return result;
        }

        public bool ContainsDuplicate(int[] nums)
        {
            if (nums == null) return false;
            if (!nums.Any()) return false;
            var duplicate = nums.GroupBy(a => a).Select(a => new { a.Key, count = a.Count() });
            if (duplicate.Any(a => a.count > 1)) return true;
            return false;
        }

        public int SingleNumber(int[] nums)
        {
            var duplicate = nums.GroupBy(a => a).Select(a => new { a.Key, count = a.Count() });
            return duplicate.FirstOrDefault(a => a.count == 1).Key;
        }

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            ////if (nums1.Length > nums2.Length)
            ////    return nums2.Where(a => nums1.Any(b => b == a)).ToArray();
            //// else 
            ////    return nums1.Where(a => nums2.Any(b => b == a)).ToArray();
            ///
            return nums1.Intersect(nums2).ToArray();
        }

        public static int MaxDepth(TreeNode root)
        {
            int maxLeftLength = 0, maxRightLength = 0;
            if (root == null) return 0;
            if (root.left != null)
            {
                maxLeftLength = MaxDepth(root.left);
            }
            if (root.right != null)
            {
                maxRightLength = MaxDepth(root.right);
            }

            int depth = Math.Max(maxLeftLength, maxRightLength) + 1;
            return depth;
        }

        public static bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            return IsMirror(root.left, root.right);
        }

        public static bool IsMirror(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left == null) return false;
            if (right == null) return false;
            if (left.val == right.val) return IsMirror(left.left, right.right) && IsMirror(left.right, right.left);
            return false;
        }

    }
}
