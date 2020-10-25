﻿using UnityEngine;
using UnityEngine.Video;
using Unity;
using UnityEngine.Experimental.UIElements;
using Assets.Scripts;

public class WindowsManagement : MonoBehaviour
{
  public GameObject Level1;
  public GameObject Level2;
  public GameObject Level3;
  public GameObject Level4;
  public GameObject Intro;
  public GameObject Loading;

  public GameObject MenuRestart;
  public GameObject MenuNext;

  private int currentLevel = 0;

  void Start()
    {
    MenuRestart.GetComponentInChildren<ButtonScript>().ActionDelegate += ShowRestart;
    MenuRestart.GetComponentInChildren<ButtonScriptExit>().ActionDelegate += ExitGame;
    MenuNext.GetComponentInChildren<ButtonScript>().ActionDelegate += ShowRestart;
    MenuNext.GetComponentInChildren<ButtonScriptExit>().ActionDelegate += ExitGame;
    MenuNext.GetComponentInChildren<ButtonScriptNext>().ActionDelegate += NextLevel;

    Intro.active = true;
    Level1.active = false;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
    Loading.active = false;
    MenuRestart.active = false;
    MenuNext.active = false;
    var introVideo = Intro.GetComponentInChildren<VideoPlayer>();
    introVideo.Play();
    introVideo.loopPointReached += ShowLoading1;
    //StartLev1(introVideo);
  }

  public void ShowLoading1(VideoPlayer vp)
  {
    vp.Stop();
    Intro.active = false;
    Level1.active = false;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
    Loading.active = true;
    var loadingVideo = Loading.GetComponentInChildren<VideoPlayer>();
    loadingVideo.Play();
    loadingVideo.loopPointReached += StartLev1;
  }

  //public void ShowLoading2()
  //{
  //  Intro.active = false;
  //  Level1.active = false;
  //  Level2.active = false;
  //  Level3.active = false;
  //  Level4.active = false;
  //  Loading.active = true;
  //  var loadingVideo = Loading.GetComponentInChildren<VideoPlayer>();
  //  loadingVideo.Play();
  //  loadingVideo.loopPointReached += StartLev2;
  //}

  //public void ShowLoading3()
  //{
  //  Intro.active = false;
  //  Level1.active = false;
  //  Level2.active = false;
  //  Level3.active = false;
  //  Level4.active = false;
  //  Loading.active = true;
  //  var loadingVideo = Loading.GetComponentInChildren<VideoPlayer>();
  //  loadingVideo.Play();
  //  loadingVideo.loopPointReached += StartLev3;
  //}

  //public void ShowLoading4()
  //{
  //  Intro.active = false;
  //  Level1.active = false;
  //  Level2.active = false;
  //  Level3.active = false;
  //  Level4.active = false;
  //  Loading.active = true;
  //  var loadingVideo = Loading.GetComponentInChildren<VideoPlayer>();
  //  loadingVideo.Play();
  //  loadingVideo.loopPointReached += StartLev4;
  //}

  public void ShowEnd()
  {
    Level1.active = false;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
    MenuRestart.active = true;
  }
  public void ShowRestart()
  {
    MenuRestart.active = false;
    MenuNext.active = false;
    switch (currentLevel)
    {
      case 1:
        var map1 = Level1.GetComponentInChildren<Map1>();
        map1.SetStartPosition();
        StartLev1();
        return;
      case 2:
        var map21 = Level2.GetComponentInChildren<Map2>();
        map21.SetStartPosition();
        var map22 = Level2.GetComponentInChildren<Map2_Invert>();
        map22.SetStartPosition();
        StartLev2();
        return;
      case 3:
        var map31 = Level3.GetComponentInChildren<Map3>();
        map31.SetStartPosition();
        var map32 = Level3.GetComponentInChildren<Map3_Invert2>();
        map32.SetStartPosition();
        StartLev3();
        return;
      case 4:
        var map41 = Level4.GetComponentInChildren<Map4>();
        map41.SetStartPosition();
        var map42 = Level4.GetComponentInChildren<Map4_Invert>();
        map42.SetStartPosition();
        StartLev4();
        return;
    }
  }

  public void NextLevel()
  {
    switch (currentLevel)
    {
      case 1:
        StartLev2();
        return;
      case 2:
        StartLev3();
        return;
      case 3:
        StartLev4();
        return;
      case 4:
        ShowEnd();
        return;
    }
  }

  public void ExitGame()
  {
    Application.Quit();
  }

  public void StartLev1(VideoPlayer vp)
  {
    vp.Stop();
    MenuRestart.active = false;
    MenuNext.active = false;
    Intro.active = false;
    Level1.active = true;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
    Loading.active = false;
    currentLevel = 1;

        SoundSystem.Instance.Play("Main Theme");
        PreloaderAnimator.Instance.Play("Start_Level");
    }
  public void StartLev1()
  {
    MenuRestart.active = false;
    MenuNext.active = false;
    Intro.active = false;
    Level1.active = true;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
    Loading.active = false;
    currentLevel = 1;

        SoundSystem.Instance.Play("Main Theme");
        PreloaderAnimator.Instance.Play("Start_Level");
    }

  public void StartLev2()
  {
    MenuRestart.active = false;
    MenuNext.active = false;
    Intro.active = false;
    Level1.active = false;
    Level2.active = true;
    Level3.active = false;
    Level4.active = false;
    Loading.active = false;
    currentLevel = 2;

        SoundSystem.Instance.Play("Main Theme");
        PreloaderAnimator.Instance.Play("Start_Level");
    }

  public void StartLev3()
  {
    MenuRestart.active = false;
    MenuNext.active = false;
    Intro.active = false;
    Level1.active = false;
    Level2.active = false;
    Level3.active = true;
    Level4.active = false;
    Loading.active = false;
    currentLevel = 3;

        SoundSystem.Instance.Play("Main Theme");
        PreloaderAnimator.Instance.Play("Start_Level");
    }

  public void StartLev4()
  {
    MenuRestart.active = false;
    MenuNext.active = false;
    Intro.active = false;
    Level1.active = false;
    Level2.active = false;
    Level3.active = false;
    Level4.active = true;
    Loading.active = false;
    currentLevel = 4;

        SoundSystem.Instance.Play("Main Theme");
        PreloaderAnimator.Instance.Play("Start_Level");
    }
  public void GameEnd()
  {
    Intro.active = true;
    Level1.active = false;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
    Loading.active = false;
    var introVideo = Intro.GetComponentInChildren<VideoPlayer>();
    introVideo.Play();
    //introVideo.loopPointReached += ShowLoading1;
  }

  public void ToNextLevel()
  {
    Level1.active = false;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
    MenuNext.active = true;
  }
  // Update is called once per frame
  void Update()
    {
        
    }
}
