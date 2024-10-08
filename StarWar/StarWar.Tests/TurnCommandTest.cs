using StarWar;

namespace StarWar.Tests
{
    public class TurnCommandTest
    {
       
        [Fact]
        public void TheGameObjectCanRotateAroundItsOwnAxis() 
        {
            var turnable = new Mock<ITurnable>();

            turnable.SetupGet(t => t.Angle).Returns(new VectorAngle(45)).Verifiable();
            turnable.SetupGet(t => t.DeltaAngle).Returns(new VectorAngle(90)).Verifiable();

            ICommand turnCommand = new TurnCommand(turnable.Object);

            turnCommand.Execute();

            turnable.Verify();
            turnable.VerifySet(t => t.Angle = new VectorAngle(135), Times.Once);

            turnable.VerifyAll();
        }
       
        [Fact]
        public void TheAngleOfGameObjectCanNotBeDefined()
        {
            var turnable = new Mock<ITurnable>();

            turnable.SetupGet(t => t.Angle).Throws(() => new Exception()).Verifiable();
            turnable.SetupGet(t => t.DeltaAngle).Returns(new VectorAngle(100)).Verifiable();

            ICommand turnCommand = new TurnCommand(turnable.Object);

            Assert.Throws<Exception>(() => turnCommand.Execute());
        }
        
        [Fact]
        public void TheDeltaAngleOfGameObjectCanNotBeDefined()
        {
            var turnable = new Mock<ITurnable>();

            turnable.SetupGet(t => t.Angle).Returns(new VectorAngle(45)).Verifiable();
            turnable.SetupGet(t => t.DeltaAngle).Throws(() => new Exception()).Verifiable();

            ICommand turnCommand = new TurnCommand(turnable.Object);

            Assert.Throws<Exception>(() => turnCommand.Execute());
        }
        [Fact]
        public void TheGameObjectCanNotRotateAroundItsOwnAxis()
        {
            var turnable = new Mock<ITurnable>();

            turnable.SetupGet(t => t.Angle).Returns(new VectorAngle(120)).Verifiable();
            turnable.SetupGet(t => t.DeltaAngle).Returns(new VectorAngle(90)).Verifiable();
            turnable.SetupSet(t => t.Angle = It.IsAny<VectorAngle>()).Throws(() => new Exception()).Verifiable();

            ICommand turnCommand = new TurnCommand(turnable.Object);

            Assert.Throws<Exception>(() => turnCommand.Execute());
        }
    }
}