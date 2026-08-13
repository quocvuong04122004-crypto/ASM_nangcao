using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Lab6Tests
{
    // =========================
    // INVENTORY UI
    // =========================

    [UnityTest]
    public IEnumerator InventoryUI_ShouldExist()
    {
        yield return null;

        InventoryUI inventory =
            Object.FindFirstObjectByType<InventoryUI>();

        Assert.IsNotNull(
            inventory,
            "InventoryUI không tồn tại"
        );
    }

    [UnityTest]
    public IEnumerator Inventory_ShouldContainSlot()
    {
        yield return null;

        InventorySlotUI[] slots =
            Object.FindObjectsByType<InventorySlotUI>(
                FindObjectsSortMode.None
            );

        Assert.Greater(
            slots.Length,
            0,
            "Inventory không có slot"
        );
    }

    [UnityTest]
    public IEnumerator InventoryManager_ShouldExist()
    {
        yield return null;

        InventoryManager manager =
            Object.FindFirstObjectByType<InventoryManager>();

        Assert.IsNotNull(manager);
    }


    // =========================
    // HOTBAR
    // =========================

    [UnityTest]
    public IEnumerator Hotbar_ShouldExist()
    {
        yield return null;

        HotbarUI hotbar =
            Object.FindFirstObjectByType<HotbarUI>();

        Assert.IsNotNull(hotbar);
    }

    [UnityTest]
    public IEnumerator Hotbar_ShouldBeActive()
    {
        yield return null;

        HotbarUI hotbar =
            Object.FindFirstObjectByType<HotbarUI>();

        Assert.IsNotNull(hotbar);

        Assert.IsTrue(
            hotbar.gameObject.activeInHierarchy
        );
    }

    [UnityTest]
    public IEnumerator Hotbar_ShouldContainUIElements()
    {
        yield return null;

        HotbarUI hotbar =
            Object.FindFirstObjectByType<HotbarUI>();

        Assert.IsNotNull(hotbar);

        Assert.Greater(
            hotbar.transform.childCount,
            0
        );
    }


    // =========================
    // AUDIO
    // =========================

    [UnityTest]
    public IEnumerator AudioSetting_ShouldExist()
    {
        yield return null;

        AudioSetting audio =
            Object.FindFirstObjectByType<AudioSetting>();

        Assert.IsNotNull(audio);
    }

    [UnityTest]
    public IEnumerator VolumeUI_ShouldExist()
    {
        yield return null;

        VolumeUI volume =
            Object.FindFirstObjectByType<VolumeUI>();

        Assert.IsNotNull(volume);
    }

    [Test]
    public void AudioVolume_ShouldBeValid()
    {
        Assert.GreaterOrEqual(
            AudioListener.volume,
            0f
        );

        Assert.LessOrEqual(
            AudioListener.volume,
            1f
        );
    }


    // =========================
    // ANIMATION
    // =========================

    [UnityTest]
    public IEnumerator Player_ShouldHaveAnimator()
    {
        yield return null;
        PlayerMovement player =
                    Object.FindFirstObjectByType<PlayerMovement>();

        Assert.IsNotNull(player);

        Animator animator =
            player.GetComponentInChildren<Animator>();

        Assert.IsNotNull(animator);
    }

    [UnityTest]
    public IEnumerator Animator_ShouldHaveController()
    {
        yield return null;

        PlayerMovement player =
            Object.FindFirstObjectByType<PlayerMovement>();

        Animator animator =
            player.GetComponentInChildren<Animator>();

        Assert.IsNotNull(animator);

        Assert.IsNotNull(
            animator.runtimeAnimatorController
        );
    }

    [UnityTest]
    public IEnumerator Animator_ShouldBeEnabled()
    {
        yield return null;

        PlayerMovement player =
            Object.FindFirstObjectByType<PlayerMovement>();

        Animator animator =
            player.GetComponentInChildren<Animator>();

        Assert.IsTrue(animator.enabled);
    }


    // =========================
    // EFFECT
    // =========================

    [UnityTest]
    public IEnumerator Particle_ShouldExist()
    {
        yield return null;

        ParticleSystem[] particle =
            Object.FindObjectsByType<ParticleSystem>(
                FindObjectsSortMode.None
            );

        Assert.Greater(particle.Length, 0);
    }

    [UnityTest]
    public IEnumerator Particle_ShouldBeEnabled()
    {
        yield return null;

        ParticleSystem particle =
            Object.FindFirstObjectByType<ParticleSystem>();

        Assert.IsNotNull(particle);

        Assert.IsTrue(
            particle.gameObject.activeInHierarchy
        );
    }

    [UnityTest]
    public IEnumerator Particle_ShouldPlay()
    {
        ParticleSystem particle =
            Object.FindFirstObjectByType<ParticleSystem>();

        Assert.IsNotNull(particle);

        particle.Play();

        yield return null;

        Assert.IsTrue(particle.isPlaying);
    }
}
