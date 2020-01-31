using NUnit.Framework;
using FluentAssertions;

namespace ActivitySelectionProblem.Test
{
    [TestFixture]
    public class RegularWeightedActivityTest
    {
        [Test]
        public void On_0_2_1_4_3_5_Returns_2() => Regular.Compute((0, 2), (1, 4), (3, 5)).Should().Be(2);

        [Test]
        public void On_0_2_2_4_3_6_Returns_2() => Regular.Compute((0, 2), (2, 4), (3, 6)).Should().Be(2);

        [Test]
        public void On_0_2_2_4_4_6_Returns_3() => Regular.Compute((0, 2), (2, 4), (4, 6)).Should().Be(3);

        [Test]
        public void On_0_2_1_4_4_6_Returns_2() => Regular.Compute((0, 2), (1, 4), (4, 6)).Should().Be(2);

        [Test]
        public void On_0_2_0_4_Returns_1() => Regular.Compute((0, 2), (0, 4)).Should().Be(1);

        [Test]
        public void On_0_4_Returns_1() => Regular.Compute((0, 4)).Should().Be(1);

        [Test]
        public void On_Empty_Returns_0() => Regular.Compute(new Activity[0]).Should().Be(0);
    }
}
