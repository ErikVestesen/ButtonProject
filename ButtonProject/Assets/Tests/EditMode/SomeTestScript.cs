using NUnit.Framework;

public class NewTestScript
{
    [Test]
    public void TestAddition()
    {
        //Arrange
        int startNumber = 10;
        int numberToAdd = 15;
        SomeTestClass test = new SomeTestClass(startNumber);

        //Act
        test.AddToNumber(numberToAdd);

        //Assert
        Assert.AreEqual(startNumber + numberToAdd, test.GetNumber()); 
    }

    [Test]
    public void TestAdditionFail()
    {
        //Arrange
        int startNumber = 10;
        int numberToAdd = 15;
        int offset = 1;
        SomeTestClass test = new SomeTestClass(startNumber);

        //Act
        test.AddToNumber(numberToAdd);

        //Assert
        Assert.AreEqual(startNumber + numberToAdd + offset, test.GetNumber());
    }
}
