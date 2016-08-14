using System;
using System.Collections.Generic;

namespace SmartClone.UnitTest.TestData
{
    /// <summary>
    ///     Class which represents test data storage
    /// </summary>
    public class ItemSetDataManager
    {
        private static readonly Random _random = new Random();

        static ItemSetDataManager()
        {
            GetRandomItemSet = RandomItemSetGeneration();
            GetNullHeaderItemSet = NullHeaderItemSetGeneration();
            GetPublicGroupsItemSet = PublicGroupItemSetGeneration();
            GetPrivateGroupsItemSet = PrivateGroupsItemSetGeneration();
            GetMaximizedHeaderItemSet = MaximizedHeaderItemSetGeneration();
            GetHeaderMaximizedItemItemSet = HeaderMaximizedItemGeneration();
        }

        public static ItemSet GetRandomItemSet { get; private set; }
        public static ItemSet GetNullHeaderItemSet { get; private set; }
        public static ItemSet GetPublicGroupsItemSet { get; private set; }
        public static ItemSet GetPrivateGroupsItemSet { get; private set; }
        public static ItemSet GetMaximizedHeaderItemSet { get; private set; }
        public static ItemSet GetHeaderMaximizedItemItemSet { get; private set; }

        private static ItemSet RandomItemSetGeneration()
        {
            var randowItemSet = new ItemSet();
            randowItemSet.Header = new Item {Hidden = false, Maximized = false};
            randowItemSet.Groups = new List<ItemGroup>();
            var groupsCount = _random.Next(100);

            for (var groupsIterator = 0; groupsIterator < groupsCount; groupsIterator++)
            {
                var itemGroup = new ItemGroup();
                var itemsCoutn = _random.Next(100);
                for (var itemsIterator = 0; itemsIterator < itemsCoutn; itemsIterator++)
                {
                    itemGroup.Hidden = Convert.ToBoolean(_random.Next()%2);
                    itemGroup.Items.Add(new Item
                    {
                        Hidden = Convert.ToBoolean(_random.Next(10)%2),
                        Maximized = Convert.ToBoolean(_random.Next(10)%2)
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
            var groupsCount = _random.Next(100);

            for (var groupsIterator = 0; groupsIterator < groupsCount; groupsIterator++)
            {
                var itemGroup = new ItemGroup();
                var itemsCoutn = _random.Next(100);
                for (var itemsIterator = 0; itemsIterator < itemsCoutn; itemsIterator++)
                {
                    itemGroup.Hidden = Convert.ToBoolean(_random.Next()%2);
                    itemGroup.Items.Add(new Item
                    {
                        Hidden = Convert.ToBoolean(_random.Next(10)%2),
                        Maximized = Convert.ToBoolean(_random.Next(10)%2)
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
            var groupsCount = _random.Next(100);

            for (var groupsIterator = 0; groupsIterator < groupsCount; groupsIterator++)
            {
                var itemGroup = new ItemGroup();
                var itemsCoutn = _random.Next(100);
                for (var itemsIterator = 0; itemsIterator < itemsCoutn; itemsIterator++)
                {
                    itemGroup.Hidden = true;
                    itemGroup.Items.Add(new Item
                    {
                        Hidden = Convert.ToBoolean(_random.Next(10)%2),
                        Maximized = Convert.ToBoolean(_random.Next(10)%2)
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
                        Hidden = Convert.ToBoolean(_random.Next(10)%2),
                        Maximized = Convert.ToBoolean(_random.Next(10)%2)
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