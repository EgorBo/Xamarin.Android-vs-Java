using System.Collections.Generic;

namespace ContactListXamarin
{
    public class Test2 : ITest
    {
        public void Run()
        {
            var list = new List<FooContainer>(); //let's don't specify initial capacity
            for (int i = 0; i < 1000000; i++)
            {
                list.Add(new FooContainer(i, i));
            }
            var filteredList = new List<FooContainer>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Sum % 2 == 0)
                {
                    filteredList.Add(list[i]);
                }
            }
        }
    }
}