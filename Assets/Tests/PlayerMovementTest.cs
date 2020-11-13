using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerMovementTest
    {
        private PlayerScript player;

        [SetUp]
        public void Setup()
        {
            GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
            player = gameGameObject.GetComponent<PlayerScript>();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(player.gameObject);
        }
        // A Test behaves as an ordinary method
        [UnityTest]
        public IEnumerator PlayerMovementSimplePasses()
        {
            KeyCode[] input = { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
            Vector3[] output = new Vector3[4];
            for (int i = 0; i < 4; i++)
            {
               output[i] = player.movePlayer(input[i]);
            }
            Vector3[] expected = { new Vector3(0.0f, 0.1f), new Vector3(-0.1f, 0.0f), new Vector3(0.0f, -0.1f), new Vector3(0.1f, 0.0f) };

            CollectionAssert.AreEqual(expected, output);

            yield return null;
        }
    }
}
