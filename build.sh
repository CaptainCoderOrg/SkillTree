#!/bin/bash
dotnet build CaptainCoder.Core/ -c Release
CORE_PATH="CaptainCoder.Core/CaptainCoder/Core/bin/Release/netstandard2.1"
CORE="CaptainCoder.Core"
SKILLTREE_PATH="CaptainCoder.Core/CaptainCoder/SkillTree/bin/Release/netstandard2.1"
SKILLTREE="CaptainCoder.SkillTree"
UNITY_DLL_PATH="Unity Skill Tree/Assets/Plugins/CaptainCoder"
cp "$CORE_PATH/$CORE.dll" \
    "$CORE_PATH/$CORE.xml" \
    "$SKILLTREE_PATH/$SKILLTREE.dll" \
    "$SKILLTREE_PATH/$SKILLTREE.xml" \
    "$UNITY_DLL_PATH/"