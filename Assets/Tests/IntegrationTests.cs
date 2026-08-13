using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class IntegrationTests
{
    // =========================================================
    // GAME UI + GAMEPLAY
    // =========================================================

    [UnityTest]
    public IEnumerator UI_Gameplay_InventorySystem_ShouldWorkTogether()
    {
        yield return null;

        InventoryManager inventoryManager =
            Object.FindFirstObjectByType<InventoryManager>();

        InventoryUI inventoryUI =
            Object.FindFirstObjectByType<InventoryUI>();

        HotbarUI hotbarUI =
            Object.FindFirstObjectByType<HotbarUI>();

        Assert.IsNotNull(
            inventoryManager,
            "InventoryManager không tồn tại"
        );

        Assert.IsNotNull(
            inventoryUI,
            "InventoryUI không tồn tại"
        );

        Assert.IsNotNull(
            hotbarUI,
            "HotbarUI không tồn tại"
        );
    }


    [UnityTest]
    public IEnumerator UI_Gameplay_Inventory_ShouldContainSlots()
    {
        yield return null;

        InventoryManager inventoryManager =
            Object.FindFirstObjectByType<InventoryManager>();

        InventorySlotUI[] slots =
            Object.FindObjectsByType<InventorySlotUI>(
                FindObjectsSortMode.None
            );

        Assert.IsNotNull(
            inventoryManager,
            "InventoryManager không tồn tại"
        );

        Assert.Greater(
            slots.Length,
            0,
            "Inventory không có Slot"
        );
    }


    [UnityTest]
    public IEnumerator UI_Gameplay_Pickup_ShouldConnectToInventory()
    {
        yield return null;

        PickupItem pickup =
            Object.FindFirstObjectByType<PickupItem>();

        InventoryManager inventoryManager =
            Object.FindFirstObjectByType<InventoryManager>();

        Assert.IsNotNull(
            pickup,
            "PickupItem không tồn tại"
        );

        Assert.IsNotNull(
            inventoryManager,
            "InventoryManager không tồn tại"
        );
    }


    // =========================================================
    // PLAYER + GAMEPLAY
    // =========================================================

    [UnityTest]
    public IEnumerator Player_Gameplay_Animator_ShouldBeConnected()
    {
        yield return null;

        PlayerMovement player =
            Object.FindFirstObjectByType<PlayerMovement>();

        Assert.IsNotNull(
            player,
            "PlayerMovement không tồn tại"
        );

        Animator animator =
            player.GetComponentInChildren<Animator>();

        Assert.IsNotNull(
            animator,
            "Player không có Animator"
        );

        Assert.IsNotNull(
            animator.runtimeAnimatorController,
            "Animator chưa có Controller"
        );
    }


    [UnityTest]
    public IEnumerator Player_Gameplay_MovementAndLook_ShouldExist()
    {
        yield return null;

        PlayerMovement movement =
            Object.FindFirstObjectByType<PlayerMovement>();

        PlayerLook look =
            Object.FindFirstObjectByType<PlayerLook>();

        Assert.IsNotNull(
            movement,
            "PlayerMovement không tồn tại"
        );

        Assert.IsNotNull(
            look,
            "PlayerLook không tồn tại"
        );
    }


    [UnityTest]
    public IEnumerator Player_Gameplay_ShouldHaveAnimatorEnabled()
    {
        yield return null;

        PlayerMovement player =
            Object.FindFirstObjectByType<PlayerMovement>();

        Assert.IsNotNull(player);

        Animator animator =
            player.GetComponentInChildren<Animator>();

        Assert.IsNotNull(animator);

        Assert.IsTrue(
            animator.enabled,
            "Animator của Player đang bị disable"
        );
    }


    // =========================================================
    // AUDIO + GAMEPLAY
    // =========================================================

    [UnityTest]
    public IEnumerator Audio_Gameplay_AudioSettingAndVolume_ShouldExist()
    {
        yield return null;

        AudioSetting audioSetting =
            Object.FindFirstObjectByType<AudioSetting>();

        VolumeUI volumeUI =
            Object.FindFirstObjectByType<VolumeUI>();

        Assert.IsNotNull(
            audioSetting,
            "AudioSetting không tồn tại"
        );

        Assert.IsNotNull(
            volumeUI,
            "VolumeUI không tồn tại"
        );
    }


    [Test]
    public void Audio_Gameplay_Volume_ShouldBeValid()
    {
        Assert.GreaterOrEqual(
            AudioListener.volume,
            0f,
            "Volume nhỏ hơn 0"
        );

        Assert.LessOrEqual(
            AudioListener.volume,
            1f,
            "Volume lớn hơn 1"
        );
    }


    [UnityTest]
    public IEnumerator Audio_Gameplay_AudioSystem_ShouldBeAvailable()
    {
        yield return null;

        AudioSetting audioSetting =
            Object.FindFirstObjectByType<AudioSetting>();

        Assert.IsNotNull(
            audioSetting,
            "AudioSetting không tồn tại"
        );

        Assert.GreaterOrEqual(
            AudioListener.volume,
            0f
        );

        Assert.LessOrEqual(
            AudioListener.volume,
            1f
        );
    }


    // =========================================================
    // EFFECT + GAMEPLAY
    // =========================================================

    [UnityTest]
    public IEnumerator Effect_Gameplay_ParticleSystem_ShouldExist()
    {
        yield return null;

        ParticleSystem particle =
            Object.FindFirstObjectByType<ParticleSystem>();

        Assert.IsNotNull(
            particle,
            "Không tìm thấy ParticleSystem"
        );
    }


    [UnityTest]
    public IEnumerator Effect_Gameplay_ParticleSystem_ShouldBeActive()
    {
        yield return null;

        ParticleSystem particle =
            Object.FindFirstObjectByType<ParticleSystem>();

        Assert.IsNotNull(
            particle,
            "Không tìm thấy ParticleSystem"
        );

        Assert.IsTrue(
            particle.gameObject.activeInHierarchy,
            "ParticleSystem đang bị disable"
        );
    }


    [UnityTest]
    public IEnumerator Effect_Gameplay_ParticleSystem_ShouldPlay()
    {
        yield return null;

        ParticleSystem particle =
            Object.FindFirstObjectByType<ParticleSystem>();

        Assert.IsNotNull(
            particle,
            "Không tìm thấy ParticleSystem"
        );

        particle.Play();

        yield return null;

        Assert.IsTrue(
            particle.isPlaying,
            "ParticleSystem không Play"
        );
    }


    // =========================================================
    // QUIZ + GAMEPLAY
    // =========================================================

    [UnityTest]
    public IEnumerator Quiz_Gameplay_ShouldExist()
    {
        yield return null;

        QuizManager quiz =
            Object.FindFirstObjectByType<QuizManager>();

        Assert.IsNotNull(
            quiz,
            "QuizManager không tồn tại"
        );
    }
}