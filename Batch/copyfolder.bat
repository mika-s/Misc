@echo off
REM Delete Foldername_Copy and copy Foldername to Foldername_Copy

RD /S /Q Foldername_Copy
XCOPY /s /e /i /y Foldername Foldername_Copy
