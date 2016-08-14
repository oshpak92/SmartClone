using System;
using System.Collections.Generic;
using System.Threading;

namespace SmartClone.UnitTest.TestData
{
    /// <summary>
    ///     Class which represents test data storage
    /// </summary>
    public class ItemSetDataManager
    {
        private static readonly Random Random = new Random();

        private static readonly Lazy<ItemSet> RandomItemSet =
            new Lazy<ItemSet>(RandomItemSetGeneration,
                LazyThreadSafetyMode.ExecutionAndPublication);

        private static readonly Lazy<ItemSet> NullHeadersItemSet =
            new Lazy<ItemSet>(NullHeaderItemSetGeneration,
                LazyThreadSafetyMode.ExecutionAndPublication);

        private static readonly Lazy<ItemSet> PublicGroupsItemSet =
            new Lazy<ItemSet>(PublicGroupItemSetGeneration,
                LazyThreadSafetyMode.ExecutionAndPublication);

        private static readonly Lazy<ItemSet> PrivateGroupsItemSet =
            new Lazy<ItemSet>(PrivateGroupsItemSetGeneration,
                LazyThreadSafetyMode.ExecutionAndPublication);

        private static readonly Lazy<ItemSet> MaximizedHeaderItemSet =
            new Lazy<ItemSet>(MaximizedHeaderItemSetGeneration,
                LazyThreadSafetyMode.ExecutionAndPublication);

        private static readonly Lazy<ItemSet> HeaderMaximizedItemItemSet =
            new Lazy<ItemSet>(HeaderMaximizedItemGeneration,
                LazyThreadSafetyMode.ExecutionAndPublication);

        public static ItemSet GetRandomItemSet => RandomItemSet.Value;
        public static ItemSet GetNullHeaderItemSet => NullHeadersItemSet.Value;
        public static ItemSet GetPublicGroupsItemSet => PublicGroupsItemSet.Value;
        public static ItemSet GetPrivateGroupsItemSet => PrivateGroupsItemSet.Value;
        public static ItemSet GetMaximizedHeaderItemSet => MaximizedHeaderItemSet.Value;
        public static ItemSet GetHeaderMaximizedItemItemSet => HeaderMaximizedItemItemSet.Value;

        private static ItemSet RandomItemSetGeneration()
        {
            var randowItemSet = new ItemSet();
            randowItemSet.Header = new Item {Hidden = false, Maximized = false};
            randowItemSet.Groups = new List<ItemGroup>();
            var groupsCount = Random.Next(100);

            for (var groupsIterator = 0; groupsIterator < groupsCount; groupsIterator++)
            {
                var itemGroup = new ItemGroup();
                var itemsCoutn = Random.Next(100);
                for (var itemsIterator = 0; itemsIterator < itemsCoutn; itemsIterator++)
                {
                    itemGroup.Hidden = Convert.ToBoolean(Random.Next()%2);
                    itemGroup.Items.Add(new Item
                    {
                        Hidden = Convert.ToBoolean(Random.Next(10)%2),
                        Maximized = Convert.ToBoolean(Random.Next(10)%2)
                    });
                }
                randowItemSet.Groups.Add(itemGroup);
            }
            return randowItemSet;
        }

        private static ItemSet NullHeaderItemSetGeneration()
        {
            var randowItemSet = new ItemSet();
            randowItemSet.Header = null;
            randowItemSet.Groups = new List<ItemGroup>();
            var groupsCount = Random.Next(100);

            for (var groupsIterator = 0; groupsIterator < groupsCount; groupsIterator++)
            {
                var itemGroup = new ItemGroup();
                var itemsCoutn = Random.Next(100);
                for (var itemsIterator = 0; itemsIterator < itemsCoutn; itemsIterator++)
                {
                    itemGroup.Hidden = Convert.ToBoolean(Random.Next()%2);
                    itemGroup.Items.Add(new Item
                    {
                        Hidden = Convert.ToBoolean(Random.Next(10)%2),
                        Maximized = Convert.ToBoolean(Random.Next(10)%2)
                    });
                }
                randowItemSet.Groups.Add(itemGroup);
            }
            return randowItemSet;
        }

        private static ItemSet PublicGroupItemSetGeneration()
        {
            var randowItemSet = new ItemSet();
            randowItemSet.Header = new Item {Hidden = false, Maximized = false};
            ;
            randowItemSet.Groups = new List<ItemGroup>();
            var groupsCount = 10;

            for (var groupsIterator = 0; groupsIterator < groupsCount; groupsIterator++)
            {
                var itemGroup = new ItemGroup();
                var itemsCoutn = 5;
                for (var itemsIterator = 0; itemsIterator < itemsCoutn; itemsIterator++)
                {
                    itemGroup.Hidden = false;
                    itemGroup.Items.Add(new Item
                    {
                        Hidden = true,
                        Maximized = false
                    });
                }
                randowItemSet.Groups.Add(itemGroup);
            }
            return randowItemSet;
        }

        private static ItemSet PrivateGroupsItemSetGeneration()
        {
            var randowItemSet = new ItemSet();
            randowItemSet.Header = new Item {Hidden = false, Maximized = false};
            randowItemSet.Groups = new List<ItemGroup>();
            var groupsCount = Random.Next(100);

            for (var groupsIterator = 0; groupsIterator < groupsCount; groupsIterator++)
            {
                var itemGroup = new ItemGroup();
                var itemsCoutn = Random.Next(100);
                for (var itemsIterator = 0; itemsIterator < itemsCoutn; itemsIterator++)
                {
                    itemGroup.Hidden = true;
                    itemGroup.Items.Add(new Item
                    {
                        Hidden = Convert.ToBoolean(Random.Next(10)%2),
                        Maximized = Convert.ToBoolean(Random.Next(10)%2)
                    });
                }
                randowItemSet.Groups.Add(itemGroup);
            }
            return randowItemSet;
        }

        private static ItemSet MaximizedHeaderItemSetGeneration()
        {
            var randowItemSet = new ItemSet();
            randowItemSet.Header = new Item {Hidden = false, Maximized = true};
            randowItemSet.Groups = new List<ItemGroup>();
            var groupsCount = 10;

            for (var groupsIterator = 0; groupsIterator < groupsCount; groupsIterator++)
            {
                var itemGroup = new ItemGroup();
                var itemsCoutn = 5;
                for (var itemsIterator = 0; itemsIterator < itemsCoutn; itemsIterator++)
                {
                    itemGroup.Hidden = true;
                    itemGroup.Items.Add(new Item
                    {
                        Hidden = Convert.ToBoolean(Random.Next(10)%2),
                        Maximized = Convert.ToBoolean(Random.Next(10)%2)
                    });
                }
                randowItemSet.Groups.Add(itemGroup);
            }
            return randowItemSet;
        }

        private static ItemSet HeaderMaximizedItemGeneration()
        {
            var randowItemSet = new ItemSet();
            randowItemSet.Header = new Item {Hidden = false, Maximized = false};
            randowItemSet.Groups = new List<ItemGroup>();
            var groupsCount = 10;

            for (var groupsIterator = 0; groupsIterator < groupsCount; groupsIterator++)
            {
                var itemGroup = new ItemGroup();
                var itemsCoutn = 5;
                for (var itemsIterator = 0; itemsIterator < itemsCoutn; itemsIterator++)
                {
                    itemGroup.Hidden = true;
                    itemGroup.Items.Add(new Item
                    {
                        Hidden = true,
                        Maximized = true
                    });
                }
                randowItemSet.Groups.Add(itemGroup);
            }
            return randowItemSet;
        }
    }
}