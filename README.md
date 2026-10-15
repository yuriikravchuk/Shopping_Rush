# Shopping Rush

A hyper-casual mobile game made in Unity 2021.3. Products roll past on a conveyor. Tap the ones on your shopping list to grab them and drop them into the cart, and finish the list to win.

**Android build:** download the APK from [Releases](../../releases).

## Gameplay

- Each round generates a mission: a random product type and how many of it to collect.
- Tap a product on the conveyor. The hand reaches out, grips it and releases it into the cart.
- Products that reach the end of the belt are collected and reused.
- When the mission is complete, the camera animates to a finish view and the character dances.

## Code

```
Assets/Scripts/Logic/Mission        Mission, MissionGenerator, MissionPresenter
Assets/Scripts/Logic/State Machine  game states (Menu, Play, Finish) built by a factory
Assets/Scripts/Logic/Pool           generic object pool and a pool over several prefabs
Assets/Scripts/Map                  conveyor, product spawner, cart, trash collector, products config
Assets/Scripts/Player               hand grip, product release, player states (default, dance)
Assets/Scripts/UI                   tap input, mission view, menus
```

- **State machines.** The game and the player each run their own state machine, so the finish state can switch the player into the dance state.
- **Pooling.** `MultiObjectsPool<T>` reuses disabled instances of several product prefabs and picks one by predicate. The spawner takes products from the pool, and the trash collector returns them.
- **Mission flow.** The mission is a model, its presenter listens for `Cart.ProductCollected`, and the mission view only renders. Game logic stays out of the UI.

## Running

Open the project in Unity 2021.3, start `Assets/Scenes/Main`, and switch the platform to Android to build.
