@echo off
setlocal

echo Processing EventHistory Schema
xsd /classes /n:UnifiedAutomation.EventHistory EventHistorySchema.xsd

echo #pragma warning disable 1591 > temp.txt
type EventHistorySchema.cs >> temp.txt
type temp.txt > EventHistorySchema.cs

del temp.txt