#!/bin/bash
dotnet build CaptainCoder.Core/ -c Release
CORE_PATH="CaptainCoder.Core/CaptainCoder/Core/bin/Release/netstandard2.1"
CORE="CaptainCoder.Core"
CORE_UNITY_PATH="CaptainCoder.Core/CaptainCoder/Core.UnityEngine/bin/Release/netstandard2.1"
CORE_UNITY="CaptainCoder.Core.UnityEngine"
SKILLTREE_PATH="CaptainCoder.Core/CaptainCoder/SkillTree/bin/Release/netstandard2.1"
SKILLTREE="CaptainCoder.SkillTree"
UNITY_DLL_PATH="Unity Skill Tree/Assets/Plugins/CaptainCoder"
cp "$CORE_PATH/$CORE.dll" \
    "$CORE_PATH/$CORE.xml" \
    "$CORE_UNITY_PATH/$CORE_UNITY.dll" \
    "$CORE_UNITY_PATH/$CORE_UNITY.xml" \
    "$SKILLTREE_PATH/$SKILLTREE.dll" \
    "$SKILLTREE_PATH/$SKILLTREE.xml" \
    "$UNITY_DLL_PATH/"