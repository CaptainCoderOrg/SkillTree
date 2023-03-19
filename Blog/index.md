---
title: Skill Tree
layout: home
nav_order: 0
---

# Let's Make a Skill Tree
{: .no_toc }

![Skill Tree](imgs/Skill%20Tree.png)

Hello coders! Captain Coder here with another learning series. On the Captain
Coder's Academy discord, it was proposed that I implement a Skill Tree live on
stream. I felt this fit into the current theme of prepping for the [2023
Dungeon Crawler Game Jam](https://itch.io/jam/dcjam2023) 

This site serves as a blog that will (hopefully) chronicle the streams for
anyone who missed them live and recap what we accomplished each day. I
hope someone finds this blog useful!

* Archived Streams Playlist: [Playlist]
* Catch the Captain Live on Twitch: [Twitch]
* Source Code: [Repository]

## Project Overview

The goal **of** this project is to create a functional skill tree system
that can be dropped into an existing project, restyled, and reused.

## Day 1 - Design Document and Project Scope

Today, we defined our learning goals, specified the scope of the project, setup
a unity project, class class library project, [xUnit] test project, and defined
a few interfaces: `ISkilledCharacter`, `ISkillNode`, and `ISkillTree`.

* [Read More]({% link pages/01-day-1.md %})
* [Watch On YouTube](https://youtube.com/live/am5e_8QieYM?feature=share)

## Day 2: Skill Tree Builder and Unit Testing

Today, we implemented a `SkillTreeBuilder` class that allows for construction of
an `ISkillTree`. While implementing this, we discovered a few flaws in our
interfaces which we corrected. Additionally, we wrote unit tests to validate
that the `SkillTreeBuilder` we implemented was correct.

* [Read More]({% link pages/02-day-2.md %})
* [Watch On YouTube](https://youtube.com/live/33_g4hJukIo)

# Day 3: Manually Building a UI

Today, we manually built a visual representation of a Skill Tree 
using Unity's UI Toolkit. Additionally, we explored the Vector Graphics
API to automatically connect nodes in the Skill Tree together.

* [Read More]({% link pages/03-day-3.md %})
* [Watch On YouTube](https://youtube.com/live/ow5piavuQaI)

# Day 4: UI Generation: Version 0

Today, we defined ScriptableObjects which can be used to specify a skill tree.
Then, we attempted to write a tool to automagically generate a UI based on a
skill tree. Unfortunately, we discovered that the desired behavior may not be
possible using a subclass of the `VisualElement` class. Off stream, the Captain
explored generating UXML which does have the intended behavior.

* [Read More]({% link pages/04-day-4.md %})
* [Watch On YouTube](https://youtube.com/live/dTeCOarDBMA)

# Day 5: UXML Serialization

Today, we implemented UXML Generators for our SkillTree and
SkillNodes. Additionally, we updated the Skill Nodes to be
intractable. Lastly, for convenience, we updated the UXML
generators to be aware of position changes by deserializing
the existing UXML prior to regeneration.

* [Read More]({% link pages/05-day-5.md %})
* [Watch On YouTube](https://youtube.com/live/Ge3wrgNvTMA?feature=share)

{% include Links.md %}