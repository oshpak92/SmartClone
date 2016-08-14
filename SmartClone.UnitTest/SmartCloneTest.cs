﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartClone.UnitTest.TestData;

namespace SmartClone.UnitTest
{
    [TestClass]
    public class SmartCloneTest
    {
        /// <summary>
        ///     Test ItemSet clone generated by default
        /// </summary>
        [TestMethod]
        public void TestRandomItemSetClone()
        {
            var sourceItemSet = ItemSetDataManager.GetRandomItemSet;
            try
            {
                sourceItemSet.SmartClone();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        ///     Test ItemSet clone for null reference exceprion (Header = null)
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (NullReferenceException),
            "Header can't be null. Test Failed!")]
        public void TestNullHeaderItemSetClone()
        {
            var sourceItemSet = ItemSetDataManager.GetNullHeaderItemSet;
            sourceItemSet.SmartClone();
        }

        /// <summary>
        ///     Test ItemSet clone with puplic groups and items
        /// </summary>
        [TestMethod]
        public void TestPuplicItemsClone()
        {
            var sourceItemSet = ItemSetDataManager.GetPublicGroupsItemSet;
            var clonedItemSet = sourceItemSet.SmartClone();
            Assert.IsTrue(sourceItemSet.Groups.Count == clonedItemSet.Groups.Count);
            Assert.IsTrue(sourceItemSet.Groups[0].Items.Count == clonedItemSet.Groups[0].Items.Count);
        }

        /// <summary>
        ///     Test Deep copy of objects
        /// </summary>
        [TestMethod]
        public void TestDeepClone()
        {
            var sourceItemSet = ItemSetDataManager.GetRandomItemSet;
            var referencedItemSet = sourceItemSet;

            var objectToClone = new CloneObject {Name = "Test deep clone object", ChildObject = new CloneObject()};
            var referencedObject = objectToClone;

            var clonedObject = Utils.DeepCopy(objectToClone);
            var clonedItemSet = sourceItemSet.SmartClone();

            //check simple object
            Assert.IsTrue(ReferenceEquals(objectToClone, referencedObject),
                "Referenced objects should have the same reference");
            Assert.IsFalse(ReferenceEquals(objectToClone, clonedObject),
                "DeepClone of current objects should have different references");
            Assert.IsFalse(ReferenceEquals(objectToClone.ChildObject, clonedObject.ChildObject),
                "DeepClone of current objects should have different references");
            Assert.IsFalse(ReferenceEquals(objectToClone.Name, clonedObject.Name),
                "DeepClone of current objects should have different references");

            //check item set
            Assert.IsTrue(ReferenceEquals(sourceItemSet, referencedItemSet),
                "Referenced objects should have the same reference");
            Assert.IsFalse(ReferenceEquals(sourceItemSet, clonedItemSet),
                "DeepClone of current objects should have different references");
        }

        /// <summary>
        ///     Test ItemSet clone with puplic groups and items
        /// </summary>
        [TestMethod]
        public void TestMaximizedHeaderItemsClone()
        {
            var sourceItemSet = ItemSetDataManager.GetMaximizedHeaderItemSet;
            var clonedItemSet = sourceItemSet.SmartClone();
            Assert.IsTrue(sourceItemSet.Groups.Any() && !clonedItemSet.Groups.Any());
        }

        /// <summary>
        ///     Test ItemSet clone with puplic groups and items
        /// </summary>
        [TestMethod]
        public void TestMaximizedItemItemsClone()
        {
            var sourceItemSet = ItemSetDataManager.GetMaximizedHeaderItemSet;
            var clonedItemSet = sourceItemSet.SmartClone();
            foreach (var group in clonedItemSet.Groups)
            {
                Assert.IsTrue(group.Items.Count == 1);
            }
        }
    }
}