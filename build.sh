#!/bin/bash
dotnet build CaptainCoder.Core/ -c Release
CORE_PATH="CaptainCoder.Core/CaptainCoder/Core/bin/Release/netstandard2.1"
CORE="CaptainCoder.Core"
INVENTORY_PATH="CaptainCoder.Core/CaptainCoder/Inventory/bin/Release/netstandard2.1"
INVENTORY="CaptainCoder.Inventory"
UNITY_DLL_PATH="Unity Skill Tree/Assets/Plugins/CaptainCoder"
cp "$CORE_PATH/$CORE.dll" \
    "$CORE_PATH/$CORE.xml" \
    "$INVENTORY_PATH/$INVENTORY.dll" \
    "$INVENTORY_PATH/$INVENTORY.xml" \
    "$UNITY_DLL_PATH/"