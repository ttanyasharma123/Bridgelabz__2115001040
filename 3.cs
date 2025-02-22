using System;
using System.Collections.Generic;

public class ListManager
{
    // Method to add an element to the list
    public void AddElement(List<int> list, int element)
    {
        if (list == null) throw new ArgumentNullException(nameof(list));
        list.Add(element);
    }

    // Method to remove an element from the list
    public bool RemoveElement(List<int> list, int element)
    {
        if (list == null) throw new ArgumentNullException(nameof(list));
        return list.Remove(element);
    }

    // Method to get the size of the list
    public int GetSize(List<int> list)
    {
        if (list == null) throw new ArgumentNullException(nameof(list));
        return list.Count;
    }
}





.Nunit Test Cases 

using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ListManagerTests
{
    [TestFixture]
    public class ListManagerTests
    {
        private ListManager _listManager;
        private List<int> _list;

        [SetUp]
        public void Setup()
        {
            _listManager = new ListManager();
            _list = new List<int>();
        }

        [Test]
        public void AddElement_ValidElement_AddsSuccessfully()
        {
            _listManager.AddElement(_list, 10);
            Assert.Contains(10, _list);
        }

        [Test]
        public void RemoveElement_ExistingElement_RemovesSuccessfully()
        {
            _listManager.AddElement(_list, 20);
            bool isRemoved = _listManager.RemoveElement(_list, 20);
            Assert.IsTrue(isRemoved);
            Assert.IsFalse(_list.Contains(20));
        }

        [Test]
        public void RemoveElement_NonExistingElement_ReturnsFalse()
        {
            bool isRemoved = _listManager.RemoveElement(_list, 30);
            Assert.IsFalse(isRemoved);
        }

        [Test]
        public void GetSize_EmptyList_ReturnsZero()
        {
            int size = _listManager.GetSize(_list);
            Assert.AreEqual(0, size);
        }

        [Test]
        public void GetSize_AfterAddingElements_ReturnsCorrectSize()
        {
            _listManager.AddElement(_list, 5);
            _listManager.AddElement(_list, 15);
            int size = _listManager.GetSize(_list);
            Assert.AreEqual(2, size);
        }

        [Test]
        public void GetSize_AfterRemovingElement_ReturnsUpdatedSize()
        {
            _listManager.AddElement(_list, 5);
            _listManager.AddElement(_list, 15);
            _listManager.RemoveElement(_list, 5);
            int size = _listManager.GetSize(_list);
            Assert.AreEqual(1, size);
        }

        [Test]
        public void AddElement_NullList_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _listManager.AddElement(null, 10));
        }

        [Test]
        public void RemoveElement_NullList_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _listManager.RemoveElement(null, 10));
        }

        [Test]
        public void GetSize_NullList_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _listManager.GetSize(null));
        }
    }
}

