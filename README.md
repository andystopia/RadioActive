# RadioActive

Type-based Unity Event System.

## Idea

Oftentimes, Unity programmers will just take references to other objects in the scene and invoke methods directly. While efficient (on CPU cycles), can lead to new design elements requiring modification of existing, working design elements, for every element they interface with. With a messaging system, by simply taking reference to the `Messenger` instance, you can react to events from other game objects without either game object's implementation referencing the other game object. In this way, new features require entirely new code, rather than on modifying existing code.

## Design
The design uses monobehaviors as message channels from 
which anybody can publish and receive strongly-typed events through unique event queues. 

## Guide

![a visual guide to the API](guide.png)


## I want it! How do I get it?

```
git clone --depth 1 https://github.com/andystopia/RadioActive
```

inside your unity programming directory.

\*must have `git` installed


## To be supported in the future
 - [ ] Unsubscribing
 - [ ] `[Int, Type]` extensible event style
 - [ ] Inheritance-aware event method call resolution
 - [ ] One event != one signature


## Contributing
Open to PRs :D
