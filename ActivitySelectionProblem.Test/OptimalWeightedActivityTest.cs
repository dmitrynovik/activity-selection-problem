using NUnit.Framework;
using FluentAssertions;

namespace ActivitySelectionProblem.Test
{
    [TestFixture]
    public class OptimalWeightedActivityTest
    {
        [Test]
        public void On_0_2_1_4_3_5_Returns_4() => Weighted.Compute((0, 2), (1, 4), (3, 5)).Should().Be(4);

        [Test]
        public void On_0_2_2_4_3_6_Returns_5() => Weighted.Compute((0, 2), (2, 4), (3, 6)).Should().Be(5);

        [Test]
        public void On_0_2_1_4_4_6_Returns_5() => Weighted.Compute((0, 2), (1, 4), (4, 6)).Should().Be(5);

        [Test]
        public void On_0_2_0_4_Returns_4() => Weighted.Compute((0, 2), (0, 4)).Should().Be(4);

        [Test]
        public void On_0_4_Returns_4() => Weighted.Compute((0, 4)).Should().Be(4);

        [Test]
        public void On_Empty_Returns_4() => Weighted.Compute(new Activity[0]).Should().Be(0);
    }
}
