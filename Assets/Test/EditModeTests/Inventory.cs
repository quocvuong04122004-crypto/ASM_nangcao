using NUnit.Framework;
using System.Collections.Generic;

public class BuildRequirementTest
{
    [Test]
    public void BuildRequirement_ShouldReturnTrue()
    {
        List<string> inventory = new List<string>();

        inventory.Add("Wood");
        inventory.Add("Stone");

        bool canBuild =
            inventory.Contains("Wood") &&
            inventory.Contains("Stone");

        Assert.IsTrue(canBuild);
    }
   
    [Test]
    public void InventoryCount_ShouldBeTwo()
    {
        List<string> inventory = new List<string>();

        inventory.Add("Wood");
        inventory.Add("Stone");

        Assert.AreEqual(4, inventory.Count);
    }

    [Test]
    public void MissingStone_ShouldReturnFalse()
    {
        List<string> inventory = new List<string>();

        inventory.Add("Wood");

        bool canBuild =
            inventory.Contains("Wood") &&
            inventory.Contains("Stone");

        Assert.IsFalse(canBuild);
    }
}