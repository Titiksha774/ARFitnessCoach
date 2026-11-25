# AR Fitness Coach

A mobile AR app made in Unity that places a 3D virtual trainer on the floor in front of you and demonstrates exercises.

## Features

- **Tap to place:** AR Foundation detects horizontal planes, and tapping the floor spawns the trainer there, facing upright (`TrainerSpawner.cs`, using `ARRaycastManager`). In the Editor you can place it with a mouse click.
- **Exercise demos:** UI buttons make the trainer play one of four animations: **jumping jacks, air squats, push-ups and sit-ups** (`TrainerController.cs`, driven by `TrainerAnimator.controller`).
- **Remove the trainer** and place it again somewhere else.
- Built on Unity's **Mobile AR template** (plane visualisation, onboarding goals and menu UI from `MobileARTemplateAssets`).

## My code

| File | What it does |
|---|---|
| `Assets/TrainerSpawner.cs` | Raycasts touches/clicks against detected planes, spawns and deletes the trainer, and forwards the exercise buttons to it |
| `Assets/TrainerController.cs` | Plays the exercise animation states on the trainer's Animator |
| `Assets/ARTapToPlace.cs` | Simpler tap-to-place script from an earlier version |
| `Assets/TrainerAnimator.controller` | Animator with the four exercise states |

Everything under `MobileARTemplateAssets/`, `Samples/`, `XR/` and `XRI/` comes from Unity's AR template and the XR Interaction Toolkit samples.

## Running it

1. Open the project in Unity **2022.3.62f1** with Android (ARCore) or iOS (ARKit) build support.
2. Open `Assets/Scenes/SampleScene.unity`.
3. Build to an AR-capable phone, point it at the floor until a plane appears, then tap to place the trainer.

## Tools

Unity 2022.3, C#, AR Foundation 5.2, ARCore / ARKit, XR Interaction Toolkit 3.1, Mixamo character and animations.
