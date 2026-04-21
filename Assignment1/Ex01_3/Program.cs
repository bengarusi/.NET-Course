
using Ex01_2;

namespace Ex01_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int treeHeight = InputHandler.GetValidTreeHeight();

            LetterTreeUtils.PrintLetterTree(treeHeight);
        }
    }
}