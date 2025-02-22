using System;
using System.Threading;

public class TaskManager
{
    public string LongRunningTask()
    {
        Thread.Sleep(3000); // Simulating a long-running task (3 seconds)
        return "Task Completed";
    }
}






.Nunit Test Cases 


using NUnit.Framework;
using System;

namespace TaskManagerTests
{
    [TestFixture]
    public class TaskManagerTests
    {
        private TaskManager _taskManager;

        [SetUp]
        public void Setup()
        {
            _taskManager = new TaskManager();
        }

        [Test, Timeout(2000)] // Fails if execution takes more than 2 seconds
        public void LongRunningTask_TimeoutTest()
        {
            string result = _taskManager.LongRunningTask();
            Assert.AreEqual("Task Completed", result);
        }
    }
}

