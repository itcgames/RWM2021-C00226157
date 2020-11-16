using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuite
{
    private PlayerScript playerScript;

    [UnityTest]
    public IEnumerator PlayerMoveUpTest()
    {
        GameObject playerGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
        playerScript = playerGameObject.GetComponent<PlayerScript>();

        float initialYPos = playerGameObject.transform.position.y;

        yield return playerScript.movePlayer(KeyCode.W);

        Assert.Greater(playerGameObject.transform.position.y, initialYPos);

        Object.Destroy(playerGameObject.gameObject);
    }

    [UnityTest]
    public IEnumerator PlayerMoveDownTest()
    {
        GameObject playerGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
        playerScript = playerGameObject.GetComponent<PlayerScript>();

        float initialYPos = playerGameObject.transform.position.y;

        yield return playerScript.movePlayer(KeyCode.S);

        Assert.Less(playerGameObject.transform.position.y, initialYPos);

        Object.Destroy(playerGameObject.gameObject);
    }

    [UnityTest]
    public IEnumerator PlayerMoveLeftTest()
    {
        GameObject playerGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
        playerScript = playerGameObject.GetComponent<PlayerScript>();

        float initialXPos = playerGameObject.transform.position.x;

        yield return playerScript.movePlayer(KeyCode.A);

        Assert.Less(playerGameObject.transform.position.x, initialXPos);

        Object.Destroy(playerGameObject.gameObject);
    }

    [UnityTest]
    public IEnumerator PlayerMoveRightTest()
    {
        GameObject playerGameObject =
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
        playerScript = playerGameObject.GetComponent<PlayerScript>();

        float initialXPos = playerGameObject.transform.position.x;

        yield return playerScript.movePlayer(KeyCode.D);

        Assert.Greater(playerGameObject.transform.position.x, initialXPos);

        Object.Destroy(playerGameObject.gameObject);
    }
}
