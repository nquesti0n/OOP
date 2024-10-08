﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWar.Tests
{
    public class IQueueExample
    {
        [Fact]
        public void IQueueExampleTakeMethod()
        {
            var qReal = new Queue<ICommand>();
            var qMock = new Mock<IQueue>();
            qMock.Setup(q => q.Take()).Returns(qReal.Dequeue);

            var cmd = new Mock<ICommand>();
            qReal.Enqueue(cmd.Object);

            Assert.Equal(cmd.Object, qMock.Object.Take());
        }

        [Fact]
        public void IQueueExampleAddMethod()
        {
            var qReal = new Queue<ICommand>();
            var qMock = new Mock<IQueue>();

            qMock.Setup(q => q.Take()).Returns(qReal.Dequeue);
            qMock.Setup(q => q.Add(It.IsAny<ICommand>())).Callback(
            (ICommand cmd) =>
            {
                qReal.Enqueue(cmd);
            });

            var cmd = new Mock<ICommand>();
            qMock.Object.Add(cmd.Object);

            Assert.Equal(cmd.Object, qMock.Object.Take());
        }
    }

}
