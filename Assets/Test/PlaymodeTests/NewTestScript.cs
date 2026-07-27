using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;

public class PlayerPlayModeTest
{
    [UnityTest]
    public IEnumerator CreatePlayer_ShouldNotBeNull()
    {
        GameObject player = new GameObject("Player");

        yield return null;

        Assert.IsNotNull(player);

        Object.Destroy(player);
    }

    [UnityTest]
    public IEnumerator PlayerSpawnAtOrigin()
    {
        GameObject player =
            new GameObject("Player");

        player.transform.position =
            Vector3.zero;

        yield return null;

        Assert.AreEqual(
            Vector3.zero,
            player.transform.position);

        Object.Destroy(player);
    }
    [UnityTest]
    public IEnumerator BuildHouse_ShouldCreateHouse()
    {
        GameObject house =
            GameObject.CreatePrimitive(
                PrimitiveType.Cube);

        yield return null;

        Assert.IsNotNull(house);

        Object.Destroy(house);
    }
}